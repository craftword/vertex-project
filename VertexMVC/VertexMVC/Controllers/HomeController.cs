using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VertexCore.Interfaces;
using VertexCore.ViewModels;


namespace VertexMVC.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterAsync(model);

                if (result != null)
                {
                    return RedirectToAction("Details", new { Id = result });
                }
                else
                {
                    ModelState.AddModelError("error", "Email Already Exists.");
                    return View(model);
                }   

            }

            ModelState.AddModelError("error", "Make sure your enter all required fields");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {
            var user = await _userService.GetAUserAsync(Id);
            if(user != null)
                return View(user);

            ModelState.AddModelError("error", "User does not Exists.");
            return View();
        }

        
    }
}
