using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<IReadOnlyList<Assignment>> GetAssignments();
        Task<Assignment> GetAssignmentById(int id);
        void Add(Assignment assignment);
        Task<Assignment> Delete(int id);
    }
}