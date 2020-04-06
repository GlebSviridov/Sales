﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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

        public MainPageController(IBookService bookService, IShoppingCartService shoppingCartService)
        {
            _bookService = bookService;
            _shoppingCartService = shoppingCartService;
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

        public IActionResult MakeOrder(List<int> bookIds)
        {
            throw new NotImplementedException();
        }
    }
}