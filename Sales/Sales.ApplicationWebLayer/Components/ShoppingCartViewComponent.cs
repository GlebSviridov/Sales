using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sales.ApplicationWebLayer.Helpers;
using Sales.ApplicationWebLayer.Models;
using Sales.BusinessLayer.Interfaces;

namespace Sales.ApplicationWebLayer.Components
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartViewComponent(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = Guid.Parse(User.Identity.Name);

            var cartItems = GetCartItems(userId);

            return View($"ShoppingCart", cartItems);
        }

        private List<ShoppingCartItemViewModel> GetCartItems(Guid userId)
        {
            var items = _shoppingCartService.GetOrderedBooks(userId).Select(Mapper.Map).ToList();
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Id = i + 1;
            }

            return items;
        }
    }
}