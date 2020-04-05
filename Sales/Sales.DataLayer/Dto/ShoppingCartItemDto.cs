using System;

namespace Sales.DataLayer.Dto
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}