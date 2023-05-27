using ERP_System.Tables;
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

          
            #endregion
            #region Pages

            //modelBuilder.Entity<User>().HasMany(x => x.AreaCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            //modelBuilder.Entity<User>().HasMany(x => x.AreaModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            //modelBuilder.Entity<User>().HasMany(x => x.AreaDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.PageCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PageModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.PageDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.ActionsPageCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ActionsPageModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ActionsPageDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            #endregion
            #region Guide
            modelBuilder.Entity<User>().HasMany(x => x.InvoiceCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.InvoiceModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.InvoiceDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);
              
            modelBuilder.Entity<User>().HasMany(x => x.StockCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.StockModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.StockDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);
           
            modelBuilder.Entity<User>().HasMany(x => x.ItemGroupCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ItemGroupModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ItemGroupDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.ProductCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ProductModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.ProductDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

            modelBuilder.Entity<User>().HasMany(x => x.UnitCreated).WithOne(x => x.CreatedUser).HasForeignKey(x => x.AddedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UnitModified).WithOne(x => x.ModifiedUser).HasForeignKey(x => x.ModifiedBy);
            modelBuilder.Entity<User>().HasMany(x => x.UnitDeleted).WithOne(x => x.DeletedUser).HasForeignKey(x => x.DeletedBy);

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





        #endregion

        #region Guide
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ItemGrpoup> ItemGrpoups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }


        #endregion
        #region Setting
        public DbSet<Setting> Settings { get; set; }

        #endregion






        #endregion
    }
}
