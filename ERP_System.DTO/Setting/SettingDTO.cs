using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP_System.DTO.Guide
{
    public class SettingDTO
    {
        public Guid ID { get; set; }
        [Required]
        public string SiteName { get; set; }
        public IFormFile Logo { get; set; }
        public bool IsActive { get; set; }
    }
}
