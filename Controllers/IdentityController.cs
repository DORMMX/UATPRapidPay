using Microsoft.AspNetCore.Mvc;
using DBRepository;
using UATPRapidPay.Commands;
using Services;
using UATPRapidPay.Authentication;

namespace UATPRapidPay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _Configuration;

        public IdentityController(IUserRepository userRepository,
            IConfiguration configuration) 
        { 
            _userRepository = userRepository;
            _Configuration = configuration;
        }

        [HttpPost("authentication")]
        public async Task<ActionResult<IdentityAccess>> Authentication(AppUserLoginCommand command)
        {
            IdentityAccess result = new();
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _userRepository.Authenticate(command.User, command.Password))
                    {
                        result.LimitUpTo = DateTime.UtcNow.AddHours(4);
                        result.AccessToken = TokenGenerator.GenerateToken(command, _Configuration["SecretKey"]);
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest("User name and password don't match.");
                    }
                }
                else 
                {
                    return BadRequest("User name and password don't match.");
                }
            }
            catch (Exception fault)
            {
                return BadRequest(fault.Message);
            }            
        }
    }
}
