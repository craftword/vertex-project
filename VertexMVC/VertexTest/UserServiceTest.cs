using System;
using Xunit;
using Moq;
using VertexCore.Interfaces;
using VertexCore.Services;
using AutoMapper;
using System.Linq;
using VertexCore.ViewModels;
using VertexCore.Models;

namespace VertexTest
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly UserService service;
        private readonly Mock<IMapper> _mapper;
        public UserServiceTest()
        {
            _mockRepo = new Mock<IUserRepository>();
            _mapper = new Mock<IMapper>();
            service = new UserService(_mockRepo.Object, _mapper.Object);
        }


        [Theory]
        [InlineData("2ccd5586-51f2-444c-aa63-e13012748dfa")]
        [InlineData("6c0998e8-f505-49c0-8efc-0d5d90a50152")]
        public void GetAUserAsyncShouldReturnAUserForValidId(string Id)
        {
            var user = Helper.GetListUsers().Where(x => x.Id == Id).SingleOrDefault();
            _mapper.Setup(x => x.Map<UserViewModel>(It.IsAny<User>())).Returns(user);
            

            var actual = service.GetAUserAsync(Id);
            var result = actual.Result;

            Assert.Equal(user.FirstName, result.FirstName);
            Assert.Equal(user.Email, result.Email);

        }

        [Theory]
        [InlineData("2ccd5586-51f2-444c")]
        [InlineData("6c0998e8-f505-49c0")]
        public void GetAUserAsyncShouldReturnNullForInValidId(string Id)
        {
            var user = Helper.GetListUsers().Where(x => x.Id == Id).SingleOrDefault();
            _mapper.Setup(x => x.Map<UserViewModel>(It.IsAny<User>())).Returns(user);

            var userModel = service.GetAUserAsync(Id);
            var result = userModel.Result;

            Assert.Null(result);
            

        }

        [Fact]
        public void RegisterAsyncShouldReturnAStringWhenEmailDoesNotExist()
        {

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Beth",
                LastName = "Meachen",
                Email = "dmeachen3@4shared.com",
                Address = "7 Nobel Ave",
                City = "Arepo",
                Phone = "08027313450",
                Zip = "100234",
                MiddleName = "Dorene",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            RegisterViewModel user1 = new RegisterViewModel()
            {
                FirstName = "Beth",
                LastName = "Meachen",
                Email = "dmeachen3@4shared.com",
                Address = "7 Nobel Ave",
                City = "Arepo",
                Phone = "08027313450",
                Zip = "100234",
                MiddleName = "Dorene",
            };
            _mockRepo.Setup(x => x.GetAUserByEmailAsync(user.Email)).ReturnsAsync(true);
            _mockRepo.Setup(x => x.AddUserAsync(user)).ReturnsAsync(true);

            var userModel = service.RegisterAsync(user1);
            

            Assert.Equal(user.Id, userModel.Result);
            Assert.IsType<string>(userModel.Result);

        }



        [Fact]
        public void RegisterAsyncShouldReturnNullWhenEmailDoesExist()
        {

            RegisterViewModel user1 = new RegisterViewModel()
            {
                FirstName = "Beth",
                LastName = "Meachen",
                Email = "eramsey5@geocities.com",
                Address = "7 Nobel Ave",
                City = "Arepo",
                Phone = "08027313450",
                Zip = "100234",
                MiddleName = "Dorene",
            };
            _mockRepo.Setup(x => x.GetAUserByEmailAsync(user1.Email)).ReturnsAsync(false);
            

            var userModel = service.RegisterAsync(user1);

            Assert.Null(userModel.Result);

        }

    }
}
