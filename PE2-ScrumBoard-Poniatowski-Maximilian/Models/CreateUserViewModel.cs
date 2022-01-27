using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Models
{
    public class CreateUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide your name!")]
        public string UserName { get; set; }
    }
}
