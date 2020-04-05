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
                UserId = user.Id.ToString(),
                HasUsed = user.HasUsed
            };
        }

        public static BookViewModel Map(Book book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                Author = book.Author,
                Isbn = book.Isbn,
                Price = book.Price,
                Title = book.Title,
                CopiesNumber = book.CopiesNumber,
                CoverPicture = book.CoverPicture,
                PublicationYear = book.PublicationYear
            };
        }

        public static ShoppingCartItemViewModel Map(ShoppingCartItem item)
        {
            return new ShoppingCartItemViewModel
            {
                Id = item.Id,
                BookId = item.BookId,
                BookTitle = item.BookTitle,
                BookPrice = item.BookPrice
            };
        }
    }
}