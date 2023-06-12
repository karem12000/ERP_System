using System.Collections.Generic;
using System.Text;

namespace ERP_System.Tables
{
    public partial class User
    {
        #region Relations


        public virtual UserType UserType { get; set; }
        public virtual ICollection<UserStock> UserStocks { get; set; }


        public ICollection<UserPermission> UserPermissionCreated { get; set; }
        public ICollection<UserPermission> UserPermissionModified { get; set; }
        public ICollection<UserPermission> UserPermissionDeleted { get; set; }



        public ICollection<Supplier> SupplierCreated { get; set; }
        public ICollection<Supplier> SupplierModified { get; set; }
        public ICollection<Supplier> SupplierDeleted { get; set; }
        
        public ICollection<Client> ClientCreated { get; set; }
        public ICollection<Client> ClientModified { get; set; }
        public ICollection<Client> ClientDeleted { get; set; }



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
        public ICollection<PurchaseInvoice> PurchaseInvoiceCreated { get; set; }
        public ICollection<PurchaseInvoice> PurchaseInvoiceModified { get; set; }
        public ICollection<PurchaseInvoice> PurchaseInvoiceDeleted { get; set; }
        
        public ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetailCreated { get; set; }
        public ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetailModified { get; set; }
        public ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetailDeleted { get; set; }
        
        public ICollection<SaleInvoice> SaleInvoiceCreated { get; set; }
        public ICollection<SaleInvoice> SaleInvoiceModified { get; set; }
        public ICollection<SaleInvoice> SaleInvoiceDeleted { get; set; }
        
        public ICollection<SaleInvoiceDetail> SaleInvoiceDetailCreated { get; set; }
        public ICollection<SaleInvoiceDetail> SaleInvoiceDetailModified { get; set; }
        public ICollection<SaleInvoiceDetail> SaleInvoiceDetailDeleted { get; set; }

        public ICollection<StockProduct> StockProductCreated { get; set; }
        public ICollection<StockProduct> StockProductModified { get; set; }
        public ICollection<StockProduct> StockProductDeleted { get; set; }
        
        public ICollection<UserStock> UserStockCreated { get; set; }
        public ICollection<UserStock> UserStockModified { get; set; }
        public ICollection<UserStock> UserStockDeleted { get; set; }

        public ICollection<Stock> StockCreated { get; set; }
        public ICollection<Stock> StockModified { get; set; }
        public ICollection<Stock> StockDeleted { get; set; }
        
        public ICollection<ItemGrpoup> ItemGroupCreated { get; set; }
        public ICollection<ItemGrpoup> ItemGroupModified { get; set; }
        public ICollection<ItemGrpoup> ItemGroupDeleted { get; set; } 
        
        public ICollection<Product> ProductCreated { get; set; }
        public ICollection<Product> ProductModified { get; set; }
        public ICollection<Product> ProductDeleted { get; set; }

        public ICollection<ProductUnit> ProductUnitCreated { get; set; }
        public ICollection<ProductUnit> ProductUnitModified { get; set; }
        public ICollection<ProductUnit> ProductUnitDeleted { get; set; }

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
