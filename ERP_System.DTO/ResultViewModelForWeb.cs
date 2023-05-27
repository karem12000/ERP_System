using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO
{
    public class ResultViewModel
    {
        public bool Status { get; set; } 
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
