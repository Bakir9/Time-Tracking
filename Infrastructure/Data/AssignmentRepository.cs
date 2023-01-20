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

        public async Task<Assignment> CreateOrUpdateAssignment(Assignment assignment, int userId)
        {
            var assig = await GetAssignmentById(assignment.Id);
            
            await _context.AddAsync(assignment);

            return assignment;
        }

        public Task<Assignment> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Assignment> GetAssignmentById(int id)
        {
            return await _context.Assignments
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IReadOnlyList<Assignment>> GetAssignments()
        {
            return await _context.Assignments
                .Include(u => u.User)
                .ToListAsync();
        }
    }
}