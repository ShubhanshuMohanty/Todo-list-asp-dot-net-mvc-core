using Microsoft.AspNetCore.Mvc;

namespace Todo_list.Areas.Client.Controllers
{
    public class TodoController : Controller
    {
        [Area("Client")]
        public IActionResult Index()
        {

            return View();
        }
    }
}
