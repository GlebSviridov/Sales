using System;

namespace Sales.BusinessLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string BookIds { get; set; }
        public decimal Price { get; set; }
    }
}