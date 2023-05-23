using System.ComponentModel.DataAnnotations;

namespace AssessmentUser.Models
{
    public class LoginPage
    {
        [Key]
        public string Username { get; set; }

        
        public string Password { get; set; }
    }
}
