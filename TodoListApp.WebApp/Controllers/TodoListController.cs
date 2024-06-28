using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.WebApp.Controllers
{
    public class TodoListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
