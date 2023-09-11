
function printDiv(data) {
	console.log(data);
	if (data) {
		var a = window.open('', '', 'height=600, width=600');


		a.document.write('<html>');
		a.document.write(
			`
			<style>
			.borderd table,.borderd th,.borderd td {
			  border:1px solid black;
			}
			</style>
			`
		);
		a.document.write('<body style="margin:0;padding:0;">');
		a.document.write(
			`
				<div id="GFG"">
					<table width=" 100%" align="center" cellpadding="0" cellspacing="0">
					<tbody style="zoom: 1;height: fit-content;">
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0">
									<tbody>
									  <tr>
										  <td colspan="2" width="100%" align="right">
											<h5 style="font-size: 18px;margin:5px 0;padding:5px;border:1px solid #000;border-radius:5px;text-align:center;">${data[0]?.CompanyName}</h5>
										  </td>
									  </tr>
									  <tr>
										<td class="mobileHeader" align="left">
										  <span class="small" > ${data[0]?.CompanyAddress}</span>
										</td>
										<td class="mobileHeader" align="right">
										  <span class="small" >${data[0]?.CompanyPhone}</span>
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
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 20px;">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">
										  <h5 style="margin: 0;">
											<span># ${data[0]?.InvoiceNumber}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span>${data[0]?.InvoiceDate}</span>
										  </h5>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;">
										  <h5 style="font-size: 18px;margin:5px 0;"> فاتورة مبيعات </h5>
										  <h5 style="margin: 0;">
											<span> ${data[0]?.StockName}</span>
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
						<td align="center" dir="rtl">
						  <table class="mobileWidth borderd" width="100%" cellspacing="0" cellpadding="0" style="margin-top: 50px;">
							<tbody>

							  <tr style="border: 1px solid #000;background-color: #a0a0a0;zoom:0.8;">
								<th colspan="3" style="text-align: right;height: 25px;font-size: 18px;padding: 0 5px;">الصنف</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">السعر</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">الكمية</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">الخصم</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">الإجمالي</th>
							  </tr>

							  `);
		if (data[0].InvoiceDetails.length) {
			data[0].InvoiceDetails.forEach((detail) => {
				a.document.write(
					`
			  <tr style="zoom:0.8;">
								<td colspan="3" style="font-size: 18px;padding: 0 5px;">${detail.UnitJsonDto[0]?.ProductJsonDto[0]?.ProductName}</td>
								<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductSellingPrice}</td>
								<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductQty}</td>
								<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductDisscount} ${detail.ProductDiscountTypeStr}</td>
								<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductTotalQtyPrice}</td>
								
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
				<table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
					<tbody >
						<tr>
							<td>
								<table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 45px;">
									<tbody>
										<tr dir="rtl">
											<td width="75%" colspan="2" align="left"
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
											<td width="270" align="center"></td>
											<td width="270" align="right"></td>
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
		a.onfocus = function () { setTimeout(function () { a.close(); }, 500); }

	}
}
function printSaleThroback(data) {
	console.log(data);
	if (data) {
		var a = window.open('', '', 'height=600, width=600');

		a.document.write('<html>');
		a.document.write(
			`
			<style>
			.borderd table,.borderd th,.borderd td {
			  border:1px solid black;
			}
			</style>
			`
		);
		a.document.write('<body style="margin:0;padding:0;">');
		a.document.write(
			`
				<div id="GFG"">
					<table width=" 100%" align="center" cellpadding="0" cellspacing="0">
					<tbody style="zoom: 1;height: fit-content;">
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0">
									<tbody>
									  <tr>
										  <td colspan="2" width="100%" align="right">
											<h5 style="font-size: 18px;margin:5px 0;padding:5px;border:1px solid #000;border-radius:5px;text-align:center;">${data[0]?.CompanyName}</h5>
										  </td>
									  </tr>
									  <tr>
										<td class="mobileHeader" align="left">
										  <span class="small" > ${data[0]?.CompanyAddress}</span>
										</td>
										<td class="mobileHeader" align="right">
										  <span class="small" >${data[0]?.CompanyPhone}</span>
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
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 20px;">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">
										  <h5 style="margin: 0;">
											<span># ${data[0]?.InvoiceNumber}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span>${data[0]?.InvoiceDate}</span>
										  </h5>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <h5 style="font-size: 18px;margin:5px 0;"> مرتجع فاتورة مبيعات </h5>
										  <h5 style="margin: 0;">
											<span> ${data[0]?.StockName}</span>
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
						<td align="center" dir="rtl">
						  <table class="mobileWidth borderd" width="100%" cellspacing="0" cellpadding="0" style="margin-top: 50px;">
							<tbody>

							  <tr style="border: 1px solid #000;background-color: #a0a0a0;zoom:0.8;">
								<th colspan="3" style="text-align: right;height: 25px;font-size: 18px;padding: 0 5px;">الصنف</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">السعر</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">الكمية</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">الخصم</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">الإجمالي</th>
							  </tr>

							  `);
		if (data[0].InvoiceDetails.length) {
			data[0].InvoiceDetails.forEach((detail) => {
				a.document.write(
					`
			  <tr style="zoom:0.8;">
								<td colspan="3" style="font-size: 16px;padding: 0 5px;">${detail.UnitJsonDto[0]?.ProductJsonDto[0]?.ProductName}</td>
								<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductSellingPrice}</td>
								<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductQty}</td>
								<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductDisscount} ${detail.ProductDiscountTypeStr}</td>
								<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductTotalQtyPrice}</td>
								
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
				<table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
					<tbody >
						<tr>
							<td>
								<table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 45px;">
									<tbody>
										<tr dir="rtl">
											<td width="75%" colspan="2" align="left"
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
											<td width="270" align="center"></td>
											<td width="270" align="right"></td>
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
		a.onfocus = function () { setTimeout(function () { a.close(); }, 500); }
	}
}
function printParchase(data) {
	console.log(data);
	if (data) {
		var a = window.open('', '', 'height=600, width=600');
		a.document.write('<html>');
		a.document.write(
			`
			<style>
			.borderd table,.borderd th,.borderd td {
			  border:1px solid black;
			}
			</style>
			`
		);
		a.document.write('<body style="margin:0;padding:0;">');
		a.document.write(
			`
				<div id="GFG"">
					<table width=" 100%" align="center" cellpadding="0" cellspacing="0">
					<tbody style="zoom: 1;height: fit-content;">
					 <tr>
						<td align="center">
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0">
									<tbody>
									  <tr>
										  <td colspan="2" width="100%" align="right">
											<h5 style="font-size: 18px;margin:5px 0;padding:5px;border:1px solid #000;border-radius:5px;text-align:center;">${data[0]?.CompanyName}</h5>
										  </td>
									  </tr>
									  <tr>
										<td class="mobileHeader" align="left">
										  <span class="small" > ${data[0]?.CompanyAddress}</span>
										</td>
										<td class="mobileHeader" align="right">
										  <span class="small" >${data[0]?.CompanyPhone}</span>
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
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 20px;">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">
										  <h5 style="margin: 0;">
											<span># ${data[0]?.InvoiceNumber}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span>${data[0]?.InvoiceDate}</span>
										  </h5>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <h5 style="font-size: 18px;margin:5px 0;"> فاتورة مشتريات </h5>
										  <h5 style="margin: 0;">
											<span> ${data[0]?.StockName}</span>
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
						<td align="center" dir="rtl">
						  <table class="mobileWidth borderd" width="100%" cellspacing="0" cellpadding="0" style="margin-top: 50px;">
							<tbody>
							  <tr style="border: 1px solid #000;background-color: #a0a0a0;zoom:0.8;">
								<th colspan="3" style="text-align: right;height: 25px;font-size: 16px;padding: 0 5px;">الصنف</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">سعر الشراء</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">الكمية</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">المجموع</th>
							  </tr>
							 `);
		if (data[0].InvoiceDetails.length) {
			data[0].InvoiceDetails.forEach((detail) => {
				console.log(detail)
				a.document.write(
					`
								  <tr style="zoom:0.8;">
													<td colspan="3" style="font-size: 16px;padding: 0 5px;">${detail.UnitJsonDto[0].ProductJsonDto[0].ProductName}</td>
													<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductPurchasingPrice}</td>
													<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductQty}</td>
													<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductTotalQtyPrice}</td>
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
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 45px;">
									<tbody>
									  <tr dir="rtl">
										<td width="75%" colspan="2" align="left"
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
										<td width="270" align="center"></td>
										<td width="270" align="right"></td>
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
		a.onfocus = function () { setTimeout(function () { a.close(); }, 500); }
	}
}

function printParchaseThrowback(data) {
	console.log(data);
	if (data) {
		var a = window.open('', '', 'height=600, width=600');
		a.document.write('<html>');
		a.document.write(
			`
			<style>
			.borderd table,.borderd th,.borderd td {
			  border:1px solid black;
			}
			</style>
			`
		);
		a.document.write('<body style="margin:0;padding:0;">');
		a.document.write(
			`
				<div id="GFG"">
					<table width=" 100%" align="center" cellpadding="0" cellspacing="0">
					<tbody style="zoom: 1;height: fit-content;">
					 <tr>
						<td align="center">
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0">
									<tbody>
									  <tr>
										  <td colspan="2" width="100%" align="right">
											<h5 style="font-size: 18px;margin:5px 0;padding:5px;border:1px solid #000;border-radius:5px;text-align:center;">${data[0]?.CompanyName}</h5>
										  </td>
									  </tr>
									  <tr>
										<td class="mobileHeader" align="left">
										  <span class="small" > ${data[0]?.CompanyAddress}</span>
										</td>
										<td class="mobileHeader" align="right">
										  <span class="small" >${data[0]?.CompanyPhone}</span>
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
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 20px;">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">
										  <h5 style="margin: 0;">
											<span># ${data[0]?.InvoiceNumber}</span>
										  </h5>
										  <h5 style="margin: 0;">
											<span>${data[0]?.InvoiceDate}</span>
										  </h5>
										</td>
										<td class="mobileHeader" width="135" align="right"
										  style="overflow:hidden;padding-right:22px;border-radius: 0 0 30px 0px">
										  <h5 style="font-size: 18px;margin:5px 0;"> مرتجع فاتورة مشتريات </h5>
										  <h5 style="margin: 0;">
											<span> ${data[0]?.StockName}</span>
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
						<td align="center" dir="rtl">
						  <table class="mobileWidth borderd" width="100%" cellspacing="0" cellpadding="0" style="margin-top: 50px;">
							<tbody>
							  <tr style="border: 1px solid #000;background-color: #a0a0a0;zoom:0.8;">
								<th colspan="3" style="text-align: right;height: 25px;font-size: 16px;padding: 0 5px;">الصنف</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">سعر الشراء</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">الكمية</th>
								<th colspan="1" style="text-align: right;height: 25px;font-size: 12px;padding: 0 5px;">المجموع</th>
							  </tr>
							 `);
		if (data[0].InvoiceDetails.length) {
			data[0].InvoiceDetails.forEach((detail) => {
				console.log(detail)
				a.document.write(
					`
								  <tr style="zoom:0.8;">
													<td colspan="3" style="font-size: 16px;padding: 0 5px;">${detail.UnitJsonDto[0].ProductJsonDto[0].ProductName}</td>
													<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductPurchasingPrice}</td>
													<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductQty}</td>
													<td colspan="1" style="font-size: 12px;padding: 0 5px;">${detail.ProductTotalQtyPrice}</td>
								
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
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 45px;">
									<tbody>
									  <tr dir="rtl">
										<td width="75%" colspan="2" align="left"
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
										<td width="270" align="center"></td>
										<td width="270" align="right"></td>
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
		a.onfocus = function () { setTimeout(function () { a.close(); }, 500); }
	}
}

function printAtEnd(data) {
	console.log(data);
	if (data) {
		var a = window.open('', '', 'height=600, width=600');
		a.document.write('<html>');
		a.document.write(
			`
			<style>
			.borderd table,.borderd th,.borderd td {
			  border:1px solid black;
			}
			</style>
			`
		);
		a.document.write('<body style="margin:0;padding:0;">');
		a.document.write(
			`
				<div id="GFG"">
					<table width=" 100%" align="center" cellpadding="0" cellspacing="0">
					<tbody style="zoom: 1;height: fit-content;">
					  <tr>
						<td align="center">
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0">
									<tbody>
									  <tr>
										  <td colspan="2" width="100%" align="right">
											<h5 style="font-size: 18px;margin:5px 0;padding:5px;border:1px solid #000;border-radius:5px;text-align:center;">${data[0]?.CompanyName}</h5>
										  </td>
									  </tr>
									  <tr>
										  <td colspan="2" width="100%" align="right">
											<h5 style="font-size: 18px;margin:5px 0;padding:5px;border:1px solid #000;border-radius:5px;text-align:center;">تقرير إجمالي مبيعات اليوم</h5>
										  </td>
									  </tr>
									  <tr>
										<td class="mobileHeader" align="left">
										  <span class="small" > ${data[0]?.CompanyAddress}</span>
										</td>
										<td class="mobileHeader" align="right">
										  <span class="small" >${data[0]?.CompanyPhone}</span>
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
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0" style="margin-top: 20px;">
									<tbody>
									<tr>
									<td colspan="2" align="left">
									<span>${data?.CurrentDate}</span>
									</td>
									<td colspan="2" align="right">
									<span style="margin: 10px 0;    display: inline-block;">التاريخ </span>
									</td>
									</tr>

									<tr>
									<td colspan="2" align="left">
									<span>${data?.StartDate}</span>
									</td>
									<td colspan="2" align="right">
									<span style="margin: 10px 0;    display: inline-block;">بداية الوردية </span>
									</td>
									</tr>

									<tr>
									<td colspan="2" align="left">
									<span>${data?.EndDate}</span>
									</td>
									<td colspan="2" align="right">
									<span style="margin: 10px 0;    display: inline-block;">نهاية الوردية </span>
									</td>
									</tr>

									<tr>
									<td colspan="2" align="left">
									<span style="margin: 10px 0;    display: inline-block;">${data?.Name}</span>
									</td>
									<td colspan="2" align="right">
									<span >اسم الكاشير</span>
									</td>
									</tr>

									<tr>
									<td colspan="2" align="left">
									<span style="margin: 10px 0;    display: inline-block;">${data?.TotalMoney}</span>
									</td>
									<td colspan="2" align="right">
									<span >إجمالي المبيعات</span>
									</td>
									</tr>

									<tr>
									<td colspan="2" align="left">
									<span style="margin: 10px 0;    display: inline-block;">${data?.TotalPaid}</span>
									</td>
									<td colspan="2" align="right">
									<span >إجمالي المدفوعات</span>
									</td>
									</tr>

									<tr>
									<td colspan="2" align="left">
									<span style="margin: 10px 0;    display: inline-block;">${data?.TotalMoneyForThrowback}</span>
									</td>
									<td colspan="2" align="right">
									<span >إجمالي المرتجعات</span>
									</td>
									</tr>

									<tr>
									<td colspan="2" align="left">
									<span style="margin: 10px 0;    display: inline-block;">${data?.NumOfSaleProducts}</span>
									</td>
									<td colspan="2" align="right">
									<span >إجمالي المنتجات المباعة</span>
									</td>
									</tr>

									<tr>
									<td colspan="2" align="left">
									<span >${data?.NumOfThrowbackProducts}</span>
									</td>
									<td colspan="2" align="right">
									<span>إجمالي المنتجات المرتجعة</span>
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
						  <table class="mobileWidth" width="100%" cellspacing="0" cellpadding="0">
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
		a.onfocus = function () { setTimeout(function () { a.close(); }, 500); }
	}

	
}