using DBRepository;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace UATPRapidPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayController : ControllerBase
    {
        readonly ITransactionRepositoy _transactionRepositoy;

        public PayController(ITransactionRepositoy transactionRepositoy)
        {
            _transactionRepositoy = transactionRepositoy;
        }

        [HttpPost]        
        public ActionResult<Transaction> Post(Transaction transaction)
        {
            if (_transactionRepositoy.CreateTransaction(transaction))
                return Ok(transaction);
            return BadRequest();
        }
    }
}