using Microsoft.AspNetCore.Mvc;
using PE2_ScrumBoard_Poniatowski_Maximilian.Models;
using ScrumBoardLib.Entities;
using ScrumBoardLib.Interfaces;
using System.Threading.Tasks;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository = null;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserPost(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateUser", model);
            }
            User user = new User { Id = model.Id, UserName = model.UserName };
            await _userRepository.Create(user);
            return RedirectToAction("Index", "Home");

        }
    }
}
