using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System.Common.General
{

    public enum ActionEnum
    {
        Add = 1, Edit, Delete, Show
    }
    /// <summary>
    /// نوع الفاتورة (بيع و شراء و مرتجع)
    /// </summary>
    public enum InvoiceType
    {
       Sale=1 , Receipt, ThrowBack
    }


}
