using dotnetEjercicio1.DataAccess;
using dotnetEjercicio1.Helpers;
using dotnetEjercicio1.Models.DataModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetEjercicio1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly JwtSettings _jwtSetting;
        private readonly ILoggerFactory _loggerFactory;

        public AccountController(UniversityDBContext context, JwtSettings jwtSetting, ILoggerFactory loggerFactory)
        {
            _context = context;
            _jwtSetting = jwtSetting;
            _loggerFactory = loggerFactory;
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

                var searchUser = (from user in Logins
                                  where user.UserName == userLogin.UserName && user.Password == userLogin.Password
                                  select user).FirstOrDefault();

                //var Valid = Logins.Any(user => user.UserName.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                if (searchUser != null)
                {
                    //var user = Logins.FirstOrDefault(user => user.UserName.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.UserName,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
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
