<Query Kind="VBStatements">
  <Connection>
    <ID>155261b5-f277-46fd-b6e3-ebe68984192c</ID>
    <Persist>true</Persist>
    <Server>prd-sql-cludb.prd.circ1.dcn</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAPaDggjjBa0+MpLgY4BFySgAAAAACAAAAAAADZgAAwAAAABAAAAAgZYeXVnMnfPzRkPdAxcLvAAAAAASAAACgAAAAEAAAAOp6MEMe6CJkjImM6ydfzikQAAAArXQGXS/0vvnaebCsMA9x/BQAAAAbyDqpFqP8at6/ZM/YcDh024ASjw==</Password>
    <Database>USPO Docket Notify</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\LinqLib.dll</Reference>
  <Reference>D:\VBProjects\prd-assignment-dft\packages\System.DirectoryServices.Linq.1.2.2.1\lib\net45\System.DirectoryServices.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\System.Linq.Dynamic.dll</Reference>
  <Namespace>LinqLib.Array</Namespace>
  <Namespace>LinqLib.DynamicCodeGenerator</Namespace>
  <Namespace>LinqLib.Operators</Namespace>
  <Namespace>LinqLib.Sequence</Namespace>
  <Namespace>LinqLib.Sort</Namespace>
</Query>

Dim qry = From s In supervisions.asenumerable
	Group Join r1 In staff.asenumerable On s.officer_code Equals r1.staff_id Into child1 = Group
	From uspo In child1.DefaultIfEmpty.AsEnumerable
	Group Join r2 In staff.asenumerable On uspo.reports_to Equals r2.staff_id Into child2 = Group
	From sup In child2.defaultifempty.asenumerable
	Where uspo.Always_show = "Y"
	Select New With
		{
			.id = s.supervision_id,
			.pacts_no = s.client_id.trim(),
			.supervision_type = s.supervision_type.trim(),
			.supervision_description = s.supervision_type_description.trim(),
			.assign_date = s.assign_date,
			.case_number = String.format("{0}:{1}-{2}-{3}" ,
				If(s.divoff_code Is Nothing , "" , s.divoff_code.trim()) ,
				If(s.year Is Nothing , "" ,  Microsoft.VisualBasic.right( s.year.trim()  ,2)  ),
				If(s.case_type Is Nothing , "" , s.case_type.trim()) ,
				If(s.docket Is Nothing , "" , s.docket.trim())),
			.defendant_no = s.defendant_no,
			.uspo_id = s.officer_code,
			.uspo_fullname = If( uspo.last_name Is Nothing , "" , 
				String.format("{0}, {1} {2}"  , 
					If(uspo.last_name Is Nothing , "" , uspo.last_name.trim()),
					If(uspo.first_name Is Nothing , "" , uspo.first_name.trim()),
					If(uspo.middle_name Is Nothing , "" , uspo.middle_name.trim())
					)
				),
			.uspo_email = If(uspo.email Is Nothing , "" , uspo.email.trim()),
			.super_id = sup.staff_id,
			.super_fullname = If( sup.last_name Is Nothing , "" , 
				String.format("{0}, {1} {2}"  , 
					If(sup.last_name Is Nothing , "" , sup.last_name.trim()),
					If(sup.first_name Is Nothing , "" , sup.first_name.trim()),
					If(sup.middle_name Is Nothing , "" , sup.middle_name.trim())
					)
				),
			.super_email = If(sup.email Is Nothing , "" , sup.email.trim())
			}




'qry = qry.where(Function(x)(x.uspo_email <> "" And x.super_email <> "" And x.assign_date Isnot Nothing)).orderby(Function(x)(x.super_email)).thenBy(Function(x)(x.uspo_email))

'qry = qry.orderby(Function(x)(x.pacts_no))
qry.dump()