using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VertexCore.Interfaces;
using VertexCore.Models;
using VertexCore.ViewModels;
using VertexMVC.Controllers;
using Xunit;

namespace VertexTest
{
    public class CreateControllerTest
    {
        private readonly Mock<IUserService> _mockRepo;
        private readonly HomeController _controller;
        public CreateControllerTest()
        {
            _mockRepo = new Mock<IUserService>();
            _controller = new HomeController(_mockRepo.Object);
            
        }


        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public void IndexGetShouldHaveNoViewModel()
        {
            
            var result = _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.Null(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task CreatePostShouldReturnCreateViewModelIfModelIsInvalid()
        {
            var model = new RegisterViewModel();
            _controller.ModelState.AddModelError("error", "Make sure your enter all required fields");

            var result = await _controller.Index(model);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<RegisterViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task IndexPostShouldReturnRedirectToActionDetailsIfModelIsValid()
        {
           

            var user = new RegisterViewModel
            {
                FirstName = "Beth",
                LastName = "Meachen",
                Email = "dmeachen3@4shared.com",
                Address = "7 Nobel Ave",
                City = "Arepo",
                Phone = "08027313450",
                Zip = "100234",
                MiddleName = "Dorene"
            };


            _mockRepo.Setup(x => x.RegisterAsync(user)).ReturnsAsync("3fcff486-718b-4050-bd19-c3115e25d0e7");

            var result = await _controller.Index(user);

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            
            Assert.Equal("Details", redirectResult.ActionName);
           
        }

        

        [Fact]
        public async Task IndexPostShouldCallRegisterAsyncWithCorrectParameterIfModelIsValid()
        {
            var user = new RegisterViewModel
            {
                FirstName = "Beth",
                LastName = "Meachen",
                Email = "dmeachen3@4shared.com",
                Address = "7 Nobel Ave",
                City = "Arepo",
                Phone = "08027313450",
                Zip = "100234",
                MiddleName = "Dorene"
            };

            await _controller.Index(user);

            _mockRepo.Verify(mock => mock.RegisterAsync(user), Times.Once);
        }


        [Fact]
        public async Task DetailsGetShouldReturnAUserWithValidId()
        {
            var user = Helper.GetAUser("2ccd5586-51f2-444c-aa63-e13012748dfa");
            
            _mockRepo.Setup(x => x.GetAUserAsync("2ccd5586-51f2-444c-aa63-e13012748dfa")).ReturnsAsync(user);


            var result = await _controller.Details("2ccd5586-51f2-444c-aa63-e13012748dfa");

            var viewResult = Assert.IsType<ViewResult>(result);
            var actual = Assert.IsType<UserViewModel>(viewResult.Model);
            //var model = Assert.IsAssignableFrom<UserViewModel>(viewResult.ViewData.Model);
            Assert.Equal("bimbo", actual.FirstName);
            Assert.Equal("hvandijk0@umn.edu", actual.Email);
        }


        [Fact]
        public async Task DetailsGetShouldReturnANullWithInValidId()
        {
            var user = Helper.GetAUser("2ccd5586-51f2-444c");
            _mockRepo.Setup(x => x.GetAUserAsync("2ccd5586-51f2-444c")).ReturnsAsync(user);


            var result = await _controller.Details("2ccd5586-51f2-444c-aa63-e13012748dfa");

            var viewResult = Assert.IsType<ViewResult>(result);
           
            Assert.Null(viewResult.Model);
        }
    }
}

