using Microsoft.AspNetCore.Mvc;

namespace ShowsAPI.Controllers
{
    public class ShowsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
