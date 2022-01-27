using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PE2_ScrumBoard_Poniatowski_Maximilian.Models;
using ScrumBoardLib.Entities;
using ScrumBoardLib.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Controllers
{
    public class BoardController : Controller
    {
        private static User user = null;
        private readonly IUserRepository _userRepository = null;
        private readonly ITaskRepository _taskRepository = null;

        public BoardController(IUserRepository userRepository, ITaskRepository taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateTask()
        {
            //Send to "error view" if u try to acces ...board/createtask without being loged in.
            //(This "error view" is hidden inside the Overview View and it's trigered when u try to access the Overview View without login)
            if (user != null)
            {
                return View();
            }
            return RedirectToAction("Overview");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskPost(CreateTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateTask", model);
            }
            ScrumTask newTask = new ScrumTask { Id = model.Id, StatusId = 1, TaskDescription = model.TaskDescription, TaskName = model.TaskName, UserId = user.Id };
            await _taskRepository.Create(newTask);
            return RedirectToAction("Overview");
        }

        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            ScrumBoardViewModel vm = new ScrumBoardViewModel();
            vm.User = user;
            vm.Tasks = await _taskRepository.GetAll();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Users = _userRepository.GetAll().Result.ToList().ConvertAll(u => new SelectListItem { Value = u.Id.ToString(), Text = u.UserName });
                return View("~/Views/Home/Index.cshtml", model);
            }
            user = await _userRepository.GetById((int)model.UserId);
            return RedirectToAction("Overview");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            user = null;
            return RedirectToAction("Index", "Home");
        }

        
        public async Task<IActionResult> StartTask(int id)
        {
            ScrumTask target = await _taskRepository.GetById(id);
            target.StatusId = 2;
            await _taskRepository.Update(target);
            return RedirectToAction("Overview");
        }

       
        public async Task<IActionResult> FinishTask(int id)
        {
            ScrumTask target = await _taskRepository.GetById(id);
            target.StatusId = 3;
            await _taskRepository.Update(target);
            return RedirectToAction("Overview");
        }

       
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskRepository.DeleteById(id);
            return RedirectToAction("Overview");
        }

    }
}
