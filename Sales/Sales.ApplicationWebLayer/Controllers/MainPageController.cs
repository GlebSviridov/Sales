using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationWebLayer.Helpers;
using Sales.ApplicationWebLayer.Models;
using Sales.BusinessLayer.Interfaces;

namespace Sales.ApplicationWebLayer.Controllers
{
    [Authorize]
    public class MainPageController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;

        public MainPageController(IBookService bookService, IShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _bookService = bookService;
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var userId = User.Identity.Name;
            ViewData["UserId"] = userId;

            var orderedItems = GetOrderedBooks(userId);

            return View(orderedItems);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddToCart(int bookId)
        {
            var userId = Guid.Parse(User.Identity.Name);

            _bookService.DecrementCopiesNumber(bookId);
            _shoppingCartService.AddBookToCart(bookId, userId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int bookId)
        {
            var userId = Guid.Parse(User.Identity.Name);

            _bookService.IncrementCopiesNumber(bookId);
            _shoppingCartService.RemoveBookFromCart(bookId, userId);

            return RedirectToAction("Index");
        }

        private List<BookViewModel> GetOrderedBooks(string userId)
        {
            var orderedItems = _shoppingCartService.GetOrderedBooks(Guid.Parse(userId));
            var books = _bookService.GetAllBooks().Select(Mapper.Map).ToList();

            foreach (var orderedBook in orderedItems)
            {
                books.First(b => b.Id == orderedBook.BookId).HasAlreadyInCart = true;
            }

            return books;
        }

        [HttpPost]
        public IActionResult MakeOrder(string orderedBookIds)
        {
            var userId = Guid.Parse(User.Identity.Name);

            _orderService.CreateOrder(userId, orderedBookIds);

            HttpContext.SignOutAsync();

            return RedirectToAction("Index", "StartPage");
        }
    }
}