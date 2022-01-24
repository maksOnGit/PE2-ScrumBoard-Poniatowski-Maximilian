using Microsoft.AspNetCore.Mvc;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Controllers
{
    public class UserController : Controller
    {
        public IActionResult CreateUser()
        {
            return View();
        }
    }
}
