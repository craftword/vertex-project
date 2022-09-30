using System;
using System.Threading.Tasks;
using AutoMapper;
using VertexCore.Interfaces;
using VertexCore.Models;
using VertexCore.ViewModels;

namespace VertexCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> GetAUserAsync(string Id)
        {
            var user = await _userRepository.GetAUserAsync(Id);

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<string> RegisterAsync(RegisterViewModel model)
        {
            var checkUser = await _userRepository.GetAUserByEmailAsync(model.Email);

            if(checkUser == null)
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
                    Zip = model.Zip,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now

                };
                var result = await _userRepository.AddUserAsync(user);

                if (result)
                    return user.Id;
            }
            

            return null;
        }
    }
}
