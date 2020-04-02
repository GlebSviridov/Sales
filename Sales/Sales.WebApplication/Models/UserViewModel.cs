
using System.ComponentModel.DataAnnotations;

namespace Sales.WebApplication.Models
{
    public class UserViewModel
    {
        [Required]
        public string UserId { get; set; }
    }
}