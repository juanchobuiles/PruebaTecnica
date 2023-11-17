using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        void Add(User entity);
        Task<IEnumerable<User>> GetAllAsync();
        Task<int> Complete();
    }
}
