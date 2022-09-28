using JWT.Web.Api.Constants;
using JWT.Web.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        public UserController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult GetCurrentUsers()
        {
            var useCurrent = GetCurrentUser();
            return Ok();
        }
        [HttpPost]
        public IActionResult Login(LoginUser loginUser)
        {
            var user = Authenticate(loginUser);
            if (user != null)
            {
                //crear token 
                var token = Generate(user);
                return Ok($"TOKEN: {token}");
            }
            return NotFound("Usuario no encontrodo");
        }


        private UserModel Authenticate( LoginUser loginUser)
        {
            var currentUser = UserContanst.Users.FirstOrDefault(x=> x.UserName.ToLower() == loginUser.UserName.ToLower() && x.Password ==  loginUser.Password);
           
            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
        private string Generate(UserModel user)
        {
            var sevurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(sevurityKey, SecurityAlgorithms.HmacSha256);
            //Crear claims
            var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserName),
                        new Claim(ClaimTypes.Email,user.EmailAddress),
                        new Claim(ClaimTypes.GivenName,user.UserName),
                        new Claim(ClaimTypes.Surname,user.UserName),
                        new Claim(ClaimTypes.Role,user.Rol),

                    };

            var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    UserName = userClaims.FirstOrDefault(o=> o.Type == ClaimTypes.NameIdentifier)?.Value
                };
            }
            return null;
        }

    }
}
