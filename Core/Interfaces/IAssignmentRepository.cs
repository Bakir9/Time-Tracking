using Core.Entities;

namespace Core.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<IReadOnlyList<Assignment>> GetAssignments();
        Task<Assignment> GetAssignmentById(int id);
        Task<Assignment> CreateAssignment(Assignment assignment);
        Task<Assignment> Delete(int id);
    }
}