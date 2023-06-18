using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO.Report
{
  
    public class BaseReportDTO
    {
        public string? CompanyName { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyLogo { get; set; }
        public string? Description { get; set; }
    }
    public class SaleReportDataDTO : BaseReportDTO
    {
        public List<SaleReportDTO> Data { get; set; }
    }
}
