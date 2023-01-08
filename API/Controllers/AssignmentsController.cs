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
      
        public AssignmentsController(StoreContext context, IAssignmentRepository assignmentRepository )
        {
            _assignmentRepository = assignmentRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Assignment>>> GetAssignments()
        {
            var tasks = await _assignmentRepository.GetAssignments();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            return await _context.Assignments
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Assignment>> SetAssignmentAsync(Assignment assignment)
        {
            var result = await _assignmentRepository.CreateOrUpdateAssignment(assignment,1);

            return result;
        }
    }
}