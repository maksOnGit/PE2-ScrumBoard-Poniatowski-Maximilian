using Microsoft.AspNetCore.Mvc.Rendering;
using ScrumBoardLib.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            users = _userRepository.GetAll().Result.ToList().ConvertAll(u => new SelectListItem { Value = u.Id.ToString(), Text = u.UserName });
        }

        public LoginViewModel()
        {

        }

        [Required(ErrorMessage = "Please select or create a user")]
        public int? UserId { get; set; }

        private IEnumerable<SelectListItem> users = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Users
        {
            get
            {
                return users;
            }
            set { users = value; }
        }

    }
}
