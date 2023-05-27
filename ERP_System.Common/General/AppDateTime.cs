using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.Common
{
  public static  class AppDateTime
    {
        /// <summary>
        /// تاريخ ووقت   مصر
        /// </summary>
        public static DateTime Now => DateTime.UtcNow.AddHours(2);
    }
}
