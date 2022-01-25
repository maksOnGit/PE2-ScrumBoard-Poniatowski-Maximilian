using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumBoardLib.Entities
{
    public class ScrumTask : BaseModel
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } // navigation
        public int StatusId { get; set; }
        public Status Status { get; set; } // navigation

    }
}
