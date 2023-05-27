using ERP_System.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(Stock) + "s", Schema = AppConstants.Areas.Guide)]
    public class Stock : BaseEntity
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? ManagerName { get; set; }
        //public decimal? Quantity { get; set; }


        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<StockProduct> StockProducts { get; set; }

    }

    [Table(nameof(StockProduct) + "s", Schema = AppConstants.Areas.Guide)]
    public class StockProduct : BaseEntity
    {
        [ForeignKey(nameof(Stock))]
        public Guid? StockId { get; set; }
        public virtual Stock Stock { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
