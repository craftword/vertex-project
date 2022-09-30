using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VertexCore.Models;

namespace VertexCore.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(User model);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetAUserAsync(string Id);
        Task<User> GetAUserByEmailAsync(string email);
    }
}
