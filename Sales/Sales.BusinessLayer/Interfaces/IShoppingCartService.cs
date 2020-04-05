using System;
using System.Collections.Generic;
using Sales.BusinessLayer.Models;

namespace Sales.BusinessLayer.Interfaces
{
    public interface IShoppingCartService
    {
        List<ShoppingCartItem> GetOrderedBooks(Guid userId);
        void AddBookToCart(int bookId, Guid userId);
        void RemoveBookFromCart(int bookId, Guid userId);
    }
}