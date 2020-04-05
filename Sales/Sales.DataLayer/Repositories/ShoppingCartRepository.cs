using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Sales.DataLayer.Dto;
using Sales.DataLayer.Interfaces;

namespace Sales.DataLayer.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly string _connectionString;

        public ShoppingCartRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ShoppingCartItemDto> GetList(Guid userId)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var sqlQuery =
                "Select sp.Id, sp.UserId, sp.BookId, b.Title, b.Price  From [ShoppingCart] sp join [Book] b on b.Id = sp.BookId  WHERE sp.UserId = @userId";

            var shoppingCartItems = db.Query<ShoppingCartItemDto>(sqlQuery, new {userId = userId}).ToList();

            return shoppingCartItems;
        }

        public void Insert(int bookId, Guid userId)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var sqlQuery = "Insert into [ShoppingCart] values(@bookId, @userId)";

            db.Query(sqlQuery, new {userId = userId, bookId = bookId});
        }

        public void Delete(int bookId, Guid userId)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var sqlQuery = "Delete FROM [ShoppingCart] where BookId = @bookId and UserId = @userId";

            db.Query(sqlQuery, new {bookId = bookId, userId = userId});
        }
    }
}