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

Dim tmp_staff = From s In Staff.AsEnumerable
	Group Join r1 In Staff.AsEnumerable On s.Reports_to Equals r1.Staff_id Into child1 = Group
            From sup In child1.DefaultIfEmpty.AsEnumerable
			Select New With {
				.staff_id = s.staff_id,
				.reports_to = s.Reports_to,
				.staff_type_cd = s.Staff_type_cd.trim(),
				.staff_type_description = s.Staff_type_description.trim(),
				.loc_code = s.Loc_code.trim(),
				.loc_description = s.Loc_description.trim(),
				.prob_or_pretrial = s.Prob_or_pretrial.trim(),
				.staff_func_type = If(s.Staff_func_type Is Nothing , "",s.Staff_func_type.trim()),
				.first_name = If(s.First_name Is Nothing , "" , s.First_name.trim()),
				.middle_name = If(s.Middle_name Is Nothing , "" , s.Middle_name.trim()),
				.last_name = If(s.last_name Is Nothing , "" , s.last_name.trim()),
				.staff_initials = If(s.Staff_initials Is Nothing , "" , s.Staff_initials.trim()),
				.title = If(s.Title Is Nothing,"",s.Title.trim()),
				.uspo_name = (String.Format("{0}, {1} {2}", If(s.last_name Is Nothing , "" , s.last_name.trim()), If(s.First_name Is Nothing , "" , s.First_name.trim()), If(s.Middle_name Is Nothing , "" , s.Middle_name.trim()))),
				.uspo_email = If(s.Email Is Nothing ,"",s.Email.trim()),
				.supervisor_name = If (sup Is Nothing , "", (String.Format("{0}, {1} {2}", If(sup.last_name Is Nothing , "" , sup.last_name.trim()), If(sup.First_name Is Nothing , "" , sup.First_name.trim()), If(sup.Middle_name Is Nothing , "" , sup.Middle_name.trim())))),
				.supervisor_email = If(sup Is Nothing , "" , If(sup.Email Is Nothing ,"",sup.Email.trim()))
				}
			
Dim tmp_sentence = From s In Sentences.AsEnumerable
	Select New With 
		{
			.sentence_id = s.Sentence_id,
			.case_defendant_id = s.Case_defendant_id
		}

Dim tmp_investigation = From i In investigations
	Select New With {
		.lcd_id = i.lcd_id.trim(),
		.invest_id  = i.invest_id,
		.investigation_client_id = i.investigation_client_id,
		.pinvest_type = i.pinvest_type.trim(),
		.invest_type = i.invest_type.trim(),
		.prob_pts = i.prob_pts.trim(),
		.date_assigned = i.date_assigned,
		.due_date = i.due_date,
		.date_submitted = i.date_submitted,
		.case_defendant_id = i.case_defendant_id,
		.defendant_no = i.defendant_no,
		.pacts_case_no = i.pacts_case_no.trim(),
		.case_id = i.case_id.trim(),
		.case_defendant_client_id = i.case_defendant_client_id.trim(),
		.divoff_code = i.divoff_code.trim(),
		.year = i.year.trim(),
		.case_type = i.case_type.trim(),
		.docket = i.docket.trim(),
		.officer_code = i.officer_code,
		.description = i.description	
		}
			
			
			
			
'
'
'            Dim tmp_investigation = From widget In ds.Tables!investigation
'                                    Select New With
'                                           {
'                                               .lcd_id = widget.Field(Of System.String)("lcd_id"),
'                                               .invest_id = widget.Field(Of Nullable(Of System.Int64))("invest_id"),
'                                               .investigation_client_id = widget.Field(Of Nullable(Of System.Int64))("investigation_client_id"),
'                                               .pinvest_type = widget.Field(Of System.String)("pinvest_type"),
'                                               .invest_type = widget.Field(Of System.String)("invest_type"),
'                                               .prob_pts = widget.Field(Of System.String)("prob_pts"),
'                                               .date_assigned = widget.Field(Of Nullable(Of System.DateTime))("date_assigned"),
'                                               .due_date = widget.Field(Of Nullable(Of System.DateTime))("due_date"),
'                                               .date_submitted = widget.Field(Of Nullable(Of System.DateTime))("date_submitted"),
'                                               .case_defendant_id = widget.Field(Of Nullable(Of System.Int64))("case_defendant_id"),
'                                               .defendant_no = widget.Field(Of Nullable(Of System.Int64))("defendant_no"),
'                                               .pacts_case_no = widget.Field(Of System.String)("pacts_case_no"),
'                                               .case_id = widget.Field(Of System.String)("case_id"),
'                                               .case_defendant_client_id = widget.Field(Of System.String)("case_defendant_client_id"),
'                                               .divoff_code = widget.Field(Of System.String)("divoff_code"),
'                                               .year = widget.Field(Of System.String)("year"),
'                                               .case_type = widget.Field(Of System.String)("case_type"),
'                                               .docket = widget.Field(Of System.String)("docket"),
'                                               .officer_code = widget.Field(Of Nullable(Of System.Int64))("officer_code"),
'                                               .description = widget.Field(Of System.String)("description")
'                                           }
'			





tmp_investigation.dump()