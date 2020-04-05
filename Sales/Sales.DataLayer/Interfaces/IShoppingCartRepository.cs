using System;
using System.Collections.Generic;
using Sales.DataLayer.Dto;

namespace Sales.DataLayer.Interfaces
{
    public interface IShoppingCartRepository
    {
        public List<ShoppingCartItemDto> GetList(Guid userId);
        void Insert(int bookId, Guid userId);
        void Delete(int bookId, Guid userId);
    }
}