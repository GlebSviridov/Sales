using Sales.Business.Models;
using Sales.WebApplication.Models;

namespace Sales.WebApplication.Helpers
{
    public static class Mapper
    {
        public static UserViewModel Map(User user)
        {
            return new UserViewModel
            {
                UserId = user.Id.ToString()
            };
        }
    }
}