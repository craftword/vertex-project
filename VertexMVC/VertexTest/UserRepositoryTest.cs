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
    public class UserRepositoryTest : InMemoryTestBase
    {   
        private UserRepository _repo;

        protected override void Reset()
        {
            _repo = new UserRepository(DbContext);
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
            
            var actual = _repo.AddUserAsync(user);
            var result = actual.Result;

            Assert.True(result);

        }



        [Fact]
        public void GetAllUserAsyncShouldReturnListOfUsers()
        { 
            var actual = _repo.GetAllUsersAsync();
            var result = actual.Result;

            Assert.IsType<List<User>>(result);
            Assert.Equal(Helper.GetAllUsers().Count, result.Count());
        }


        [Fact]
        public void GetAUserAsyncShouldReturnAUser()
        {
            var Id = "2ccd5586-51f2-444c-aa63-e13012748dfa";
            var user = Helper.GetUser(Id);
            var actual = _repo.GetAUserAsync(Id);
            var result = actual.Result;

            Assert.IsType<User>(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.FirstName, result.FirstName);
            Assert.Equal(user.Email, result.Email);
        }

        [Fact]
        public void GetAUserAsyncByEmailShouldReturnAUser()
        {
            var email = "hvandijk0@umn.edu";
            var actual = _repo.GetAUserByEmailAsync(email);
            var result = actual.Result;

            Assert.IsType<bool>(result);
            Assert.True(result);
        }
    }
}
