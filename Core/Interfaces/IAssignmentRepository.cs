using Core.Entities;

namespace Core.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<IReadOnlyList<Assignment>> GetAssignments();
        Task<Assignment> GetAssignmentById(int id);
        void Create(Assignment assignment);
        void Delete(Assignment assignment);
        void Update(Assignment assignment);
        Task SaveAsync();
    }
}