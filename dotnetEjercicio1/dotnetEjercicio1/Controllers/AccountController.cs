using dotnetEjercicio1.DataAccess;
using dotnetEjercicio1.Helpers;
using dotnetEjercicio1.Models.DataModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetEjercicio1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly JwtSettings _jwtSetting;
        public AccountController(UniversityDBContext context, JwtSettings jwtSetting)
        {
            _context = context;
            _jwtSetting = jwtSetting;
        }

        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "fede@ejemplo.com",
                UserName = "admin",
                Password = "admin"
            },
            new User()
            {
                Id = 2,
                Email = "pepe@ejemplo.com",
                UserName = "User 1",
                Password = "pepe"
            },
        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();
                var Valid = Logins.Any(user => user.UserName.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                if (Valid)
                {
                    var user = Logins.FirstOrDefault(user => user.UserName.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = user.UserName,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid(),

                    }, _jwtSetting);
                }
                else
                {
                    return BadRequest("Wrong Password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }
    }
}
