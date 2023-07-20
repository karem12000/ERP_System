using ERP_System.DAL;
using ERP_System.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ERP_System.BLL.Report
{
	public class SupplierReportBll
	{
		private readonly IRepository<Supplier> _repoSupplier;
        public SupplierReportBll(IRepository<Supplier> repoSupplier)
        {
                _repoSupplier = repoSupplier;
        }

		public DataTableResponse GetDebtorSupplierNumPurchasingReportDto(ProductReportDataTableRequest mdl)
		{
			var data = _repoSupplier.ExecuteStoredProcedure<GetSupplierAmountDto>
				("[Report].[spGetDebtorSupplier]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}

		public DataTableResponse GetCreditorSupplierNumPurchasingReportDto(ProductReportDataTableRequest mdl)
		{
			var data = _repoSupplier.ExecuteStoredProcedure<GetSupplierAmountDto>
				("[Report].[spGetCreditorSupplier]", mdl?.ToSqlParameter(), CommandType.StoredProcedure);

			return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
		}
	}

	public class GetSupplierAmountDto
	{
		public string Name { get; set; }
		public string CompanyName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public decimal? Amount { get; set; }
		public bool IsActive { get; set; }
		public int? TotalCount { get; set; }
	}
}
