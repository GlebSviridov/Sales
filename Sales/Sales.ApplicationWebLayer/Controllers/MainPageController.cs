using Microsoft.AspNetCore.Mvc;
using Sales.BusinessLayer.Interfaces;

namespace Sales.ApplicationWebLayer.Controllers
{
    public class MainPageController : Controller
    {
        private readonly IBookService _bookService;

        public MainPageController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            ViewData["UserId"] = TempData["UserId"];
            var books = _bookService.GetAllBooks();
            return View(books);
        }
    }
}