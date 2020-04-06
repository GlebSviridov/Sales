using System;

namespace Sales.DataLayer.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string BookIds { get; set; }
        public decimal Price { get; set; }
    }
}