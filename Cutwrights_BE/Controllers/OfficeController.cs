using Microsoft.AspNetCore.Mvc;

namespace CutwrightsCRUD.Controllers
{
    public class OfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
