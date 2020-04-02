﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Sales.Business.Interfaces;
using Sales.WebApplication.Models;

namespace Sales.WebApplication.Controllers
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

        public IActionResult Index(BookPageViewModel model)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var user = _userService.GetUser(Guid.Parse("5A570AF4-F889-4139-B516-141FEFE04C95"));
            var createdUser = _userService.CreateUser();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult Logout()
        {
            throw new NotImplementedException();
        }
    }
}