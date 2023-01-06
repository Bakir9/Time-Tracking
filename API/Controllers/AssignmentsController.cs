using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly StoreContext _context;
        public AssignmentsController(StoreContext context	)
        {
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
    }
}