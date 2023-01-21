using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly StoreContext _context;
        public AssignmentRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Assignment> CreateAssignment(Assignment assignment)
        {
            //var task = await GetAssignmentById(assignment.Id);
           
            var newTask = new Assignment(
                assignment.Title,
                assignment.Content,
                assignment.Status,
                assignment.AssignedTo,
                assignment.EstimatedTime,
                assignment.ActualTime,
                assignment.UserId = 1
            );
            await _context.AddAsync(newTask);
            _context.SaveChanges();

            return assignment;
        }

        public Task<Assignment> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Assignment> GetAssignmentById(int id)
        {
            return await _context.Assignments
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IReadOnlyList<Assignment>> GetAssignments()
        {
            return await _context.Assignments
                .Include(a => a.User)
                .ToListAsync();
        }
    }
}