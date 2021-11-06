using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using NashSneaker.Data;
using NashSneaker.Helpers;
using NashSneaker.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly NashSneakerContext _context;
        private readonly JwtService _jwtService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(
            RoleManager<IdentityRole> roleManager, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            NashSneakerContext context,
            JwtService jwtService,
            IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _jwtService = jwtService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("Profile")]
        public IActionResult Profile()
        {
            //Get email admin from jwt token
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var emailFromPayload = jwtSecurityToken.Claims.First(claim => claim.Type == "email").Value;

            var adminVM = new UserViewModel();
            var admin = _context.Users.SingleOrDefault(x => x.Email == emailFromPayload);
            var userRole = _context.UserRoles.SingleOrDefault(x => x.UserId == admin.Id);
            var role = _context.Roles.SingleOrDefault(x => x.Id == userRole.RoleId);

            adminVM.Id = admin.Id;
            adminVM.FirstName = admin.FirstName;
            adminVM.LastName = admin.LastName;
            adminVM.Email = admin.Email;
            adminVM.PhoneNumber = admin.PhoneNumber;
            adminVM.Role = role.Name;

            return Ok(adminVM);
        }

        [HttpPut("EditProfile")]
        public IActionResult EditProfile(UserViewModel vm)
        {
            if(_context.Users.Any(x => x.Email == vm.Email))
            {
                var user = _context.Users.SingleOrDefault(x => x.Email == vm.Email);
                user.FirstName = vm.FirstName;
                user.LastName = vm.LastName;
                user.PhoneNumber = vm.PhoneNumber;

                _context.SaveChanges();

                return Ok(new { message = "Update profile successfully." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("ViewUsers")]
        public IActionResult ViewUsers()
        {
            var listUserVM = new List<UserViewModel>();
            var users = _context.Users.ToList();
            var roles = _context.Roles.ToList();

            foreach(var item in users)
            {
                UserViewModel userVM = new UserViewModel();
                var userRole = _context.UserRoles.SingleOrDefault(x => x.UserId == item.Id);
                var role = _context.Roles.SingleOrDefault(x => x.Id == userRole.RoleId);
                userVM.Id = item.Id;
                userVM.FirstName = item.FirstName;
                userVM.LastName = item.LastName;
                userVM.Email = item.Email;
                userVM.PhoneNumber = item.PhoneNumber;
                userVM.Role = role.Name;

                if(userVM.Role != "Admin")
                {
                    listUserVM.Add(userVM);
                }
            }

            return Ok(listUserVM);
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var roles = _context.Roles.Where(x => x.Name != "Admin").ToList();
            return Ok(roles);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel vm)
        {
            var roleExist = await _roleManager.RoleExistsAsync(vm.RoleName);
            if(!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(vm.RoleName));

                return Ok(new { message = "Create user role succeeded." });
            }
            else
            {
                return BadRequest(new { message = "The role name had exist." });
            }
        }

        [HttpPut("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleViewModel vm)
        {
            var user = await _userManager.FindByEmailAsync(vm.UserEmail);
            var rolesOld = await _userManager.GetRolesAsync(user);

            foreach(var item in rolesOld)
            {
                await _userManager.RemoveFromRoleAsync(user, item);
            }
            
            await _userManager.AddToRoleAsync(user, vm.RoleName);

            return Ok(new { message = "Update user role successfully." });
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserViewModel vm)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Email == vm.Email);
                var userRole = _context.UserRoles.SingleOrDefault(x => x.UserId == user.Id);
                var role = _context.Roles.SingleOrDefault(x => x.Id == userRole.RoleId);

                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded && role.Name == "Admin")
                {
                    var jwt = _jwtService.GenerateJwt(user);
                    return Ok(new { message = "Welcome Admin!", fullName = user.FirstName + " " + user.LastName, jwt });
                }
                else
                {
                    return BadRequest(new { message = "Incorrect Account." });
                }
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Incorrect Account." });
            }
        }

        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            var categories = _context.Category.ToList();
            return Ok(categories);
        }

        [HttpGet("GetCategoryById/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            if(_context.Category.Any(x => x.Id == id))
            {
                var category = _context.Category.SingleOrDefault(x => x.Id == id);
                return Ok(category);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpPost("AddNewCategory")]
        public IActionResult AddNewCategory(Category category)
        {
            if(!_context.Category.Any(x => x.Name == category.Name))
            {
                _context.Add(category);
                _context.SaveChanges();

                return Ok(new { message = "Add new category successfully." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("EditCategory")]
        public IActionResult EditCategory(Category category)
        {
            if (_context.Category.Any(x => x.Id == category.Id))
            {
                var currentCategory = _context.Category.SingleOrDefault(x => x.Id == category.Id);

                if(_context.Category.Any(x => x.Name == category.Name && category.Name != currentCategory.Name))
                {
                    return BadRequest();
                }
                else
                {
                    var _category = _context.Category.SingleOrDefault(x => x.Id == category.Id);
                    _category.Name = category.Name;
                    _category.Description = category.Description;
                    _context.SaveChanges();

                    return Ok(new { message = "Update category successfully." });
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            if (_context.Category.Any(x => x.Id == id))
            {
                var category = _context.Category.SingleOrDefault(x => x.Id == id);
                _context.Remove(category);
                _context.SaveChanges();

                return Ok(new { message = "Delete category successfully." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Products")]
        public IActionResult Products()
        {
            var products = _context.Product.ToList();
            var categories = _context.Category.ToList();
            var images = _context.Image.ToList();

            foreach(var item in categories)
            {
                item.Products = new List<Product>();
            }

            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            if (_context.Product.Any(x => x.Id == id))
            {
                var product = _context.Product.SingleOrDefault(x => x.Id == id);
                var categories = _context.Category.ToList();
                var images = _context.Image.Where(x => x.Product == product).ToList();

                foreach (var item in categories)
                {
                    item.Products = new List<Product>();
                }

                return Ok(product);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("AddNewProduct")]
        public async Task<IActionResult> AddNewProduct([FromForm]AddOrEditProductViewModel vm)
        {
            if (!_context.Product.Any(x => x.Name == vm.Name))
            {
                var product = new Product();
                var category = _context.Category.SingleOrDefault(x => x.Id == vm.CategoryId);
                product.Name = vm.Name;
                product.Price = float.Parse(vm.Price);
                product.Description = vm.Description;
                product.CreatedDate = DateTime.Now;
                product.UpdatedDate = DateTime.Now;
                product.Category = category;

                _context.Add(product);
                _context.SaveChanges();

                //Images for product
                var images = new List<Image>();
                var _product = _context.Product.SingleOrDefault(x => x.Name == product.Name);

                foreach (var item in vm.imagesFile)
                {
                    var image = new Image();
                    image.Name = Path.GetFileNameWithoutExtension(item.FileName) + "_" + DateTime.Now.ToString("ssfff");
                    //save each image & get imageName + extension
                    image.Path = await SaveImage(item, item.FileName);
                    image.Product = _product;
                    images.Add(image);
                }

                _context.AddRange(images);
                _context.SaveChanges();

                //Sizes for product
                var sizes = new List<Size>();
                
                foreach(var item in vm.Sizes)
                {
                    var size = new Size();
                    size.Name = Int16.Parse(item);
                    size.Product = _product;
                    sizes.Add(size);
                }

                _context.AddRange(sizes);
                _context.SaveChanges();

                return Ok(new { message = "Add new product successfully." });
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<string> SaveImage(IFormFile imageFile, string imageName)
        {
            string _imageName = Path.GetFileNameWithoutExtension(imageName) + "_" + DateTime.Now.ToString("ssfff") + Path.GetExtension(imageName);
            var imagePath = Path.Combine("C:\\NashSneaker\\nashsneaker_netcore\\wwwroot\\images\\products", _imageName);
            using( var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return _imageName;
        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine("C:\\NashSneaker\\nashsneaker_netcore\\wwwroot\\images\\products", imageName);
            if(System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        [HttpPut("EditProduct")]
        public async Task<IActionResult> EditProduct([FromForm]AddOrEditProductViewModel vm)
        {
            if (_context.Product.Any(x => x.Id == vm.Id))
            {
                var currentProduct = _context.Product.SingleOrDefault(x => x.Id == vm.Id);

                if (!_context.Product.Any(x => x.Name == vm.Name && vm.Name != currentProduct.Name))
                {
                    var product = _context.Product.SingleOrDefault(x => x.Id == vm.Id);
                    var category = _context.Category.SingleOrDefault(x => x.Id == vm.CategoryId);
                    product.Name = vm.Name;
                    product.Price = float.Parse(vm.Price);
                    product.Description = vm.Description;
                    product.UpdatedDate = DateTime.Now;
                    product.Category = category;

                    //Check images need to be deleted
                    if (vm.imagesDelete != null && vm.imagesDelete.Count > 0)
                    {
                        foreach (var item in vm.imagesDelete)
                        {
                            //Delete each image in this list
                            var imageDelete = _context.Image.SingleOrDefault(x => x.Path == item);
                            DeleteImage(item);
                            _context.Remove(imageDelete);
                            _context.SaveChanges();
                        }
                    }

                    //Check images need to be added
                    if (vm.imagesFile != null && vm.imagesFile.Count > 0)
                    {
                        var _images = new List<Image>();
                        foreach (var item in vm.imagesFile)
                        {
                            var image = new Image();
                            image.Name = Path.GetFileNameWithoutExtension(item.FileName) + "_" + DateTime.Now.ToString("ssfff");
                            //save each image & get imageName + extension
                            image.Path = await SaveImage(item, item.FileName);
                            image.Product = product;
                            _images.Add(image);
                        }

                        _context.AddRange(_images);
                        _context.SaveChanges();
                    }

                    _context.SaveChanges();

                    return Ok(new { message = "Update product successfully." });
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (_context.Product.Any(x => x.Id == id))
            {
                var product = _context.Product.SingleOrDefault(x => x.Id == id);
                var sizes = _context.Size.Where(x => x.Product == product);
                var ratings = _context.Rating.Where(x => x.Product == product);
                var images = _context.Image.Where(x => x.Product == product);
                var cartDetails = _context.CartDetail.Where(x => x.Product == product);

                foreach(var img in images)
                {
                    DeleteImage(img.Path);
                }

                _context.RemoveRange(sizes);
                _context.RemoveRange(ratings);
                _context.RemoveRange(images);
                _context.RemoveRange(cartDetails);

                _context.Remove(product);
                _context.SaveChanges();

                return Ok(new { message = "Delete product successfully." });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
