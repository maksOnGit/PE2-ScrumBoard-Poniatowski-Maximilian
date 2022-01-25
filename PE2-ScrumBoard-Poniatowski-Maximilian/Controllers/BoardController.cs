using Microsoft.AspNetCore.Mvc;
using PE2_ScrumBoard_Poniatowski_Maximilian.Models;
using ScrumBoardLib.Entities;
using ScrumBoardLib.Interfaces;
using System.Threading.Tasks;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Controllers
{
    public class BoardController : Controller
    {
        private static User user = null;
        private readonly IUserRepository _userRepository = null;
        public BoardController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> CreateTask()
        {
            return await Task.FromResult(View());
        }
        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            ScrumBoardViewModel vm = new ScrumBoardViewModel();
            vm.User = user;
            //TODO add tasks
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            user = await _userRepository.GetById(model.UserId);
            return RedirectToAction("Overview");
        }
    }
}
