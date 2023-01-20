using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using API.DTOS;
using Core.Interfaces;
using Core.Specifications;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly IGenericRepository<Assignment> _assignmentRepo;
        private readonly IAssignmentRepository _assignmentRepository;
      
        public AssignmentsController(StoreContext context, IGenericRepository<Assignment> assignmentRepo, IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
            _assignmentRepo = assignmentRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Assignment>>> GetAssignments()
        {
            var spec = new AssignmentsWithUserSpecification();

            var tasks = await _assignmentRepo.ListAsync(spec);

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