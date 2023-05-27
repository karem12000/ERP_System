using ERP_System.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP_System.Tables
{
    [Table(nameof(ItemGrpoup) + "s", Schema = AppConstants.Areas.Guide)]
    public class ItemGrpoup : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
