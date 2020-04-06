using System;
using System.Collections.Generic;
using System.Linq;
using Sales.BusinessLayer.Interfaces;
using Sales.DataLayer.Dto;
using Sales.DataLayer.Interfaces;

namespace Sales.BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IBookRepository _bookRepository;

        public OrderService(IUserRepository userRepository, IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _bookRepository = bookRepository;
        }

        public void CreateOrder(Guid userId, string bookIds)
        {
            var order = CompleteOrder(userId, bookIds);

            _orderRepository.Insert(order);

            _shoppingCartRepository.Delete(GetIdsFromString(bookIds), userId);

            _userRepository.Update(userId, true);

        }

        private OrderDto CompleteOrder(Guid userId, string bookIds)
        {
            var books = _bookRepository.GetList(GetIdsFromString(bookIds));
            var price = books.Sum(b => b.Price);
            return new OrderDto
            {
                UserId = userId,
                Price = price,
                BookIds = bookIds
            };
        }

        private List<int> GetIdsFromString(string ids)
        {
            return ids.Split(',').Select(int.Parse).ToList();
        }
    }
}