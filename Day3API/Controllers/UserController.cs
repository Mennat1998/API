using Day3API.Data.Models;
using Day3API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Day3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //services used
        public readonly IConfiguration _configuration;
        public readonly UserManager<UsersEntity> _userManager;
        
        public UserController( IConfiguration configuration, UserManager<UsersEntity> userManager)
        {
            _configuration = configuration;
            _userManager =userManager;
           
        }

        // RegisterUser


        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult> RegisterUser(RegisterDto registerDto)
        {
            var user = new UsersEntity
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                UserDepartment = registerDto.UserDepartment
            };
           var CreatePassHash= await _userManager.CreateAsync(user, registerDto.Password);
            if(!CreatePassHash.Succeeded )
            { return BadRequest(CreatePassHash.Errors); }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,"User")
            };

            await _userManager.AddClaimsAsync(user, claims);
            return NoContent();

        }

        //RegisterAdmin


        [HttpPost]
        [Route("RegisterAdmin")]

        public async Task<ActionResult> RegisterAdmin(RegisterDto registerDto)
        {
            var user = new UsersEntity
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                UserDepartment = registerDto.UserDepartment
            };
            var CreatePassHash = await _userManager.CreateAsync(user, registerDto.Password);
            if (!CreatePassHash.Succeeded)
            { return BadRequest(CreatePassHash.Errors); }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,"Admin")
            };
            await _userManager.AddClaimsAsync(user, claims);

            return NoContent();

        }

        //Login


        [HttpPost]
        [Route("Login")]

        public async Task<ActionResult<TokenDto>> Login (LoginDto loginDto)
        {
            UsersEntity? user =await _userManager.FindByNameAsync(loginDto.UserName);
            if(user==null)
            {
                return BadRequest();
            }
            bool UserPasswordCorrect =
                await _userManager.CheckPasswordAsync(user, loginDto.Password);
             if(!UserPasswordCorrect) { return BadRequest(); }

            var ClaimListOfUser = await _userManager.GetClaimsAsync(user);

            // 3 steps to get Secret Key in Bytes
            string KeyString=_configuration.GetValue<String>("SecretKey") ?? string.Empty;
            var KeyStringinBytes= Encoding.ASCII.GetBytes(KeyString);
            var key= new SymmetricSecurityKey(KeyStringinBytes);

            // combine key with hashingAlgoritm

            var signingCredentionals =
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // generate token combine token together

            var expire = DateTime.Now.AddMinutes(60);
            var jwtToken = new JwtSecurityToken
                (
                expires: expire,
                claims: ClaimListOfUser,
                signingCredentials:signingCredentionals
                );

            // convert token to string

            var TokenHandler= new JwtSecurityTokenHandler();
            var token =TokenHandler.WriteToken(jwtToken);

            return new TokenDto
            {
                Token = token,
                TokenExpire = expire
            };

            }
        }
    }

