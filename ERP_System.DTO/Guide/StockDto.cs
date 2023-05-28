using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP_System.DTO.Guide
{
    public class StockDto
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? ManagerName { get; set; }
    }
    public class StockTableDTO : StockDto
    {

        public string AddedDate { get; set; }
        public int TotalCount { get; set; }

    }
}
