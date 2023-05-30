using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System
{
    public class DataTableResponse
    {
        public DataTableResponse() { }

        public DataTableResponse(int ITotalRecords, object Data)
        {
            this.iTotalRecords = ITotalRecords;
            aaData = Data;
        }

        public int iTotalRecords { get; set; }

        public int iTotalDisplayRecords => iTotalRecords;

        public object aaData { get; set; }

        public object data => aaData;

    }
}
