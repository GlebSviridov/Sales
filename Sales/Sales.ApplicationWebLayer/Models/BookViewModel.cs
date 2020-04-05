﻿using Sales.DataLayer.Dto;

namespace Sales.ApplicationWebLayer.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string Isbn { get; set; }
        public string CoverPicture { get; set; }
        public decimal Price { get; set; }
        public int CopiesNumber { get; set; }
        public bool HasAlreadyInCart { get; set; }
    }
}