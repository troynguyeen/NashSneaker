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
    }
}
