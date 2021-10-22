using System.Threading.Tasks;
using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            // Recover the user.
            var user = UserRepository.Get(model.Username, model.Password);
            if (user == null)
            {
                return NotFound(new {message = "Invalid user or password"});
            }

            // Generated token for user.
            var token = TokenService.GenerateToken(user);
            
            //Hide password.
            user.Password = "";
            
            //Return data;
            return new
            {
                user = user,
                token = token
            };
        }
    }
}