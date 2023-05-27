﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP_System.DTO.Guide
{
    public class UserTypeDTO
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }


    }
    public class UserTypeTableDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public string AddedDate { get; set; }
        public int TotalCount { get; set; }
    }
}
