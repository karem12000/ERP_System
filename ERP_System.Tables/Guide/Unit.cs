using ERP_System.Common;
using ERP_System.Common.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(Unit) + "s", Schema = AppConstants.Areas.Guide)]
    public class Unit : BaseEntity
    {
        public string Name { get; set; }
        //public double? Rate { get; set; } = 0;
        //public Guid? ParentId { get; set; } = null;
        //public UnitType? UnitType { get; set; } = null;

        public ICollection<ProductUnit> ProductUnits { get; set; }

    }
}
