using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
  public class RegisterDto
    {
        [Required(ErrorMessage ="Username is required")]
        [MinLength(5,ErrorMessage ="Username must be at least 5 characters")]
        public string Username {get;set;}
        [Required (ErrorMessage ="Email is required")]
        [EmailAddress (ErrorMessage="Please enter correct email address")]
        public string Email {get;set;}
        [Required (ErrorMessage ="Password is required")]
        [MinLength(6, ErrorMessage ="Password must be at least 6 characters")]
        public string Password {get;set;}
    }
}