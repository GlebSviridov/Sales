using System;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationWebLayer.Helpers;
using Sales.ApplicationWebLayer.Models;
using Sales.BusinessLayer.Interfaces;

namespace Sales.ApplicationWebLayer.Controllers
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
                ViewBag.UserId = user.UserId;
                return RedirectToAction("Index", "MainPage");
            }

            ModelState.AddModelError("Id", "Incorrect Promo Code or Promo Code doesn't exist");
            return View("Index", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterNewPromoCode()
        {
            var userViewModel = Mapper.Map(_userService.CreateUser());
            ViewBag.UserId = userViewModel.UserId;
            TempData["UserId"] = userViewModel.UserId;
            return RedirectToAction("Index", "MainPage");
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