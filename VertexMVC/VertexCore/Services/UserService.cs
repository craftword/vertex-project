using System;
using System.Threading.Tasks;
using VertexCore.Interfaces;
using VertexCore.Models;
using VertexCore.ViewModels;

namespace VertexCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserViewModel> GetAUserAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Email = model.Email,
                Address = model.Address,
                Phone = model.Phone,
                City = model.City,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now

            };
            var result = await _userRepository.AddUserAsync(user);


            return result;

            
        }
    }
}
