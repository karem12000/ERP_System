using ERP_System.Common;
using ERP_System.Common.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(User) + "s", Schema = AppConstants.Areas.People)]

    public partial class User:BaseEntity
    {
        [Required, StringLength(100)]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        public string UserImage { get; set; }

        public bool IsAdmin { get; set; } = false;
        /// <summary>
        /// هل قام باستخدام الباسورد الافتراضي ام لا
        /// </summary>
        public bool UseDefaultPassword { get; set; } = true;

        #region Reset

        public DateTime? ResetPasswordDate { get; set; }

        public string CodeOfReset { get; set; } = string.Empty;
        public UserClassification? UserClassification { get; set; }

        #endregion

        /// <summary>
        /// For Password 
        /// </summary>
        public string Salt { get; set; }
        [ForeignKey(nameof(UserType))]
        public Guid? UserTypeId { get; set; }

        public string Name { get; set; }

    }
}
