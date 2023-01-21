using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class User : BaseEntity
    {
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

        [JsonIgnore]
        public virtual ICollection<Assignment> Assignments { get; set; }

    }
}