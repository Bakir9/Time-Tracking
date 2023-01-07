using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using API.DTOS;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly IAssignmentRepository _assignmentRepository;
      
        public AssignmentsController(StoreContext context, IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Assignment>>> GetAssignments()
        {
            var tasks = await _context.Assignments.ToListAsync();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            return await _context.Assignments.FindAsync(id);   
        }

        [HttpPost("create")]
        public async Task<ActionResult<AssignmentDto>> SetAssignment(Assignment assignment)
        {
            var assig = new AssignmentDto
            {
                Title = assignment.Title,
                Content = assignment.Content
            };

             _assignmentRepository.Add(assignment);

            return Ok(assig); 
        }
    }
}