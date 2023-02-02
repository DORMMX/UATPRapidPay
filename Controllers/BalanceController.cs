using DBRepository;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace UATPRapidPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
