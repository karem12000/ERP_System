using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO
{
    public class SelectListDTO
    {
        public Guid Value { get; set; }
        public string Text { get; set; }
        public object Data { get; set; }
    }


    public class SelectChildWithParentDTO
    {
        public Guid Value { get; set; }
        public string Text { get; set; }
        public List<SelectListDTO> Childs { get; set; }
    }
}
