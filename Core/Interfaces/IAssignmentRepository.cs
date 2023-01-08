using Core.Entities;

namespace Core.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<IReadOnlyList<Assignment>> GetAssignments();
        Task<Assignment> GetAssignmentById(int id);
        Task<Assignment> CreateOrUpdateAssignment(Assignment assignment, int userId);
        Task<Assignment> Delete(int id);
    }
}