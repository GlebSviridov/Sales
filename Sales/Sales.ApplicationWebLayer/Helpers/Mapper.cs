using Sales.ApplicationWebLayer.Models;
using Sales.BusinessLayer.Models;

namespace Sales.ApplicationWebLayer.Helpers
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