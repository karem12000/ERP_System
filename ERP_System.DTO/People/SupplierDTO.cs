using ERP_System.Common;
using ERP_System.Common.General;
using ERP_System.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ERP_System.DTO
{
    public class SupplierDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string companyName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public ProcessType? ProcessType { get; set; }
        public int? ProcessTypeInt { get; set; }
        public decimal? ProcessAmount { get; set; }
        public bool IsActive { get; set; }
    }

    public class SupplierTableDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string companyName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AddedDate { get; set; }
        public ProcessType? ProcessType { get; set; }
        public decimal? ProcessAmount { get; set; }
        public bool IsActive { get; set; }
        public int TotalCount { get; set; }

    }


}
