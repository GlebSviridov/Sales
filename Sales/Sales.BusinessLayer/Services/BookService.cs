using System.Collections.Generic;
using System.Linq;
using Sales.BusinessLayer.Helpers;
using Sales.BusinessLayer.Interfaces;
using Sales.BusinessLayer.Models;
using Sales.DataLayer.Dto;
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
    }
}