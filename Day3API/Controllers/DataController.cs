using Day3API.Data.Models;
using Day3API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public readonly UserManager<UsersEntity> _userManager;

        public DataController(UserManager<UsersEntity> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [Route("GetInfo")]
        public async Task<ActionResult> GetUserInfo(LoginDto loginDto)
        {
            // two ways to get user info
            //1
            /* var userId= User.FindFirstValue(ClaimTypes.NameIdentifier);
             var user = await _userManager.FindByIdAsync(userId);
            */
            //2
            var user = await _userManager.GetUserAsync(User);
            return Ok(new string[] {
            user!.UserName!,
            user!.Email!,
            user!.UserDepartment!
            });
           
        }

        [HttpGet]
        [Authorize(policy:"Admins")]
        [Route("GetInfoForManager")]
        public ActionResult GetInfoForManager()
        {
            return Ok( "Info For Manager" );
        }

        [HttpGet]
        [Authorize(policy:"Admins_Users")]
        [Route("GetInfoForuser")]
        public ActionResult GetInfoForuser() 
        {
            return Ok("Info For User");
        }
        
    }
}
