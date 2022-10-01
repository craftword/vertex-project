using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Moq.EntityFrameworkCore;
using VertexCore.Models;
using VertexInfrastrature;
using VertexInfrastrature.Repository;
using Xunit;

namespace VertexTest
{
    public class UserRepositoryTest
    {

        private readonly Mock<AppDbContext> _mockDbContext;
        private readonly UserRepository repo;
        
        public UserRepositoryTest()
        {
            _mockDbContext = new Mock<AppDbContext>();
            repo = new UserRepository(_mockDbContext.Object);
        }

        [Fact]
        public void AddUserAsyncShouldReturnBool()
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
            
            

            var actual = repo.AddUserAsync(user);
            var result = actual.Result;

            Assert.True(result);

        }

        [Fact]
        public void GetAllUserAsyncShouldReturnListOfUsers()
        {
            _mockDbContext.Setup(x => x.Users).ReturnsDbSet(Helper.GetAllUsers());
            var actual = repo.GetAllUsersAsync();
            var result = actual.Result;

            Assert.IsType<List<User>>(result);
            Assert.Equal(Helper.GetAllUsers(), result);
        }


        [Fact]
        public void GetAUserAsyncShouldReturnAUser()
        {
            var Id = "2ccd5586-51f2-444c-aa63-e13012748dfa";
            var user = Helper.GetUser(Id);
            _mockDbContext.Setup(x => x.Users.Where(x => x.Id == Id).SingleOrDefault()).Returns(user);
            var actual = repo.GetAUserAsync(Id);
            var result = actual.Result;

            Assert.IsType<User>(result);
            Assert.Equal(user, result);
        }

        [Fact]
        public void GetAUserAsyncByEmailShouldReturnAUser()
        {
            var email = "hvandijk0@umn.edu";
            var user = Helper.GetUserByEmail(email);
            _mockDbContext.Setup(x => x.Users.Where(x => x.Email == email).SingleOrDefault()).Returns(user);
            var actual = repo.GetAUserByEmailAsync(email);
            var result = actual.Result;

            Assert.IsType<bool>(result);
            Assert.True(result);
        }
    }
}
