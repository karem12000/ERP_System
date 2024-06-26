﻿using ERP_System.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.DAL
{
   public class ERP_SystemDbContext : DbContext
    {
        public ERP_SystemDbContext(DbContextOptions<ERP_SystemDbContext> options) : base(options) { }

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          

            #region People
            modelBuilder.Entity<User>().HasMany(x => x.UserCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UserModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UserDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.UserTypeCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UserTypeModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UserTypeDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.UserPermissionCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UserPermissionModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UserPermissionDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.SupplierCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SupplierModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SupplierDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.ClientCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ClientModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ClientDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);


            #endregion
            #region Pages


            modelBuilder.Entity<User>().HasMany(x => x.PageCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PageModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PageDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.ActionsPageCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ActionsPageModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ActionsPageDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            #endregion
            #region Guide
            modelBuilder.Entity<User>().HasMany(x => x.SaleThrowbackCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SaleThrowbackModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SaleThrowbackDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.SaleThrowbackDetailCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SaleThrowbackDetailModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SaleThrowbackDetailDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.PurchaseThrowbackCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PurchaseThrowbackModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PurchaseThrowbackDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.PurchaseThrowbackDetailCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PurchaseThrowbackDetailModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PurchaseThrowbackDetailDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.PurchaseInvoiceCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PurchaseInvoiceModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PurchaseInvoiceDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);
            
            modelBuilder.Entity<User>().HasMany(x => x.PurchaseInvoiceDetailCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PurchaseInvoiceDetailModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PurchaseInvoiceDetailDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);
            
            modelBuilder.Entity<User>().HasMany(x => x.SaleInvoiceCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SaleInvoiceModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SaleInvoiceDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

             modelBuilder.Entity<User>().HasMany(x => x.SaleInvoiceDetailCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SaleInvoiceDetailModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SaleInvoiceDetailDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);


            modelBuilder.Entity<User>().HasMany(x => x.StockProductCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.StockProductModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.StockProductDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

             modelBuilder.Entity<User>().HasMany(x => x.UserStockCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UserStockModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UserStockDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);


            modelBuilder.Entity<User>().HasMany(x => x.StockCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.StockModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.StockDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);
           
            modelBuilder.Entity<User>().HasMany(x => x.ItemGroupCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ItemGroupModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ItemGroupDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.ProductCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ProductModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ProductDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);
            
            modelBuilder.Entity<User>().HasMany(x => x.ProductUnitCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ProductUnitModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ProductUnitDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.UnitCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UnitModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UnitDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.AttatchCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.AttatchModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.AttatchDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            #endregion
            #region Setting
            modelBuilder.Entity<User>().HasMany(x => x.SettingCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SettingModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.SettingDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            #endregion


        }

        #endregion
        #region Entities

        #region People

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserStock> UserStocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Client> Clients { get; set; }





        #endregion

        #region Guide
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
        public DbSet<SaleInvoice> SaleInvoices { get; set; }
        public DbSet<SaleInvoiceDetail> SaleInvoiceDetails { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockProduct> StockProducts { get; set; }
        public DbSet<ItemGrpoup> ItemGrpoups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductUnit> ProductUnit { get; set; }
        public DbSet<Unit> Units { get; set; }


        public DbSet<SaleThrowback> SaleThrowbacks { get; set; }
        public DbSet<SaleThrowbackDetail> SaleThrowbackDetails { get; set; }
        public DbSet<PurchaseThrowback> PurchaseThrowbacks { get; set; }
        public DbSet<PurchaseThrowbackDetail> PurchaseThrowbackDetails { get; set; }


        #endregion
        #region Setting
        public DbSet<Setting> Settings { get; set; }

        #endregion






        #endregion
    }
}
