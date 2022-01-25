using Microsoft.AspNetCore.Mvc.Rendering;
using ScrumBoardLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Models
{
    public class LoginViewModel
    {
        private readonly IUserRepository _userRepository = null;
        public LoginViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LoginViewModel()
        {

        }

        public int UserId { get; set; }
        public IEnumerable<SelectListItem> Users
        {
            get
            {
                if (_userRepository != null)
                {
                    return _userRepository.GetAll().Result.ToList().ConvertAll(u => new SelectListItem { Value = u.Id.ToString(), Text = u.UserName });
                }
                return Enumerable.Empty<SelectListItem>();
            }
        }
    }
}
