
function printDiv(data) {
	console.log(data);
	if (data) {
		var a = window.open('', '', 'height=1200, width=1200');

		a.document.write('<html>');
		a.document.write('<body >');
		a.document.write(
			`
				<div id="GFG"">
					<table width=" 100%" align="center" cellpadding="0" cellspacing="0">
					<tbody>
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="640" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">
										  <p class="small"
											style="width:fit-content;font-size: 12px;font-weight: bold;color: #777;margin:0 0 5px 0;">
											    رقم الشركة :  ${data[0]?.CompanyPhone}
										  </p>
										  <p class="small" style="margin: 0;"> عنوان الشركة : ${data[0]?.CompanyAddress}</p>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <img src="../../../${data[0]?.CompanyImage}" width="100" alt="Logo" />
										  <h5 style="font-size: 18px;margin:5px 0;"> اسم الشركة : ${data[0]?.CompanyName}</h5>

										</td>
									  </tr>
									</tbody>
								  </table>
								</td>
							  </tr>
							</tbody>
						  </table>
						</td>
					  </tr>
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="640" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 20px;">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">
										  <h5 style="margin: 0;">
											<span style="margin: 0 15px;">رقم الفاتورة : </span>
											<span>${data[0]?.InvoiceNumber}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span style="margin: 0 15px;">تاريخ الفاتورة :</span>
											<span>${data[0]?.InvoiceDate}</span>
										  </h5>
										   <h5 style="margin: 0;">
											<span style="margin: 0 15px;">المخزن : </span>
											<span> ${data[0]?.StockName}</span>
										  </h5>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <h5 style="font-size: 18px;margin:5px 0;"> فاتورة مبيعات </h5>
										</td>
									  </tr>
									</tbody>
								  </table>
								</td>
							  </tr>
							</tbody>
						  </table>
						</td>
					  </tr>
					  <tr>
						<td align="center" dir="rtl">
						  <table class="mobileWidth borderd" width="640" cellspacing="0" cellpadding="0" style="margin-top: 50px;">
							<tbody>

							  <tr style="border: 1px solid #000;background-color: #a0a0a0;">
								<th class="bold small" style="text-align: right;height: 25px;">الصنف</th>
								<th class="bold small" style="text-align: right;height: 25px;">الباركود</th>
								<th class="bold small" style="text-align: right;height: 25px;">الوحده</th>
								<th class="bold small" style="text-align: right;height: 25px;">سعر البيع</th>
								<th class="bold small" style="text-align: right;height: 25px;">الكمية</th>
								<th class="bold small" style="text-align: right;height: 25px;">الخصم</th>
								<th class="bold small" style="text-align: right;height: 25px;">الإجمالي</th>
							  </tr>

							  `);
		if (data[0].InvoiceDetails.length) {
			data[0].InvoiceDetails.forEach((detail) => {
				a.document.write(
					`
			  <tr>
								<td>${detail.UnitJsonDto[0]?.ProductJsonDto[0]?.ProductName}</td>
								<td>${detail.UnitJsonDto[0]?.ProductJsonDto[0]?.ProductParcode}</td>
								<td>${detail.UnitJsonDto[0]?.UnitName}</td>
								<td>${detail.ProductSellingPrice}</td>
								<td>${detail.ProductQty}</td>
								<td>${detail.ProductDisscount} ${detail.ProductDiscountTypeStr}</td>
								<td>${detail.ProductTotalQtyPrice}</td>
								
			 </tr>
			`
				)
			});
		} else {
			a.document.write(`
		<tr>
			<td colspan="7">لاتوجد بيانات</td>
			</tr>
		`);
		}


		a.document.write(`
	  
							</tbody >
						  </table >
						</td >
					  </tr >
		<tr>
			<td align="center">
				<table class="mobileWidth" width="640" cellspacing="0" cellpadding="0">
					<tbody>
						<tr>
							<td>
								<table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 45px;">
									<tbody>
										<tr dir="rtl">
											<td width="135" align="left"
												style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
												<h5 style="font-size: 18px;margin:5px 0; border-bottom: 1px solid;">
													<span style="float: right;"> الخصم:</span>
													<span class="normal small">${data[0]?.InvoiceTotalDiscount} ${data[0].InvoiceDisscountTypeStr}</span>
												</h5>
												<h5 style="font-size: 18px;margin:5px 0; border-bottom: 1px solid;">
													<span style="float: right;">الإجمالي : </span>
													<span class="normal small">${data[0]?.InvoiceTotalPrice}</span>
												</h5>
												<h5 style="font-size: 18px;margin:5px 0; border-bottom: 1px solid;">
													<span style="float: right;">المدفوع:</span>
													<span class="normal small">${data[0]?.TotalPaid}</span>
												</h5>
												<h5 style="font-size: 18px;margin:5px 0; border-bottom: 1px solid;">
													<span style="float: right;">الباقي:</span>
													<span class="normal small">${data[0]?.Remainning}</span>
												</h5>
											</td>
											<td width="135" align="center"></td>
											<td width="135" align="right"></td>
										</tr>
									</tbody>
								</table>
							</td>
						</tr>
					</tbody>
				</table>
			</td>
		</tr>
					</tbody >
					</table >
				  </div >
					
	`);

		// <tr>
		//<td>صنف تجريبي</td>
		//<td>100.00</td>
		//<td>10</td>
		//<td>10%</td>
		//<td>9000</td>
		// </tr>
		// <tr>
		//<td>صنف تجريبي</td>
		//<td>100.00</td>
		//<td>10</td>
		//<td>10%</td>
		//<td>9000</td>
		// </tr>
		// <tr>
		//<td>صنف تجريبي</td>
		//<td>100.00</td>
		//<td>10</td>
		//<td>10%</td>
		//<td>9000</td>
		// </tr>


		a.document.write('</body></html>');
		a.document.close();
		a.print();
	}
}

