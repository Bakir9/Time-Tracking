using System.ComponentModel.DataAnnotations;

namespace API.DTOS
{
    public class AssignmentToReturn
    {
        public int Id { get; set; }
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

        public string User { get; set; }
    }
}