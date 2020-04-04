using System;
using Sales.DataLayer.Dto;

namespace Sales.DataLayer.Interfaces
{
    public interface IUserRepository
    {
        UserDto Get(Guid userId);
        UserDto Create();
    }
}