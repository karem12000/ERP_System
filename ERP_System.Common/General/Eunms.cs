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
        Add = 1, Edit, Delete, Show, Throwback
    }
    /// <summary>
    /// نوع الفاتورة (بيع و شراء و مرتجع)
    /// </summary>
    public enum InvoiceType
    {
       Sale=1 , Receipt, SaleThrowBack,ReciptThrowBack
    }
    public enum AttachmentType
    {
        file = 0,
        image = 1,
    }

    public enum UserClassification
    {
       SuperAdmin=1 , Admin=2, User=3, Cashier=4, Client=5 , Suppliers=6 
    }
    public enum ProcessType
    {
        /// <summary>
        /// مدين
        /// </summary>
        Debtor = 1 
            ///دائن
        , Creditor = 2
    }


}
