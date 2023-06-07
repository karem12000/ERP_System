using ERP_System.Tables;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.DTO.Guide
{
    public class ProductDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public string ProductUnitsStr { get; set; }
        //public ProductUnitsDTO[] ProductUnits {

        //    set
        //    {
        //        ProductUnits = JsonConvert.DeserializeObject<ProductUnitsDTO[]>(ProductUnitsStr);
        //    }

        //    get { return ProductUnits; }

        //}
        public ProductUnitsDTO[] ProductUnits => JsonConvert.DeserializeObject<ProductUnitsDTO[]>(ProductUnitsStr);
        public ProductUnitsDTO[] GetProductUnits { get; set; }

        //public double Price { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        public List<Attachment> ProductImages { get; set; }
        public string BarCodeText { get; set; }
        public string BarCodePath { get; set; }
        public decimal? QtyInStock { get; set; }

        public Guid? GroupId { get; set; }
        public string GroupName { get; set; }

        public Guid? StockId { get; set; }
        public string StockName { get; set; }

        public Guid? UnitId { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
    }

    public class ProductTableDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string AddedDate { get; set; }
        //public double Price { get; set; }
        public string BarCodeText { get; set; }
        public string BarCodePath { get; set; }
        public Guid? GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public Guid? StockId { get; set; }
        public string StockName { get; set; }

        //public Guid? UnitId { get; set; }
        //public string UnitName { get; set; }
        public decimal? QtyInStock { get; set; }
        public bool IsActive { get; set; }
        public int TotalCount { get; set; }

    }

    public class ProductUnitsDTO
    {
        public Guid? ID { get; set; }
        public Guid? UnitId { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Price { get; set; }
       
    }
}
