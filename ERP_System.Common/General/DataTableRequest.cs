﻿using ERP_System.Common.General;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ERP_System
{
    public class DataTableRequest
    {
        #region Private

        private int _Length = 0;
        private int _Start;
        private string _Search = null;

        #endregion

        /// <summary>
        /// Number Of Columns User Specified into the Columns Property Of Data Table Object []
        /// </summary>
        public int IColumns { get; set; }

        public string SColumns { get; set; }

        /// <summary>
        /// The Index Should Start From It To Display Data
        /// </summary>
        public int IDisplayStart
        {
            get => _Start;
            set
            {
                if (value != 0)
                {
                    _Start = value;
                }
            }
        }

        public int Start
        {
            get => _Start;
            set
            {
                if (value != 0)
                {
                    _Start = value;
                }
            }
        }

        /// <summary>
        /// The Length Should Appear in The Data Table 
        /// Showed Recordes To The User
        /// </summary>
        public int IDisplayLength
        {
            get => _Length; set
            {
                if (value != 0)
                {
                    _Length = value;
                }
            }
        }

        public int Length
        {
            get => _Length; set
            {
                if (value != 0)
                {
                    _Length = value;
                }
            }
        }

        public string MDataProp_0 { get; set; }

        public bool BSortable_0 { get; set; }

        /// <summary>
        /// The Index Of Sorting Column by
        /// This Is The Index That The User Sort By It
        /// </summary>
        public int ISortCol_0 { get; set; }

        /// <summary>
        /// This Is The Sorting Direction , asc , desc
        /// </summary>
        public SortingDir SSortDir_0 { get; set; }

        public int ISortingCols { get; set; }

        public string SSearch
        {
            get => _Search;
            set
            {
                if (value != null)
                {
                    _Search = value;
                }
            }
        }

        public string Search
        {
            get => _Search;
            set
            {
                if (value != null)
                {
                    _Search = value;
                }
            }
        }

        public Guid? UserID { get; set; }
        public UserClassification? UserClassification { get; set; }
        public InvoiceType? InvoiceType { get; set; }

        public SqlParameter[] ToSqlParameter(Guid? UserId = null, Guid? LanguageId = null, params SqlParameter[] sqlParameters)
        {
            List<SqlParameter> _list = new List<SqlParameter>
            {
                new SqlParameter() { ParameterName = "@DisplayLength", Value = IDisplayLength },
                new SqlParameter() { ParameterName = "@DisplayStart", Value = IDisplayStart },
                new SqlParameter() { ParameterName = "@SortCol", Value = ISortCol_0 },
                new SqlParameter() { ParameterName = "@SortDir", Value = SSortDir_0.ToString().ToLower() },
                new SqlParameter() { ParameterName = "@Search", Value = SSearch },
            };


            if (UserID != null)
            {
                _list.Add(new SqlParameter() { ParameterName = "@UserID", Value = UserID });
            }
            if (UserClassification != null)
            {
                _list.Add(new SqlParameter() { ParameterName = "@UserClassification", Value = UserClassification });
            }
            if (InvoiceType != null)
            {
                _list.Add(new SqlParameter() { ParameterName = "@InvoiceType", Value = InvoiceType });
            }

            if (LanguageId != null)
            {
                _list.Add(new SqlParameter { ParameterName = "@LanguageID", Value = LanguageId });
            }

            if (sqlParameters != null)
            {
                _list.AddRange(sqlParameters);
            }
            return _list.ToArray();
        }


    }
    public class ProductReportDataTableRequest
    {
        #region Private

        private int _Length = 0;
        private int _Start;
        private string _Search = null;

        #endregion

        /// <summary>
        /// Number Of Columns User Specified into the Columns Property Of Data Table Object []
        /// </summary>
        public int IColumns { get; set; }

        public string SColumns { get; set; }

        /// <summary>
        /// The Index Should Start From It To Display Data
        /// </summary>
        public int IDisplayStart
        {
            get => _Start;
            set
            {
                if (value != 0)
                {
                    _Start = value;
                }
            }
        }

        public int Start
        {
            get => _Start;
            set
            {
                if (value != 0)
                {
                    _Start = value;
                }
            }
        }

        /// <summary>
        /// The Length Should Appear in The Data Table 
        /// Showed Recordes To The User
        /// </summary>
        public int IDisplayLength
        {
            get => _Length; set
            {
                if (value != 0)
                {
                    _Length = value;
                }
            }
        }

        public int Length
        {
            get => _Length; set
            {
                if (value != 0)
                {
                    _Length = value;
                }
            }
        }

        public string MDataProp_0 { get; set; }

        public bool BSortable_0 { get; set; }

        /// <summary>
        /// The Index Of Sorting Column by
        /// This Is The Index That The User Sort By It
        /// </summary>
        public int ISortCol_0 { get; set; }

        /// <summary>
        /// This Is The Sorting Direction , asc , desc
        /// </summary>
        public SortingDir SSortDir_0 { get; set; }

        public int ISortingCols { get; set; }

        public string SSearch
        {
            get => _Search;
            set
            {
                if (value != null)
                {
                    _Search = value;
                }
            }
        }

        public string Search
        {
            get => _Search;
            set
            {
                if (value != null)
                {
                    _Search = value;
                }
            }
        }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Guid? StockId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? CashierId { get; set; }
        public SqlParameter[] ToSqlParameter(params SqlParameter[] sqlParameters)
        {
            List<SqlParameter> _list = new List<SqlParameter>
            {
                new SqlParameter() { ParameterName = "@DisplayLength", Value = IDisplayLength },
                new SqlParameter() { ParameterName = "@DisplayStart", Value = IDisplayStart },
                new SqlParameter() { ParameterName = "@SortCol", Value = ISortCol_0 },
                new SqlParameter() { ParameterName = "@SortDir", Value = SSortDir_0.ToString().ToLower() },
                new SqlParameter() { ParameterName = "@Search", Value = SSearch },
            };

            if (FromDate != null)
            {
                _list.Add(new SqlParameter { ParameterName = "@FromDate", Value = FromDate.Value.Date  });
            }
            if (StockId != null)
            {
                _list.Add(new SqlParameter { ParameterName = "@StockId", Value = StockId });
            }
            if (CashierId != null)
            {
                _list.Add(new SqlParameter { ParameterName = "@CashierId", Value = CashierId });
            }
            if (ProductId != null)
            {
                _list.Add(new SqlParameter { ParameterName = "@ProductId", Value = ProductId });
            }
            if (ToDate != null)
            {
                _list.Add(new SqlParameter { ParameterName = "@ToDate", Value = ToDate.Value.Date });
            }

            if (sqlParameters != null)
            {
                _list.AddRange(sqlParameters);
            }
            return _list.ToArray();
        }


    }
    public enum SortingDir { asc, Desc }
}
