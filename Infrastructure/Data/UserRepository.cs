using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreContext _context;
        public UserRepository(StoreContext context)
        {
            _context = context;
        }
        
        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
             _context.Set<User>().Remove(user);
        }
        
        public async Task<IReadOnlyList<User>> GetUserAssignments()
        {
            return await _context.Users
                .Include(a => a.Assignment)
                .ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(User user)
        {
             _context.Set<User>().Update(user);
        }
    }
}