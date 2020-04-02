using System;
using Sales.Data.Dto;

namespace Sales.Data.Interfaces
{
    public interface IUserRepository
    {
        UserDto Get(Guid userId);
        UserDto Create();
    }
}