function printParchase(data) {
	console.log(data);
	if (data) {
		var a = window.open('', '', 'height=1200, width=1200');
		a.document.write('<html>');
		a.document.write('<body >');
		a.document.write(
			`
				<div id="GFG"">
					<table width=" 100%" align="center" cellpadding="0" cellspacing="0">
					<tbody>
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="640" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">
										  <p class="small"
											style="width:fit-content;font-size: 12px;font-weight: bold;color: #777;margin:0 0 5px 0;">
											    رقم الشركة :  ${data[0].CompanyPhone}
										  </p>
										  <p class="small" style="margin: 0;"> عنوان الشركة : ${data[0].CompanyAddress}</p>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <img
											src="../../../${data[0].CompanyImage}"
											width="100" alt="">
										  <h5 style="font-size: 18px;margin:5px 0;"> اسم الشركة : ${data[0].CompanyName}</h5>

										</td>
									  </tr>
									</tbody>
								  </table>
								</td>
							  </tr>
							</tbody>
						  </table>
						</td>
					  </tr>
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="640" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 20px;">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">
										  <h5 style="margin: 0;">
											<span style="margin: 0 15px;">رقم الفاتورة : </span>
											<span>${data[0].InvoiceNumber}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span style="margin: 0 15px;">تاريخ الفاتورة :</span>
											<span>${data[0].InvoiceDate}</span>
										  </h5>
										   <h5 style="margin: 0;">
											<span style="margin: 0 15px;">المخزن : </span>
											<span> ${data[0].StockName}</span>
										  </h5>
										   <h5 style="margin: 0;">
											<span style="margin: 0 15px;">المورد : </span>
											<span> ${data[0].SupplierName}</span>
										  </h5> 
										  <h5 style="margin: 0;">
											<span style="margin: 0 15px;">رقم التليفون للمورد  : </span>
											<span> ${data[0].SupplierPhone}</span>
										  </h5>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <h5 style="font-size: 18px;margin:5px 0;"> فاتورة مشتريات </h5>
										</td>
									  </tr>
									</tbody>
								  </table>
								</td>
							  </tr>
							</tbody>
						  </table>
						</td>
					  </tr>
					  <tr>
						<td align="center" dir="rtl">
						  <table class="mobileWidth borderd" width="640" cellspacing="0" cellpadding="0" style="margin-top: 50px;">
							<tbody>
							  <tr style="border: 1px solid #000;background-color: #a0a0a0;">
								<th class="bold small" style="text-align: right;height: 25px;">الصنف</th>
								<th class="bold small" style="text-align: right;height: 25px;">الباركود</th>
								<th class="bold small" style="text-align: right;height: 25px;">الوحدة</th>
								<th class="bold small" style="text-align: right;height: 25px;">سعر الشراء</th>
								<th class="bold small" style="text-align: right;height: 25px;">الكمية</th>
								<th class="bold small" style="text-align: right;height: 25px;">المجموع</th>
							  </tr>
							 `);
		if (data[0].InvoiceDetails.length) {
			data[0].InvoiceDetails.forEach((detail) => {
				console.log(detail)
				a.document.write(
					`
								  <tr>
													<td>${detail.UnitJsonDto[0].ProductJsonDto[0].ProductName}</td>
													<td>${detail.UnitJsonDto[0].ProductJsonDto[0].ProductParcode}</td>
													<td>${detail.UnitJsonDto[0].UnitName}</td>
													<td>${detail.ProductPurchasingPrice}</td>
													<td>${detail.ProductQty}</td>
													<td>${detail.ProductTotalQtyPrice}</td>
								
								 </tr>
								`
				)
			});
		} else {
			a.document.write(`
							<tr>
								<td colspan="7">لاتوجد بيانات</td>
								</tr>
							`);
		}

		a.document.write(`
							</tbody>
						  </table>
						</td>
					  </tr>
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="640" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 45px;">
									<tbody>
									  <tr dir="rtl">
										<td width="135" align="left"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <h5 style="font-size: 18px;margin:5px 0; border-bottom: 1px solid;">
											<span style="float: right;">الإجمالي : </span>
											<span class="normal small">${data[0].InvoiceTotalPrice}</span>
										  </h5>
										  <h5 style="font-size: 18px;margin:5px 0; border-bottom: 1px solid;">
											<span style="float: right;">المدفوع:</span>
											<span class="normal small">${data[0].TotalPaid}</span>
										  </h5>
										   <h5 style="font-size: 18px;margin:5px 0; border-bottom: 1px solid;">
											<span style="float: right;">الباقي:</span>
											<span class="normal small">${data[0].Remainning}</span>
										  </h5>
										</td>
										<td width="135" align="center"></td>
										<td width="135" align="right"></td>
									  </tr>
									</tbody>
								  </table>
								</td>
							  </tr>
							</tbody>
						  </table>
						</td>
					  </tr>
					</tbody>
					</table>
				  </div>
					`
		);
		a.document.write('</body></html>');
		a.document.close();
		a.print();
	}
}

