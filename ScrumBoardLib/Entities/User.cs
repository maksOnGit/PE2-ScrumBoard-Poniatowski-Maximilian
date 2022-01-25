using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumBoardLib.Entities
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public IEnumerable<ScrumTask> Tasks { get; set; } // navigation
    }
}
