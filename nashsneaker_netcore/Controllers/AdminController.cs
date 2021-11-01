using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NashSneaker.Data;
using NashSneaker.Helpers;
using NashSneaker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly NashSneakerContext _context;
        private readonly JwtService _jwtService;

        public AdminController(
            RoleManager<IdentityRole> roleManager, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            NashSneakerContext context,
            JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _jwtService = jwtService;
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

                    return Ok(new { message = "Edit category successfully." });
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
