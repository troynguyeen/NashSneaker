﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NashSneaker.Data;
using NashSneaker.Helpers;
using NashSneaker.ViewModel;
using System;
using System.Collections.Generic;
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

        [HttpPost("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleViewModel vm)
        {
            var user = await _userManager.FindByEmailAsync(vm.UserEmail);

            if (vm.Delete)
            {
                await _userManager.RemoveFromRoleAsync(user, vm.Role);
            }
            else
            {
                await _userManager.AddToRoleAsync(user, vm.Role);
            }

            return Ok(vm);
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
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot\\images\\products", _imageName);
            using( var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return _imageName;
        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot\\images\\products", imageName);
            if(System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        [HttpPut("EditProduct/{id}")]
        public async Task<IActionResult> EditProduct([FromForm]AddOrEditProductViewModel vm)
        {
            if (_context.Product.Any(x => x.Id == vm.Id))
            {
                var product = _context.Product.SingleOrDefault(x => x.Id == vm.Id);
                var category = _context.Category.SingleOrDefault(x => x.Id == vm.CategoryId);
                product.Name = vm.Name;
                product.Price = float.Parse(vm.Price);
                product.Description = vm.Description;
                product.UpdatedDate = DateTime.Now;
                product.Category = category;

                //Delete old images
                var images = _context.Image.Where(x => x.Product == product);
                foreach (var img in images)
                {
                    DeleteImage(img.Path);
                }

                _context.RemoveRange(images);
                _context.SaveChanges();

                //Add new images to update
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

                return Ok(new { message = "Update product successfully." });
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

        [HttpGet("Users")]
        public IActionResult Users()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
