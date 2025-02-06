
using backend.Models;

namespace backend.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User?> UpdateUserAsync(int id, User updatedUser);
        Task<bool> DeleteUserAsync(int id);
    }
}
