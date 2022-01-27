using ScrumBoardLib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Models
{
    public class ScrumBoardViewModel
    {
        public User User { get; set; }
        public IEnumerable<ScrumTask> Tasks { get; set; }
    }
}
