using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumBoardLib.Entities
{
    public class Task : BaseModel
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
    }
}
