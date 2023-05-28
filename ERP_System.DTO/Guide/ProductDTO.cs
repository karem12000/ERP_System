using ERP_System.Tables;
using Microsoft.AspNetCore.Http;
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

        public double Price { get; set; }
        public IFormFile[] images { get; set; }
        public List<Attachment> ProductImages { get; set; }
        public string? BarCodeText { get; set; }
        public decimal? QtyInStock { get; set; }

        public Guid? GroupId { get; set; }
        public string? GroupName { get; set; }

        public Guid? UnitId { get; set; }
        public string? UnitName { get; set; }
    }

    public class ProductTableDTO : ProductDTO
    {

        public string GroupName { get; set; }
        public string UnitName { get; set; }
        public bool IsActive { get; set; }
        public int TotalCount { get; set; }

    }
}
