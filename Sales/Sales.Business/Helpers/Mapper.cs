using Sales.Business.Models;
using Sales.Data.Dto;

namespace Sales.Business.Helpers
{
    public static class Mapper
    {
        public static User Map(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id
            };
        }
    }
}