using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using API.DTOS;
using Core.Interfaces;
using Core.Specifications;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IGenericRepository<Assignment> _assignmentRepo;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;
      
        public AssignmentsController(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _assignmentRepository = assignmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Assignment>>> GetAssignments()
        {
            var spec = new AssignmentsWithUserSpecification();

            var tasks = await _assignmentRepository.GetAssignments();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            return await _assignmentRepository.GetAssignmentById(id);
        }

        [HttpPost("create")]
        public async Task<ActionResult<AssignmentToReturn>> SetAssignmentAsync(Assignment assignment)
        {
            _assignmentRepository.Create(assignment);
            await _assignmentRepository.SaveAsync();
            
            var newAssignment = await _assignmentRepository.GetAssignmentById(assignment.Id);
            var data =  _mapper.Map<Assignment, AssignmentToReturn>(newAssignment);
            
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AssignmentToReturn>> DeleteAssignment(int id)
        {
            var deletedAssignment = await _assignmentRepository.GetAssignmentById(id);

            if(deletedAssignment == null)
            {
                return NotFound();
            }

            _assignmentRepository.Delete(deletedAssignment);
            await _assignmentRepository.SaveAsync();

            return Ok(_mapper.Map<Assignment, AssignmentToReturn>(deletedAssignment));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AssignmentToReturn>> UpdateAssignment(int id, [FromBody]Assignment assignment)
        {
            if(assignment == null)
            {
                return NotFound();
            }

            _assignmentRepository.Update(assignment);
            await _assignmentRepository.SaveAsync();

            var updatedAssignment = await _assignmentRepository.GetAssignmentById(id);

            return Ok(_mapper.Map<Assignment, AssignmentToReturn>(updatedAssignment));
        }
    }
}