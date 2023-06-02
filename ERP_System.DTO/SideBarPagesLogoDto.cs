using ERP_System.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO
{
    public class SideBarPagesLogoDto
    {
        public Setting Setting { get; set; }
        public IEnumerable<AsideBarPagesDTO> AsideBarPagesDTO { get; set; }
    }
}
