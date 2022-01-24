using Microsoft.AspNetCore.Mvc;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult CreateTask()
        {
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }
    }
}
