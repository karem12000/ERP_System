﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP_System.DTO.Guide
{
    public class UnitDTO
    {
        public Guid ID { get; set; }
        public Guid? ParentUnitId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    public class UnitTableDTO
    {

        public Guid ID { get; set; }
        public Guid? ParentUnitId { get; set; }
        public string Name { get; set; }
        public string AddedDate { get; set; }
        public bool IsActive { get; set; }
        public int TotalCount { get; set; }

    }
}
