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
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly NashSneakerContext _context;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, NashSneakerContext context)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._context = context;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(Role role)
        {
            var roleExist = await _roleManager.RoleExistsAsync(role.RoleName);
            if(!roleExist)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(role.RoleName));

                return Ok(result);
            }
            else
            {
                return BadRequest("The role name had exist!");
            }
        }

        [HttpPost("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleViewModel userViewModel)
        {
            var user = await _userManager.FindByEmailAsync(userViewModel.UserEmail);

            if (userViewModel.Delete)
            {
                await _userManager.RemoveFromRoleAsync(user, userViewModel.Role);
            }
            else
            {
                await _userManager.AddToRoleAsync(user, userViewModel.Role);
            }

            return Ok(userViewModel);
        }
    }
}
