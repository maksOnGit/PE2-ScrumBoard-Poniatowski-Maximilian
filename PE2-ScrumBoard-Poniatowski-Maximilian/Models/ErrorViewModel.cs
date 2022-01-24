using System;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
