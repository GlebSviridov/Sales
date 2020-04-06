using System;

namespace Sales.BusinessLayer.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(Guid userId, string bookIds);
    }
}