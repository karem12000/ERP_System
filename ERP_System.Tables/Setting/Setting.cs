using ERP_System.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP_System.Tables
{
    [Table(nameof(Setting) + "s", Schema = AppConstants.Areas.Setting)]
    public class Setting : BaseEntity
    {
        public string Logo { get; set; }
        public string CompanyImage { get; set; }
        public string SiteName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyAddress { get; set; }
        public string Description { get; set; }
        public DateTime? Duration { get; set; }
    }
}
