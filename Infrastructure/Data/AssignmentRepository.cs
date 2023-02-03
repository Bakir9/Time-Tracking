using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly StoreContext _context;
        
        public AssignmentRepository(StoreContext context)
        {
            _context = context;
        }

       
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Assignment> GetAssignmentById(int id)
        {
            return await _context.Assignments
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Create(Assignment assignment)
        {
             _context.Set<Assignment>().Add(assignment);
        }
      
        public async Task<IReadOnlyList<Assignment>> GetAssignments()
        {
            return await _context.Assignments
                .Include(a => a.User)
                .ToListAsync();
        }

        public void Delete(Assignment assignment)
        {
            _context.Set<Assignment>().Remove(assignment);
        }

        public void Update(Assignment assignment)
        {
            _context.Set<Assignment>().Update(assignment);
        }
    }
}