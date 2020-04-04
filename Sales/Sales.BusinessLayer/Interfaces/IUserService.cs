using System;
using Sales.BusinessLayer.Models;

namespace Sales.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        User GetUser(Guid userId);
        User CreateUser();
        bool CheckForExisting(Guid userId);
    }
}