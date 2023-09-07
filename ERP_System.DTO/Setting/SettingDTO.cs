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
        public IFormFile CompanyImage { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyAddress { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? Duration { get; set; }
        public string DurationStr { get; set; }
        public string MacAddress { get; set; }
    }
    public class ActivationData
    {
        public string Address { get; set; }
        public string Duration { get; set; }
    }
}
