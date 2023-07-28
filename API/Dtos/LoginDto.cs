using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
  public class LoginDto
    {
         [Required(ErrorMessage ="Username is required")]
        [MinLength(5,ErrorMessage ="Username must be at least 5 characters")]
        public string Username {get;set;}
        [Required (ErrorMessage ="Password is required")]
        [MinLength(6, ErrorMessage ="Password must be at least 6 characters")]
        public string Password {get;set;}
    }
}