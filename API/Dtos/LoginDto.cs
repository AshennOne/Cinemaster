using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
  public class LoginDto
    {
         [Required(ErrorMessage ="Username is required")]
        [MinLength(4,ErrorMessage ="Username must be at least 4 characters")]
        public string Username {get;set;}
        [Required (ErrorMessage ="Password is required")]
        [MinLength(6, ErrorMessage ="Password must be at least 6 characters")]
        public string Password {get;set;}
    }
}