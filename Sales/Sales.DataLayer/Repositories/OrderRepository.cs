using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Sales.DataLayer.Dto;
using Sales.DataLayer.Interfaces;

namespace Sales.DataLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Insert(OrderDto order)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "Insert into [Order] values(@userId, @bookIds, @price)";

            var result = db.Query(sqlQuery, new {userId = order.UserId, bookIds = order.BookIds, price = order.Price});
        }
    }
}