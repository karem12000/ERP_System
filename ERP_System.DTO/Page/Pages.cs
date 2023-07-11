using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DTO
{
    public class AsideBarDTO
    {
        //public string AreaTitle { get; set; }
        //public int? OrderNo { get; set; }
        //public string IconName { get; set; }
        //public bool? IsLink { get; set; }
        //public string Link { get; set; }

        //public IEnumerable<AsideBarPagesDTO> AsideBarPagesDTOs { get; set; }
        
    }
    public class AsideBarPagesDTO
    {
        public string PageTitle { get; set; }
        public string AreaTitle { get; set; }
        public int? OrderNo { get; set; }
        public string IconName { get; set; }
        public string PageRoute { get; set; }
        public bool HasPermission { get; set; }
    }

    public class NewSidebarDto
    {
        public string PageRoute { get; set; }
        public string PageTitle { get; set; }
        public string IconName { get; set; }
        public string AreaName { get; set; }
        public int? OrderNo { get; set; }
        public bool HasPermission { get; set; }
        public bool IsArea { get; set; }
        public bool HaveArea { get; set; }
        public string CollapsedArea { get; set; }
        public List<AsideBarPagesDTO> Pages { get; set; }
    }
}