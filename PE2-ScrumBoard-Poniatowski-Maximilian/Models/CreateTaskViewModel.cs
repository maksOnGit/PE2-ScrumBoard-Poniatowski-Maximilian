using ScrumBoardLib.Entities;
using System.ComponentModel.DataAnnotations;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Models
{
    public class CreateTaskViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide the task name!")]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int UserId { get; set; }
    }
}
