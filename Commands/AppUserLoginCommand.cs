using System.ComponentModel.DataAnnotations;

namespace UATPRapidPay.Commands
{
    public class AppUserLoginCommand
    {
        [Required]
        public string User { get; set; }

        [Required]
        public string Password { get; set; }                
    }
}
