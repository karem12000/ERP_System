
function printDiv(data) {
	console.log(data);
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
											src="${data[0].CompanyImageFullPath}"
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
								<th class="bold small" style="text-align: right;height: 25px;">سعر الوحدة</th>
								<th class="bold small" style="text-align: right;height: 25px;">الكمية</th>
								<th class="bold small" style="text-align: right;height: 25px;">سعر البيع</th>
								<th class="bold small" style="text-align: right;height: 25px;">نوع الخصم</th>
								<th class="bold small" style="text-align: right;height: 25px;">الخصم</th>
								<th class="bold small" style="text-align: right;height: 25px;">الإجمالي</th>
							  </tr>
							  <tr>
								<td>صنف تجريبي</td>
								<td>100.00</td>
								<td>10</td>
								<td>10%</td>
								<td>9000</td>
							  </tr>
							  <tr>
								<td>صنف تجريبي</td>
								<td>100.00</td>
								<td>10</td>
								<td>10%</td>
								<td>9000</td>
							  </tr>
							  <tr>
								<td>صنف تجريبي</td>
								<td>100.00</td>
								<td>10</td>
								<td>10%</td>
								<td>9000</td>
							  </tr>
							  <tr>
								<td>صنف تجريبي</td>
								<td>100.00</td>
								<td>10</td>
								<td>10%</td>
								<td>9000</td>
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
											<span style="float: right;"> الخصم:</span>
											<span class="normal small">${data[0].InvoiceTotalDiscount}</span>
										  </h5>
										   <h5 style="font-size: 18px;margin:5px 0; border-bottom: 1px solid;">
											<span style="float: right;"> نوع الخصم:</span>
											<span class="normal small">${data[0].InvoiceDisscountTypeStr}</span>
										  </h5>
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

function printParchase(data) {
	console.log(data);
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
											src="${data[0].CompanyImageFullPath}"
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
								<th class="bold small" style="text-align: right;height: 25px;">باركود الصنف</th>
								<th class="bold small" style="text-align: right;height: 25px;">اسم الصنف</th>
								<th class="bold small" style="text-align: right;height: 25px;">الوحدة</th>
								<th class="bold small" style="text-align: right;height: 25px;">الكمية</th>
								<th class="bold small" style="text-align: right;height: 25px;">سعر الشراء</th>
								<th class="bold small" style="text-align: right;height: 25px;">المجموع</th>
							  </tr>
							  <tr>
								<td>1111</td>
								<td>صنف تجريبي</td>
								<td>كيلوجرام</td>
								<td>10</td>
								<td>120</td>
								<td>1200</td>
							  </tr>
							 <tr>
								<td>1111</td>
								<td>صنف تجريبي</td>
								<td>كيلوجرام</td>
								<td>10</td>
								<td>120</td>
								<td>1200</td>
							  </tr>
							 <tr>
								<td>1111</td>
								<td>صنف تجريبي</td>
								<td>كيلوجرام</td>
								<td>10</td>
								<td>120</td>
								<td>1200</td>
							  </tr>
							 <tr>
								<td>1111</td>
								<td>صنف تجريبي</td>
								<td>كيلوجرام</td>
								<td>10</td>
								<td>120</td>
								<td>1200</td>
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

function printAtEnd(data) {
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
											   : رقم الشركة ${data.CompanyPhone}
										  </p>
										  <p class="small" style="margin: 0;"> عنوان الشركة : ${data.CompanyAddress}</p>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <img
											src="${data.CompanyImagePath}"
											width="100" alt="">
										  <h5 style="font-size: 18px;margin:5px 0;"> اسم الشركة : ${data.CompanyName}</h5>

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
											<span>${data.CurrentDate}</span>
										  </h5>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <h5 style="font-size: 18px;margin:5px 0;"> تقرير إجمالي مبيعات اليوم </h5>
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