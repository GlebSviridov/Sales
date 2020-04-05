using System.Collections.Generic;
using System.Linq;
using Sales.BusinessLayer.Helpers;
using Sales.BusinessLayer.Interfaces;
using Sales.BusinessLayer.Models;
using Sales.DataLayer.Interfaces;

namespace Sales.BusinessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
            var booksDto = _bookRepository.GetList();

            return booksDto.Select(Mapper.Map).ToList();
        }

        public void DecrementCopiesNumber(int bookId)
        {
            _bookRepository.UpdateCopiesNumber(bookId, -1);
        }

        public void IncrementCopiesNumber(int bookId)
        {
            _bookRepository.UpdateCopiesNumber(bookId, 1);
        }
    }
}