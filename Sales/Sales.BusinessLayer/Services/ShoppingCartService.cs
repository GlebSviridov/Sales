using System;
using System.Collections.Generic;
using System.Linq;
using Sales.BusinessLayer.Helpers;
using Sales.BusinessLayer.Interfaces;
using Sales.BusinessLayer.Models;
using Sales.DataLayer.Interfaces;

namespace Sales.BusinessLayer.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IBookRepository _bookRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IBookRepository bookRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _bookRepository = bookRepository;
        }

        public List<ShoppingCartItem> GetOrderedBooks(Guid userId)
        {
            var orderedItems = _shoppingCartRepository.GetList(userId);

            return orderedItems.Select(Mapper.Map).ToList();
        }

        public void AddBookToCart(int bookId, Guid userId)
        {

            _shoppingCartRepository.Insert(bookId, userId);
        }

        public void RemoveBookFromCart(int bookId, Guid userId)
        {
            _shoppingCartRepository.Delete(bookId, userId);
        }
    }
}