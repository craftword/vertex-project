using System;
using System.Threading.Tasks;
using VertexCore.ViewModels;

namespace VertexCore.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterViewModel model);
        Task<UserViewModel> GetAUserAsync(string Id);
    }
}
