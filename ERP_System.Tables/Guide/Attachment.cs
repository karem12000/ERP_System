using ERP_System.Common;
using ERP_System.Common.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_System.Tables
{
    [Table(nameof(Attachment) + "s", Schema = AppConstants.Areas.Guide)]
    public class Attachment : BaseEntity
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public AttachmentType Type { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

    }


   


}

