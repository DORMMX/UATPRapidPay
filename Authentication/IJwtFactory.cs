using DBRepository;
using System.Security.Claims;

namespace UATPRapidPay.Authentication
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(User user, string id);
    }
}
