
using System.ComponentModel.DataAnnotations;

namespace Sales.ApplicationWebLayer.Models
{
    public class UserViewModel
    {
        [Required]
        public string UserId { get; set; }
    }
}