using System.ComponentModel.DataAnnotations;

namespace SendEmail.Models
{
    public class Email
    {
        [Required(ErrorMessage = "Is Required")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Is Required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Is Required")]
        public string Message { get; set; }
    }
}
