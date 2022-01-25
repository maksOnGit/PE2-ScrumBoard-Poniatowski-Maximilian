using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PE2_ScrumBoard_Poniatowski_Maximilian.Models;
using ScrumBoardLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository = null;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            LoginViewModel vm = new LoginViewModel(_userRepository);

            return View(vm);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