function printAtEnd(data) {
	console.log(data);
	if (data) {
		var a = window.open('', '', 'height=1200, width=1200');
		a.document.write('<html>');
		a.document.write('<body >');
		a.document.write(
			`
				<div id="GFG"">
					<table width=" 100%" align="center" cellpadding="0" cellspacing="0">
					<tbody>
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="640" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">
										  <p class="small"
											style="width:fit-content;font-size: 12px;font-weight: bold;color: #777;margin:0 0 5px 0;">
											   : رقم الشركة ${data?.CompanyPhone}
										  </p>
										  <p class="small" style="margin: 0;"> عنوان الشركة : ${data?.CompanyAddress}</p>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <img
											src="../../../${data?.CompanyImage}"
											width="100" alt="">
										  <h5 style="font-size: 18px;margin:5px 0;"> اسم الشركة : ${data?.CompanyName}</h5>

										</td>
									  </tr>
									</tbody>
								  </table>
								</td>
							  </tr>
							</tbody>
						  </table>
						</td>
					  </tr>
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="640" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 20px;">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">
										  <h5 style="margin: 0;">
											<span style="margin: 0 15px;">التاريخ </span>
											<span>${data?.CurrentDate}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span style="margin: 0 15px;">بداية الوردية </span>
											<span>${data?.StartDate}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span style="margin: 0 15px;">نهاية الوردية </span>
											<span>${data?.EndDate}</span>
										  </h5>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <h5 style="font-size: 18px;margin:5px 0;text-align:right;"> تقرير إجمالي مبيعات اليوم </h5>
										  <h5 style="margin: 0;">
											<span >اسم الكاشير</span>
											<span style="margin: 0 15px;">${data?.Name}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span >إجمالي المبيعات</span>
											<span style="margin: 0 15px;">${data?.TotalMoney}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span >إجمالي المدفوعات</span>
											<span style="margin: 0 15px;">${data?.TotalPaid}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span >إجمالي المرتجعات</span>
											<span style="margin: 0 15px;">${data?.TotalMoneyForThrowback}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span >إجمالي المنتجات المباعة</span>
											<span style="margin: 0 15px;">${data?.NumOfSaleProducts}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span>إجمالي المنتجات المرتجعة</span>
											<span style="margin: 0 15px;">${data?.NumOfThrowbackProducts}</span>
										  </h5>
										</td>
									  </tr>
									</tbody>
								  </table>
								</td>
							  </tr>
							</tbody>
						  </table>
						</td>
					  </tr>
					  
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="640" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 45px;">
									<tbody>
									  <tr dir="rtl">
										<td width="135" align="left"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <h5 style="font-size: 18px;margin:5px 0; border-bottom: 1px solid;">
											<span style="float: right;">إجمالي مبلغ عمليات اليوم:</span>
											<span class="normal small">${data.TotalMoney}</span>
										  </h5>
										  
										</td>
										<td width="135" align="center"></td>
										<td width="135" align="right"></td>
									  </tr>
									</tbody>
								  </table>
								</td>
							  </tr>
							</tbody>
						  </table>
						</td>
					  </tr>
					</tbody>
					</table>
				  </div>
					`
		);
		a.document.write('</body></html>');
		a.document.close();
		a.print();
	}

	
}