using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Sales.ApplicationWebLayer.Controllers
{
    [ViewComponent]
    public class ShoppingCartController : Controller
    {
        // // GET
        // public IActionResult Index()
        // {
        //     return View();
        // }

        public IViewComponentResult Invoke()
        {
            return new ContentViewComponentResult("dskfjklsdjfklsdjflk");
        }
    }
}