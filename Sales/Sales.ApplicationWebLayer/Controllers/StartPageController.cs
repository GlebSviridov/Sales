using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        public async Task<IActionResult> InputPromoCode(UserViewModel user)
        {
            var isCorrectUser = CheckUser(user);
            if (isCorrectUser)
            {
                await AuthenticateUser(user.UserId);
                return RedirectToAction("Index", "MainPage");
            }

            ModelState.AddModelError("Id", "Incorrect Promo Code or Promo Code doesn't exist");
            return View("Index", user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterNewPromoCode()
        {
            var userViewModel = Mapper.Map(_userService.CreateUser());

            await AuthenticateUser(userViewModel.UserId);
            return RedirectToAction("Index", "MainPage");
        }

        private bool CheckUser(UserViewModel user)
        {
            if (!Guid.TryParse(user.UserId, out var userId))
            {
                return false;
            }

            var storedUser = Mapper.Map(_userService.GetUser(userId));
            var hasUserExists = storedUser != null;

            if (!hasUserExists)
            {
                return false;
            }

            return !storedUser.HasUsed;
        }

        private async Task AuthenticateUser(string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userId)
            };

            var claimsIdentity = new ClaimsIdentity(claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }
    }
}