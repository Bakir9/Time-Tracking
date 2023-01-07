using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.DTOS
{
    public class AssignmentDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}