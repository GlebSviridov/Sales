using System;
using Microsoft.AspNetCore.Mvc;
using Sales.Business.Interfaces;
using Sales.WebApplication.Helpers;
using Sales.WebApplication.Models;

namespace Sales.WebApplication.Controllers
{
    public class StartPageController : Controller
    {
        private readonly IUserService _userService;

        public StartPageController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InputPromoCode(UserViewModel user)
        {
            var isCorrectUser = CheckUser(user);
            if (isCorrectUser)
            {
                return RedirectToAction("Index", "Home", user);
            }

            ModelState.AddModelError("Id", "Incorrect Promo Code or Promo Code doesn't exist");
            return View("Index", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterNewPromoCode()
        {
            var userViewModel = Mapper.Map(_userService.CreateUser());

            return RedirectToAction("Index", "Home", userViewModel);
        }

        private bool CheckUser(UserViewModel user)
        {
            if (!Guid.TryParse(user.UserId, out var userId))
            {
                return false;
            }

            var hasUserExists = _userService.CheckForExisting(userId);

            return hasUserExists;
        }
    }
}