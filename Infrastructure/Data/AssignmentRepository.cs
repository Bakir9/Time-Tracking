using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly StoreContext _context;
        public AssignmentRepository(StoreContext context)
        {
            _context = context;
        }

        public void  Add(Assignment assignment)
        {
            var result =  _context.Set<Assignment>().Add(assignment);
        }

        public Task<Assignment> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Assignment> GetAssignmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Assignment>> GetAssignments()
        {
            throw new NotImplementedException();
        }
    }
}