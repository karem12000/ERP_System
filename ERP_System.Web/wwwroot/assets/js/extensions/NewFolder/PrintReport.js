function printDiv() {
	var a = window.open('', '', 'height=1200, width=1200');
	var PrintedData = document.querySelector(".dataTables_scroll").innerHTML;
	a.document.write('<html>');
	a.document.write('<body >');
	a.document.write(
		`
				<div id="GFG"">
					<table width=" 100%" align="center" cellpadding="0" cellspacing="0">
					<tbody>
					  <tr>
						<td align="center" dir='rtl'>
						  <table class="mobileWidth" width="640" cellspacing="0" cellpadding="0">
							<tbody>
							  <tr>
								<td>
								  <table width="100%" cellspacing="0" cellpadding="0">
									<tbody>
									  <tr>
										<td class="mobileHeader" width="135" align="left">  
											${PrintedData}
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
					</tbody>
					</table>
				  </div>
					`
	);
	a.document.write('</body></html>');
	a.document.close();
	a.print();
}
