using System;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Sales.Data.Dto;
using Sales.Data.Interfaces;

namespace Sales.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserDto Get(Guid userId)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var sqlQuery = "Select Top(1) * From [User] WHERE Id = @Id";

            var user = db.Query<UserDto>(sqlQuery, new {Id = userId}).FirstOrDefault();

            return user;
        }

        public UserDto Create()
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var sqlQuery = "insert into [User] output inserted.[Id] values (newid())";

            var user = db.Query<UserDto>(sqlQuery).FirstOrDefault();

            return user;
        }
    }
}