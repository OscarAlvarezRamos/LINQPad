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

Sub Main


	Dim tmp_staff = From s In Staff.AsEnumerable
		Group Join r1 In Staff.AsEnumerable On s.Reports_to Equals r1.Staff_id Into child1 = Group
	            From sup In child1.DefaultIfEmpty.AsEnumerable
				Where s.always_show = "Y"
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
			.description = i.description.trim()	
			}
				
				
	
	
	
	Dim qry = (
	From investigation In tmp_investigation.AsEnumerable
	Group Join r1 In tmp_staff On investigation.officer_code Equals r1.staff_id Into child1 = Group
	From staff In child1.DefaultIfEmpty
	Group Join r2 In tmp_sentence On investigation.case_defendant_id Equals r2.case_defendant_id Into child2 = Group
	From sentence In child2.DefaultIfEmpty
	Select
	lcd_id = investigation.lcd_id,
	invest_id = investigation.invest_id,
	investigation_client_id = investigation.investigation_client_id,
	pinvest_type = investigation.pinvest_type,
	invest_type = investigation.invest_type,
	prob_pts = investigation.prob_pts,
	date_assigned = investigation.date_assigned,
	due_date = investigation.due_date,
	date_submitted = investigation.date_submitted,
	case_defendant_id = investigation.case_defendant_id,
	pacts_case_no = investigation.pacts_case_no,
	case_id = investigation.case_id,
	case_defendant_client_id = investigation.case_defendant_client_id,
	pacts_no = investigation.case_defendant_client_id,
	divoff_code = investigation.divoff_code,
	year = investigation.year,
	case_type = investigation.case_type,
	docket = investigation.docket,
	officer_code = investigation.officer_code,
	description = investigation.description,
	cs_casenumber = String.Format("{0}:{1}-{2}-{3}", investigation.divoff_code, Microsoft.VisualBasic.Right(investigation.year, 2), investigation.case_type, investigation.docket),
	defendant_no = investigation.defendant_no,
	staff_id = If(staff Is Nothing, 0, staff.staff_id),
	sentence_id = If(sentence Is Nothing, Nothing, sentence.sentence_id.ToString),
	uspo_name = If(staff Is Nothing, Nothing, staff.uspo_name),
	uspo_email = If(staff Is Nothing, Nothing, staff.uspo_email),
	supervisor_name = If(staff Is Nothing, Nothing, staff.supervisor_name),
	supervisor_email = If(staff Is Nothing, Nothing, staff.supervisor_email)
	).Where(Function(x) (
							x.sentence_id Is Nothing And
							x.uspo_email <> "" And
							x.uspo_name <> "" And
							x.supervisor_email <> "" And
							x.supervisor_name <> ""
							))
						
						
qry.dump()
	

            Dim n As Integer = 0
			Dim cut_off_date As System.DateTime 
			
			
            For Each lvl1 In qry
				n += 1
				
                cut_off_date = {lvl1.date_assigned, #01/26/2014#}.Max()				
				
'				String.format("{0} {1}   {2}",lvl1.cs_casenumber,lvl1.defendant_no,cut_off_date).dump()
				
				
			Next
'			n.dump()
	
	
	
	
	
	
End Sub

' Define other methods and classes here
