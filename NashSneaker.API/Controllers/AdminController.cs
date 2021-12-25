using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using NashSneaker.API;
using NashSneaker.BlobServices;
using NashSneaker.Data;
using NashSneaker.Data.ViewModel;
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
        private readonly IBlobService _blobService;

        public AdminController(
            RoleManager<IdentityRole> roleManager, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            NashSneakerContext context,
            JwtService jwtService,
            IBlobService blobService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _jwtService = jwtService;
            _blobService = blobService;
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
                listUserVM.Add(userVM);
            }

            return Ok(listUserVM);
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var roles = _context.Roles.ToList();
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

                //Check this category was assigned to any products
                if (_context.Product.Any(x => x.Category == category))
                {
                    return BadRequest();
                }

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
        public async Task<IActionResult> Products()
        {
            var products = _context.Product.ToList();
            var categories = _context.Category.ToList();
            var images = _context.Image.ToList();

            // This for getting images from Azure Blob Storage
            foreach(var item in images)
            {
                //item.Path = await _blobService.GetBlob(item.Path, "images");
                // For localhost
                item.Path = "https://localhost:44357/images/products/" + item.Path;
            }

            foreach(var item in categories)
            {
                item.Products = new List<Product>();
            }

            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (_context.Product.Any(x => x.Id == id))
            {
                var product = _context.Product.SingleOrDefault(x => x.Id == id);
                var categories = _context.Category.ToList();
                var images = _context.Image.Where(x => x.Product == product).ToList();

                // This for getting images from the container of Blob Storage
                foreach (var item in images)
                {
                    //item.Path = await _blobService.GetBlob(item.Path, "images");
                    // For localhost
                    item.Path = "https://localhost:44357/images/products/" + item.Path;
                }

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
                    image.Name = Path.GetFileNameWithoutExtension(item.FileName) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                    image.Path = Path.GetFileNameWithoutExtension(item.FileName) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + Path.GetExtension(item.FileName);
                    //save each image & get imageName + extension
                    image.Path = await SaveImage(item, item.FileName);

                    // This for uploading the image into the container of Blob Storage
                    //await _blobService.UploadBlob(image.Path, item, "images");

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
            string _imageName = Path.GetFileNameWithoutExtension(imageName) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + Path.GetExtension(imageName);
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

                            // This for deleting the image from the container of Blob Storage
                            //await _blobService.DeleteBlob(item, "images");

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
                            image.Name = Path.GetFileNameWithoutExtension(item.FileName) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                            image.Path = Path.GetFileNameWithoutExtension(item.FileName) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + Path.GetExtension(item.FileName);
                            //save each image & get imageName + extension
                            image.Path = await SaveImage(item, item.FileName);

                            // This for uploading the image into the container of Blob Storage
                            //await _blobService.UploadBlob(image.Path, item, "images");
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
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Product.Any(x => x.Id == id))
            {
                var product = _context.Product.SingleOrDefault(x => x.Id == id);

                //Check this product exist in orders
                if(_context.OrderDetail.Any(x => x.Product == product))
                {
                    return BadRequest();
                }

                var sizes = _context.Size.Where(x => x.Product == product);
                var ratings = _context.Rating.Where(x => x.Product == product);
                var images = _context.Image.Where(x => x.Product == product);
                var cartDetails = _context.CartDetail.Where(x => x.Product == product).ToList();
                var carts = _context.Cart.ToList();

                foreach (var img in images)
                {
                    DeleteImage(img.Path);

                    // This for deleting the image from the container of Blob Storage
                    //await _blobService.DeleteBlob(img.Path, "images");
                }

                _context.RemoveRange(sizes);
                _context.RemoveRange(ratings);
                _context.RemoveRange(images);
                _context.RemoveRange(cartDetails);

                _context.Remove(product);
                _context.SaveChanges();

                // Check if cart be null it will be deleted
                foreach (var item in cartDetails)
                {
                    var cart = _context.Cart.SingleOrDefault(x => x.Id == item.Cart.Id);
                    if(!_context.CartDetail.Any(x => x.Cart == cart) && cart != null)
                    {
                        _context.Remove(cart);
                        _context.SaveChanges();
                    }
                }

                return Ok(new { message = "Delete product successfully." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Orders")]
        public IActionResult Orders()
        {
            var users = _context.Users.ToList();
            var orders = _context.Order.ToList();
            var orderDetails = _context.OrderDetail.ToList();

            return Ok(orders);
        }

        [HttpPut("EditOrder")]
        public IActionResult EditOrder(EditOrderViewModel vm)
        {
            if (_context.Order.Any(x => x.Id == vm.Id))
            {
                var order = _context.Order.SingleOrDefault(x => x.Id == vm.Id);
                order.RecipientName = vm.RecipientName;
                order.PhoneNumber = vm.PhoneNumber;
                order.Address = vm.Address;
                order.PaymentMethod = vm.PaymentMethod;
                order.Status = vm.Status;

                _context.SaveChanges();

                return Ok(new { message = "Edit order successfully." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            if (_context.Order.Any(x => x.Id == id))
            {
                var order = _context.Order.SingleOrDefault(x => x.Id == id);
                var orderDetails = _context.OrderDetail.Where(x => x.Order == order);

                _context.RemoveRange(orderDetails);
                _context.Remove(order);
                _context.SaveChanges();

                return Ok(new { message = "Delete order successfully." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            if(_context.Order.Any(x => x.Id == id))
            {
                var users = _context.Users.ToList();
                var order = _context.Order.SingleOrDefault(x => x.Id == id);
                var orderDetails = _context.OrderDetail.Where(x => x.Order == order).ToList();
                var products = _context.Product.ToList();
                var categories = _context.Category.ToList();
                var images = _context.Image.ToList();

                // This for getting images from Azure Blob Storage
                foreach (var item in images)
                {
                    //item.Path = await _blobService.GetBlob(item.Path, "images");
                    // For localhost
                    item.Path = "https://localhost:44357/images/products/" + item.Path;
                }

                foreach (var item in categories)
                {
                    item.Products = new List<Product>();
                }

                return Ok(order);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("EditProductFromOrderDetail")]
        public IActionResult EditProductFromOrderDetail(EditProductFromOrderDetailViewModel vm)
        {
            if (_context.OrderDetail.Any(x => x.Id == vm.orderDetailId))
            {
                var products = _context.Product.ToList();
                var orders = _context.Order.ToList();
                var orderDetail = _context.OrderDetail.SingleOrDefault(x => x.Id == vm.orderDetailId);
                orderDetail.Quantity = vm.quantity;

                _context.SaveChanges();

                //Update totalAmount for Order
                int totalAmount = 0;
                var order = _context.Order.SingleOrDefault(x => x.Id == orderDetail.Order.Id);
                var orderDetails = _context.OrderDetail.Where(x => x.Order == order).ToList();

                foreach(var item in orderDetails)
                {
                    totalAmount += (int) item.Product.Price * item.Quantity;
                }

                order.TotalAmount = totalAmount;
                _context.SaveChanges();

                return Ok(new { message = "Edit Product from Order Detail successfully." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteProductFromOrderDetail/{id}")]
        public IActionResult DeleteProductFromOrderDetail(int id)
        {
            if (_context.OrderDetail.Any(x => x.Id == id))
            {
                var products = _context.Product.ToList();
                var orders = _context.Order.ToList();
                var orderDetail = _context.OrderDetail.SingleOrDefault(x => x.Id == id);
                var OrderId = orderDetail.Order.Id;

                _context.Remove(orderDetail);
                _context.SaveChanges();

                //Update totalAmount for Order
                int totalAmount = 0;
                var order = _context.Order.SingleOrDefault(x => x.Id == OrderId);
                var orderDetails = _context.OrderDetail.Where(x => x.Order == order).ToList();

                foreach (var item in orderDetails)
                {
                    totalAmount += (int)item.Product.Price * item.Quantity;
                }

                order.TotalAmount = totalAmount;
                _context.SaveChanges();

                return Ok(new { message = "Delete Product from Order Detail successfully." });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
