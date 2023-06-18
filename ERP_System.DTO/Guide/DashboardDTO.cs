using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO.Guide
{
    public class DashboardDTO
    {
        public int UsersCount { get; set; }
        public int ProductsCount { get; set; }
        public int StocksCount { get; set; }
        public int GroupsCount { get; set; }
        public List<MostSaleProducts> MostSaleProductsCount { get; set; }
    }
    public class MostSaleProducts
    {
        public string ProductName { get; set; }
        public Guid? ProductId { get; set; }
        public decimal? Qty { get; set; }
    }
}
