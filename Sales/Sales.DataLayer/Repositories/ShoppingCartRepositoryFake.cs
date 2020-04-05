using System;
using System.Collections.Generic;
using System.Linq;
using Sales.DataLayer.Dto;
using Sales.DataLayer.Interfaces;

namespace Sales.DataLayer.Repositories
{
    public class ShoppingCartRepositoryFake : IShoppingCartRepository
    {
        public List<ShoppingCartItemDto> GetList(Guid userId)
        {
            return new List<ShoppingCartItemDto>
            {
                new ShoppingCartItemDto
                {
                    Id = 1,
                    BookId = 1,
                    UserId = Guid.Parse("67B0A44C-0FBD-470E-AAC7-02867E5FE475"),
                    Title = "Тонкое искусство пофигизма: Парадоксальный способ жить счастливо",
                    Price = 320
                },
                new ShoppingCartItemDto
                {
                    Id = 2,
                    BookId = 3,
                    UserId = Guid.Parse("67B0A44C-0FBD-470E-AAC7-02867E5FE475"),
                    Title = "Лисья нора",
                    Price = 301
                },
                new ShoppingCartItemDto
                {
                    Id = 3,
                    BookId = 2,
                    UserId = Guid.Parse("DEBC10BC-362A-4652-A37C-0B76C72361DE"),
                    Title = "Пиши, сокращай: Как создавать сильный текст",
                    Price = 458
                }
            }.Where(i => i.UserId == userId).ToList();
        }

        public void Insert(int bookId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int bookId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}