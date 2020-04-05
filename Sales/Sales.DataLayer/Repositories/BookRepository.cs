using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Sales.DataLayer.Dto;
using Sales.DataLayer.Interfaces;

namespace Sales.DataLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BookDto Get(int bookId)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "Select * from [Book] where Id = @BookId";

            var result = db.Query<BookDto>(sqlQuery, new {BookId = bookId}).FirstOrDefault();

            return result;
        }

        public List<BookDto> GetList()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "Select * from [Book]";

            var result = db.Query<BookDto>(sqlQuery);

            return result.ToList();
        }

        public List<BookDto> GetList(IEnumerable<int> bookIds)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "Select * from [Book] where Id in (@BookIds)";

            var result = db.Query<BookDto>(sqlQuery, new {BookIds = bookIds});

            return result.ToList();
        }

        public void UpdateCopiesNumber(int bookId, int changeValue)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "Update [Book] set CopiesNumber = CopiesNumber + @ChangeValue where Id = @BookId";

            db.Query(sqlQuery, new {BookId = bookId, ChangeValue = changeValue});
        }
    }
}