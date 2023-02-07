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
    public class CardController : ControllerBase
    {
        readonly ICardRepository _cardRepository;

        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet]        
        public ActionResult<List<Card>> Get()
        {
            return Ok(_cardRepository.GetCards());
        }

        [HttpPost]        
        public ActionResult<Card> Post(Card card)
        {
            if (_cardRepository.CreateCards(card))
                return Ok(card);
            return BadRequest();
        }
    }
}