using Sales.DataLayer.Dto;

namespace Sales.DataLayer.Interfaces
{
    public interface IOrderRepository
    {
        void Insert(OrderDto order);
    }
}