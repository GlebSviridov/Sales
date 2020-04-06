using System.ComponentModel;
using Sales.DataLayer.Dto;

namespace Sales.ApplicationWebLayer.Models
{
    public class BookViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Title { get; set; }
        [DisplayName("Автор")]
        public string Author { get; set; }
        [DisplayName("Год издания")]
        public int PublicationYear { get; set; }
        [DisplayName("ISBN")]
        public string Isbn { get; set; }
        [DisplayName("Обложка")]
        public string CoverPicture { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Осталось копий")]
        public int CopiesNumber { get; set; }
        public bool HasAlreadyInCart { get; set; }
    }
}