using System;
using Sales.Business.Models;

namespace Sales.Business.Interfaces
{
    public interface IUserService
    {
        User GetUser(Guid userId);
        User CreateUser();
        bool CheckForExisting(Guid userId);
    }
}