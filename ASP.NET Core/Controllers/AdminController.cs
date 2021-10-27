using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NashSneaker.Data;
using NashSneaker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NashSneaker.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly NashSneakerContext _context;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, NashSneakerContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
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
            var user = _context.Users.SingleOrDefault(x => x.Email == vm.Email);
            var userRole = _context.UserRoles.SingleOrDefault(x => x.UserId == user.Id);
            var role = _context.Roles.SingleOrDefault(x => x.Id == userRole.RoleId);

            var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded && role.Name == "Admin")
            {
                return Ok(new { message = "Welcome Admin!" });
            }
            else
            {
                return BadRequest(new { message = "Incorrect Account." });
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Logout succeeded." });
        }
    }
}
