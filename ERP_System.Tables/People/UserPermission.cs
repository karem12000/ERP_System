using ERP_System.Common;
using ERP_System.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(UserPermission) + "s", Schema = AppConstants.Areas.People)]

    public class UserPermission:BaseEntity
    {
        [ForeignKey(nameof(ActionsPage))]
        public Guid? PageActionId { get; set; }
        [ForeignKey(nameof(UserType))]

        public Guid? UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual ActionsPage ActionsPage { get; set; }

    }
}
