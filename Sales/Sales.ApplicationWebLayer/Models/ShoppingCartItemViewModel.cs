﻿namespace Sales.ApplicationWebLayer.Models
{
    public class ShoppingCartItemViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public decimal BookPrice { get; set; }
    }
}