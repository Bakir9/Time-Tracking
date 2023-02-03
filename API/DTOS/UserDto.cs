using System.ComponentModel.DataAnnotations;

namespace API.DTOS
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string RegisteredAt {get; set;}

        public string LastLogin {get; set;}
    }
}