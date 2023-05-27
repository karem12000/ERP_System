﻿using ERP_System.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(UserType) + "s", Schema = AppConstants.Areas.Guide)]
    public class UserType:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }

    }
}
