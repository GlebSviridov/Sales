using System.Collections.Generic;

namespace Sales.ApplicationWebLayer.Models
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItemViewModel> CartItems { get; set; }

        public ShoppingCartViewModel()
        {
            CartItems = new List<ShoppingCartItemViewModel>();
        }
    }
}