<Query Kind="VBStatements">
  <Connection>
    <ID>155261b5-f277-46fd-b6e3-ebe68984192c</ID>
    <Persist>true</Persist>
    <Server>prd-sql-cludb.prd.circ1.dcn</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAPaDggjjBa0+MpLgY4BFySgAAAAACAAAAAAADZgAAwAAAABAAAAAgZYeXVnMnfPzRkPdAxcLvAAAAAASAAACgAAAAEAAAAOp6MEMe6CJkjImM6ydfzikQAAAArXQGXS/0vvnaebCsMA9x/BQAAAAbyDqpFqP8at6/ZM/YcDh024ASjw==</Password>
    <Database>Attorney Fees</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
  <Reference>D:\VBProjects\electronic-court-calendar\scripts\objects\InformixService.dll</Reference>
  <Reference>D:\VBProjects\electronic-court-calendar\electronic-court-calendar\Bin\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-fees\prd-fees\Bin\System.Linq.Dynamic.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System.Linq.Dynamic</Namespace>
</Query>

'Dim tmp1 = From p In persons
'Select New With 
'{
'	.pr_prid = p.Pr_prid,
'	.pr_type = p.Pr_type,
'	.pr_retrieve_code = p.Pr_retrieve_code,
'	.pr_first_name = p.Pr_first_name,
'	.pr_middle_name = p.Pr_middle_name,
'	.pr_fullname = p.Pr_fullname,
'	.pr_last_name = p.Pr_last_name,
'	.pr_address1 = p.Pr_address1,
'	.pr_address2 = p.Pr_address2,
'	.pr_address3 = p.Pr_address3,
'	.pr_city = p.Pr_city,
'	.pr_state = p.Pr_state,
'	.pr_fulladdress = p.Pr_address1+" "+p.Pr_address2+ " "+p.Pr_address3+" "+ p.Pr_city+" "+ p.Pr_state,
'	.pr_zip = p.Pr_zip,
'	.pr_county = p.Pr_county,
'	.pr_country = p.Pr_country,
'	.pr_e_mail = p.Pr_e_mail,
'	.pr_create_date = p.Pr_create_date,
'	.bm_admission_date = p.Bm_admission_date,
'	.pr_status_override = p.Pr_status_override,
'	.pr_attorney_cert_type = p.Pr_attorney_cert_type, 
'	.pr_attorney_cert_date = p.Pr_attorney_cert_date,
'	.key1 = p.Key1,
'	.pmt_receipt_number = (
'			From p1 In payments 
'			Where p1.pmt_pr_prid = p.Pr_prid 
'			Order By p1.pmt_id Descending 
'			Take 1 
'			Select p1.pmt_receipt_number ).FirstOrDefault(),
'	.payments = (From pmt In payments Where pmt.pmt_pr_prid = p.Pr_prid
'			Order By pmt.pmt_id	
'			Select New With 
'			{
'			.pmt_id = pmt.Pmt_id,
'			.pmt_pr_prid = pmt.Pmt_pr_prid,
'			.pmt_year_paid = pmt.Pmt_year_paid,
'			.pmt_payment_amount = pmt.Pmt_payment_amount,
'			.pmt_receipt_number = pmt.Pmt_receipt_number,
'			.pmt_attorney_status = pmt.Pmt_attorney_status,
'			.pmt_remarks = pmt.Pmt_remarks,
'			.pmt_sysdate = pmt.Pmt_sysdate
'			})
'}
'tmp1.dump()



Dim tmp2 = From p In persons
Let var1 = (From pmt In payments Where pmt.pmt_pr_prid = p.Pr_prid
			Order By pmt.pmt_id	Descending
			Take 1
			Select New With 
			{
			.pmt_id = pmt.Pmt_id,
			.pmt_pr_prid = pmt.Pmt_pr_prid,
			.pmt_year_paid = pmt.Pmt_year_paid,
			.pmt_payment_amount = pmt.Pmt_payment_amount,
			.pmt_receipt_number = pmt.Pmt_receipt_number,
			.pmt_attorney_status = pmt.Pmt_attorney_status,
			.pmt_remarks = pmt.Pmt_remarks,
			.pmt_sysdate = pmt.Pmt_sysdate
			})
From pmt_last In var1.defaultifempty
Select New With 
{
	.pr_prid = p.Pr_prid,
	.pr_type = p.Pr_type,
	.pr_retrieve_code = p.Pr_retrieve_code,
	.pr_first_name = p.Pr_first_name,
	.pr_middle_name = p.Pr_middle_name,
	.pr_fullname = p.Pr_fullname,
	.pr_last_name = p.Pr_last_name,
	.pr_address1 = p.Pr_address1,
	.pr_address2 = p.Pr_address2,
	.pr_address3 = p.Pr_address3,
	.pr_city = p.Pr_city,
	.pr_state = p.Pr_state,
	.pr_fulladdress = p.Pr_address1+" "+p.Pr_address2+ " "+p.Pr_address3+" "+ p.Pr_city+" "+ p.Pr_state,
	.pr_zip = p.Pr_zip,
	.pr_county = p.Pr_county,
	.pr_country = p.Pr_country,
	.pr_e_mail = p.Pr_e_mail,
	.pr_create_date = p.Pr_create_date,
	.bm_admission_date = p.Bm_admission_date,
	.pr_status_override = p.Pr_status_override,
	.pr_attorney_cert_type = p.Pr_attorney_cert_type, 
	.pr_attorney_cert_date = p.Pr_attorney_cert_date,
	.key1 = p.Key1,
	.pmt_year_paid = pmt_last.pmt_year_paid,
	.pmt_payment_amount = pmt_last.pmt_payment_amount
}
	
	
tmp2.dump()




'
'Dim tmp3 As String = (From p In payments.AsEnumerable 
'Where p.pmt_pr_prid = 190789
'Order By p.pmt_id).Aggregate(
'New System.Text.StringBuilder, 
'Function(cur, nxt) cur.AppendFormat(", {0}", nxt.Pmt_remarks.ToString)
').ToString.substring(2)
'
'tmp3.dump()
'
'
'Dim tmp4 = (From p In payments.AsEnumerable Where p.pmt_pr_prid = 190789)
'
'tmp4.dump()
'
'



