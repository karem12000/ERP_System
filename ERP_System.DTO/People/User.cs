using ERP_System.Common;
using ERP_System.Common.General;
using ERP_System.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP_System.DTO
{
    public class UserParameters
    {
        [Required(ErrorMessage = nameof(ERP_SystemResources.UsernameRequired))]
        public string Username { get; set; }
        [Required(ErrorMessage = nameof(ERP_SystemResources.PasswordRequired))]

        public string Password { get; set; }
    }
    public class UserChangePasswordParameters
    {
        [Required(ErrorMessage = nameof(ERP_SystemResources.PasswordRequired))]

        public string NewPassword { get; set; }
    }
    public class UserSendCodeParameters
    {
        [Required(ErrorMessage = nameof(ERP_SystemResources.UsernameRequired))]

        public string Username { get; set; }
    }
    public class UserForgetPasswordParameters
    {
        [Required(ErrorMessage = nameof(ERP_SystemResources.UsernameRequired))]

        public string Username { get; set; }

        [Required(ErrorMessage = nameof(ERP_SystemResources.PasswordRequired))]

        public string NewPassword { get; set; }
        [Required(ErrorMessage = nameof(ERP_SystemResources.ValidationCodeRequired))]

        public string Code { get; set; }
    }
    public class UserResultDTO
    {
        public Guid Id { get; set; }
        public string BearerToken { get; set; }
        public string Username { get; set; }
        public bool UseDefaultPassword { get; set; } = true;
    }
    public class UserSelectDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public bool Selected { get; set; }

    }
    
    #region Web
    public class UserDTO
    {
        public int TotalCount { get; set; } = 0;
        public Guid ID { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = AppConstants.Messages.RequiredMessage), StringLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = AppConstants.Messages.RequiredMessage)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; } = false;

        public bool IsActive { get; set; }
        public string AddedDate { get; set; }
        public IEnumerable<Guid>? StockIds { get; set; }

        public Guid? UserTypeId { get; set; }

        public string UserTypeName { get; set; }

    }

    public class UserTableDTO
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public UserClassification? UserClassification { get; set; }
        public Guid? UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string Name { get; set; }
        public string AddedDate { get; set; }
        public bool IsActive { get; set; }
        public int TotalCount { get; set; }

    }
    #endregion
}
