<Query Kind="VBProgram">
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



Function TryGetDate(value As String) As System.Nullable(Of DateTime)
	Dim d As DateTime
	Return If(DateTime.TryParse(value, d), d, Nothing)
End Function



Sub Main
	'Dim tmp1 As String() = {"aaa","bbb","ccc"}
	'Dim tmp2 As String() = {"aaa","bbb","ccc","ddd"}
	'Dim conc1 = (From a In tmp1 Select a ).concat(From a In tmp2 Select a)
	''conc1.dump()
	'
	
	
	Dim tmp1 = From a In supervisions.asenumerable
	                           Select New With {
	                               .supervision_id = a.Supervision_id,
	                               .assign_date = a.Assign_date,
	                               .close_date = a.Close_date,
	                               .pacts_no = a.Client_id.trim(),
	                               .divoff_code = If(a.Divoff_code Is Nothing , "" , a.Divoff_code.trim()),
	                               .year = If(a.year Is Nothing , "" , a.year.trim()),
	                               .case_type = If(a.case_type Is Nothing , "" , a.case_type.trim()),
	                               .docket = If(a.docket Is Nothing , "" , a.docket.trim()),
	                               .cs_casenumber = String.Format("{0}:{1}-{2}-{3}", If(a.Divoff_code Is Nothing, "", a.Divoff_code.Trim), If(a.Year Is Nothing, "", Microsoft.VisualBasic.Right(a.Year.Trim, 2)), If(a.Case_type Is Nothing, "", a.Case_type.Trim), If(a.Docket Is Nothing, "", a.Docket.Trim)),
	                               .defendant_no = a.Defendant_no,
	                               .officer_code = a.Officer_code,
	                               .last_name = If(a.last_name Is Nothing , "" , a.last_name.trim()),
	                               .first_name = If(a.first_name Is Nothing , "" , a.first_name.trim()),
	                               .middle_name = If(a.middle_name Is Nothing , "" , a.middle_name.trim()),
	                               .staff_initials = If(a.staff_initials Is Nothing , "" , a.staff_initials.trim()),
	                               .title = If(a.title Is Nothing , "" , a.title.trim()),
	                               .email = If(a.email Is Nothing , "" , a.email.trim().tolower()),
	                               .officer_full_name = If(a.officer_full_name Is Nothing , "" , a.officer_full_name.trim().tolower()),
	                               .reports_to = a.Reports_to
	                           }
	
	
	Dim tmp2 = From a In Pretrials.asenumerable
	Group Join r1 In staff On a.Staff_id   Equals r1.staff_id Into child1 = Group
	From s In child1.DefaultIfEmpty
	Select New With 
	{
		.supervision_id = a.Pretrial_id,
		.assign_date = a.begin_date,
		.close_date = a.Termination_date,
		.pacts_no = a.Pacts_no,
		.divoff_code = If(a.Divoff_code Is Nothing , "" , a.Divoff_code.trim()),
		.year = a.case_Year,
		.case_type = a.Case_type.trim().replace("MG","MJ"),
		.docket = a.case_number,
		.cs_casenumber = String.Format("{0}:{1}-{2}-{3}",a.Divoff_code.trim(),If (a.Case_type Is Nothing,Nothing ,Microsoft.VisualBasic.Right(a.case_year.Trim, 2) ),If(a.Case_type Is Nothing ,Nothing,a.Case_type.trim()),If(a.case_number Is Nothing , Nothing , a.case_number.trim())),
		.defendant_no = a.Defendant_number,
		.officer_code = a.Staff_id,
		.last_name = If (s Is Nothing , "" , If(s.Last_name Is Nothing,"",s.Last_name.trim())),
		.first_name = If (s Is Nothing , "" , If(s.first_name Is Nothing,"",s.first_name.trim())),
		.middle_name = If (s Is Nothing , "" , If(s.middle_name Is Nothing,"",s.middle_name.trim())),
		.staff_initials = If (s Is Nothing , "" , If(s.staff_initials Is Nothing,"",s.staff_initials.trim())),
		.title = If (s Is Nothing , "" , If(s.title Is Nothing,"",s.title.trim())),
		.email = If (s Is Nothing , "" , If(s.email Is Nothing,"",s.email.trim().tolower())),
		.officer_full_name = If(s Is Nothing , "",String.format("{0}, {1} {2}",If (s Is Nothing , "" , If(s.Last_name Is Nothing,"",s.Last_name.trim()))  , If (s Is Nothing , "" , If(s.first_name Is Nothing,"",s.first_name.trim())),If (s Is Nothing , "" , If(s.middle_name Is Nothing,"",s.middle_name.trim()))  )),
		.reports_to = s.reports_to
	}
	
	
	Dim oSupervision = (From a In tmp1
		Select a.supervision_id,
		a.assign_date,
		close_date = TryGetDate(a.close_date),
		a.pacts_no,
		a.divoff_code,
		a.year,
		a.case_type,
		a.docket,
		a.cs_casenumber,
		a.defendant_no,
		a.officer_code,
		a.last_name,
		a.first_name,
		a.middle_name,
		a.staff_initials,
		a.title,
		a.email,
		a.officer_full_name,
		a.reports_to
		).concat(From a In tmp2
		Select a.supervision_id,
		a.assign_date,
		a.close_date,
		a.pacts_no,
		a.divoff_code,
		a.year,
		a.case_type,
		a.docket,
		a.cs_casenumber,
		a.defendant_no,
		a.officer_code,
		a.last_name,
		a.first_name,
		a.middle_name,
		a.staff_initials,
		a.title,
		a.email,
		a.officer_full_name,
		a.reports_to)
	
'	oSupervision.dump()
	
	
	
	tmp2.dump()						   
	
	
	
	
End Sub

' Define other methods and classes here


