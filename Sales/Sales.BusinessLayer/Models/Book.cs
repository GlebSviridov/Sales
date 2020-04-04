namespace Sales.BusinessLayer.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string Isbn { get; set; }
        public string CoverPicture { get; set; }
        public decimal Price { get; set; }
        public int CopiesNumber { get; set; }
    }
}