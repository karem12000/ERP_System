using ERP_System.Common;
using ERP_System.Common.General;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP_System.Tables
{
    [Table(nameof(Supplier) + "s", Schema = AppConstants.Areas.People)]
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string companyName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public ProcessType? ProcessType { get; set; }
        public decimal? ProcessAmount { get; set; }
    }
}
