using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VertexCore.Interfaces;
using VertexCore.ViewModels;
using VertexMVC.Models;

namespace VertexMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterAsync(model);

                if (result != null)
                    return RedirectToAction("Details", result);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {
            var user = await _userService.GetAUserAsync(Id);
            return View();
        }

        
    }
}
