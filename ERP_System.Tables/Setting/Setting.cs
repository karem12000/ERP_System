using ERP_System.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP_System.Tables
{
    [Table(nameof(Setting) + "s", Schema = AppConstants.Areas.Setting)]
    public class Setting : BaseEntity
    {
        public string Logo { get; set; }
        public string SiteName { get; set; }
    }
}
