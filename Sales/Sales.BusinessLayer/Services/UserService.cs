using System;
using Sales.BusinessLayer.Helpers;
using Sales.BusinessLayer.Interfaces;
using Sales.BusinessLayer.Models;
using Sales.DataLayer.Interfaces;

namespace Sales.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(Guid userId)
        {
            var userDto = _userRepository.Get(userId);

            return Mapper.Map(userDto);
        }

        public User CreateUser()
        {
            var userDto = _userRepository.Create();

            return Mapper.Map(userDto);
        }

        public bool CheckForExisting(Guid userId)
        {
            var user = _userRepository.Get(userId);

            return user != null;
        }
    }
}