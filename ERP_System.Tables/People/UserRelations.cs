using System.Collections.Generic;
using System.Text;

namespace ERP_System.Tables
{
    public partial class User
    {
        #region Relations


        public virtual UserType UserType { get; set; }
        public ICollection<Stock> Stocks { get; set; }

        public ICollection<UserPermission> UserPermissionCreated { get; set; }
        public ICollection<UserPermission> UserPermissionModified { get; set; }
        public ICollection<UserPermission> UserPermissionDeleted { get; set; }

        #region Pages
        //public ICollection<Area> AreaCreated { get; set; }
        //public ICollection<Area> AreaModified { get; set; }
        //public ICollection<Area> AreaDeleted { get; set; }

        public ICollection<Page> PageCreated { get; set; }
        public ICollection<Page> PageModified { get; set; }
        public ICollection<Page> PageDeleted { get; set; }

        public ICollection<ActionsPage> ActionsPageCreated { get; set; }
        public ICollection<ActionsPage> ActionsPageModified { get; set; }
        public ICollection<ActionsPage> ActionsPageDeleted { get; set; }

        #endregion
        #region User

        public ICollection<User> UserCreated { get; set; }
        public ICollection<User> UserModified { get; set; }
        public ICollection<User> UserDeleted { get; set; }
        public ICollection<UserType> UserTypeCreated { get; set; }
        public ICollection<UserType> UserTypeModified { get; set; }
        public ICollection<UserType> UserTypeDeleted { get; set; }


        #endregion
        #region Guide
        public ICollection<Invoice> InvoiceCreated { get; set; }
        public ICollection<Invoice> InvoiceModified { get; set; }
        public ICollection<Invoice> InvoiceDeleted { get; set; } 
        
        public ICollection<Stock> StockCreated { get; set; }
        public ICollection<Stock> StockModified { get; set; }
        public ICollection<Stock> StockDeleted { get; set; }
        
        public ICollection<ItemGrpoup> ItemGroupCreated { get; set; }
        public ICollection<ItemGrpoup> ItemGroupModified { get; set; }
        public ICollection<ItemGrpoup> ItemGroupDeleted { get; set; } 
        
        public ICollection<Product> ProductCreated { get; set; }
        public ICollection<Product> ProductModified { get; set; }
        public ICollection<Product> ProductDeleted { get; set; }

        public ICollection<Unit> UnitCreated { get; set; }
        public ICollection<Unit> UnitModified { get; set; }
        public ICollection<Unit> UnitDeleted { get; set; }

        public ICollection<Attachment> AttatchCreated { get; set; }
        public ICollection<Attachment> AttatchModified { get; set; }
        public ICollection<Attachment> AttatchDeleted { get; set; }
        #endregion
        #region Setting
        public ICollection<Setting> SettingCreated { get; set; }
        public ICollection<Setting> SettingModified { get; set; }
        public ICollection<Setting> SettingDeleted { get; set; }
        #endregion
        #endregion

    }
}
