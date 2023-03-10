using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Assignment : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int AssignedTo {get; set;}

        [Required]
        public int EstimatedTime {get; set;}
        
        public int? ActualTime {get; set;}
        
        public User User { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}