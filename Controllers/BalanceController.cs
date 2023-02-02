using DBRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace UATPRapidPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    public class BalanceController : ControllerBase
    {
        readonly IBalanceRepository _balanceRepository;

        public BalanceController(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        [HttpGet]        
        public ActionResult<Card> Get(string cardNumber)
        {
            return Ok(_balanceRepository.GetBalanceByCard(cardNumber));
        }
    }
}
