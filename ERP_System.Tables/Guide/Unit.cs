﻿using ERP_System.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(Unit) + "s", Schema = AppConstants.Areas.Guide)]
    public class Unit : BaseEntity
    {
        public string Name { get; set; }


        public ICollection<Product> Products { get; set; }


    }
}
