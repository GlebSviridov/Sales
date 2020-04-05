using Sales.BusinessLayer.Models;
using Sales.BusinessLayer.Services;
using Sales.DataLayer.Dto;

namespace Sales.BusinessLayer.Helpers
{
    public static class Mapper
    {
        public static User Map(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                HasUsed = userDto.HasUsed
            };
        }

        public static Book Map(BookDto bookDto)
        {
            return new Book
            {
                Id = bookDto.Id,
                Author = bookDto.Author,
                Isbn = bookDto.Isbn,
                Price = bookDto.Price,
                Title = bookDto.Title,
                CopiesNumber = bookDto.CopiesNumber,
                CoverPicture = bookDto.CoverPicture,
                PublicationYear = bookDto.PublicationYear
            };
        }

        public static ShoppingCartItem Map(ShoppingCartItemDto itemDto)
        {
            return new ShoppingCartItem
            {
                Id = itemDto.Id,
                BookId = itemDto.BookId,
                BookTitle = itemDto.Title,
                BookPrice = itemDto.Price
            };
        }
    }
}