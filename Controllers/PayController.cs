using DBRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace UATPRapidPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            return Ok(_transactionRepositoy.CreateTransaction(transaction));
            
        }
    }
}