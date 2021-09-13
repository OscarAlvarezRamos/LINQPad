<Query Kind="VBStatements">
  <Connection>
    <ID>6e3f92df-80a3-4fd7-8c2c-c0cdc238133f</ID>
    <Persist>true</Persist>
    <Server>156.119.90.80</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>docket_usr</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXnMFePhfaEGdJEvMcFMiwQAAAAACAAAAAAADZgAAwAAAABAAAAB42R18UHa4Mi2Lt9pHNZH0AAAAAASAAACgAAAAEAAAAElEhCw+9+ECAH4dUQMnedkQAAAA1fN8ToZYA7B2vnCqmolVThQAAAClxV4Ia4fBiVbWzG9Z6j2qJCuhQA==</Password>
    <Database>Docket Notify</Database>
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


'
'
'Dim tmpStaff = From s In Staff.AsEnumerable
' Group Join r1 In Staff.AsEnumerable On s.Reports_to Equals r1.Staff_id Into child1 = Group
'            From sup In child1.DefaultIfEmpty.AsEnumerable
'   Select New With {
'    .staff_id = s.Staff_id,
'    .reports_to = s.Reports_to,
'    .staff_type_cd = s.Staff_type_cd.Trim(),
'    .staff_type_description = s.Staff_type_description.Trim(),
'    .loc_code = s.Loc_code.Trim(),
'    .loc_description = s.Loc_description.Trim(),
'    .prob_or_pretrial = s.Prob_or_pretrial.Trim(),
'    .staff_func_type = If(s.Staff_func_type Is Nothing, "", s.Staff_func_type.Trim()),
'    .first_name = If(s.First_name Is Nothing, "", s.First_name.Trim()),
'    .middle_name = If(s.Middle_name Is Nothing, "", s.Middle_name.Trim()),
'    .last_name = If(s.Last_name Is Nothing, "", s.Last_name.Trim()),
'    .staff_initials = If(s.Staff_initials Is Nothing, "", s.Staff_initials.Trim()),
'    .title = If(s.Title Is Nothing, "", s.Title.Trim()),
'    .uspo_name = (String.Format("{0}, {1} {2}", If(s.Last_name Is Nothing, "", s.Last_name.Trim()), If(s.First_name Is Nothing, "", s.First_name.Trim()), If(s.Middle_name Is Nothing, "", s.Middle_name.Trim()))),
'    .uspo_email = If(s.Email Is Nothing, "", s.Email.Trim()),
'    .supervisor_name = If(sup Is Nothing, "", (String.Format("{0}, {1} {2}", If(sup.Last_name Is Nothing, "", sup.Last_name.Trim()), If(sup.First_name Is Nothing, "", sup.First_name.Trim()), If(sup.Middle_name Is Nothing, "", sup.Middle_name.Trim())))),
'    .supervisor_email = If(sup Is Nothing, "", If(sup.Email Is Nothing, "", sup.Email.Trim()))
'    }
'
'
'tmpStaff.dump()



Dim tmp1 = From a In Supervisions.AsEnumerable
		Select New With {
		.id = a.Supervision_id,
		.pacts_no = a.Client_id.Trim(),
		.divoff_code = If(a.Divoff_code Is Nothing, "", a.Divoff_code.Trim()),
		.year = If(a.Year Is Nothing, "", a.Year.Trim()),
		.case_type = If(a.Case_type Is Nothing, "", a.Case_type.Trim()),
		.docket = If(a.Docket Is Nothing, "", a.Docket.Trim()),
		.cs_casenumber = String.Format("{0}:{1}-{2}-{3}", If(a.Divoff_code Is Nothing, "", a.Divoff_code.Trim), If(a.Year Is Nothing, "", Microsoft.VisualBasic.Right(a.Year.Trim, 2)), If(a.Case_type Is Nothing, "", a.Case_type.Trim), If(a.Docket Is Nothing, "", a.Docket.Trim)),
		.defendant_no = a.Defendant_no,
		.officer_code = a.Officer_code,
		.last_name = If(a.Last_name Is Nothing, "", a.Last_name.Trim()),
		.first_name = If(a.First_name Is Nothing, "", a.First_name.Trim()),
		.middle_name = If(a.Middle_name Is Nothing, "", a.Middle_name.Trim()),
		.staff_initials = If(a.Staff_initials Is Nothing, "", a.Staff_initials.Trim()),
		.title = If(a.Title Is Nothing, "", a.Title.Trim()),
		.email = If(a.Email Is Nothing, "", a.Email.Trim().ToLower()),
		.officer_full_name = If(a.Officer_full_name Is Nothing, "", a.Officer_full_name.Trim().ToLower())
		}

Dim tmp2 = From a In Pretrials.AsEnumerable
		Group Join r1 In Staff On a.Staff_id Equals r1.Staff_id Into child1 = Group
		From s In child1.DefaultIfEmpty
		Select New With {
		.id = a.Pretrial_id,
		.pacts_no = a.Pacts_no,
		.divoff_code = If(a.Divoff_code Is Nothing, "", a.Divoff_code.Trim()),
		.year = a.Case_year,
		.case_type = a.Case_type.Trim(),
		.docket = a.Case_number,
		.cs_casenumber = String.Format("{0}:{1}-{2}-{3}", a.Divoff_code.Trim(), If(a.Case_type Is Nothing, Nothing, Microsoft.VisualBasic.Right(a.Case_year.Trim, 2)), If(a.Case_type Is Nothing, Nothing, a.Case_type.Trim().Replace("MG", "MJ")), If(a.Case_number Is Nothing, Nothing, a.Case_number.Trim())),
		.defendant_no = a.Defendant_number,
		.officer_code = a.Staff_id,
		.last_name = If(s Is Nothing, "", If(s.Last_name Is Nothing, "", s.Last_name.Trim())),
		.first_name = If(s Is Nothing, "", If(s.First_name Is Nothing, "", s.First_name.Trim())),
		.middle_name = If(s Is Nothing, "", If(s.Middle_name Is Nothing, "", s.Middle_name.Trim())),
		.staff_initials = If(s Is Nothing, "", If(s.Staff_initials Is Nothing, "", s.Staff_initials.Trim())),
		.title = If(s Is Nothing, "", If(s.Title Is Nothing, "", s.Title.Trim())),
		.email = If(s Is Nothing, "", If(s.Email Is Nothing, "", s.Email.Trim().ToLower())),
		.officer_full_name = If(s Is Nothing, "", String.Format("{0}, {1} {2}", If(s Is Nothing, "", If(s.Last_name Is Nothing, "", s.Last_name.Trim())), If(s Is Nothing, "", If(s.First_name Is Nothing, "", s.First_name.Trim())), If(s Is Nothing, "", If(s.Middle_name Is Nothing, "", s.Middle_name.Trim()))))
		}

Dim tmp3 = (From a In investigations.asenumerable
			Group Join r1 In Staff On a.Officer_code Equals r1.Staff_id Into child1 = Group
			From s In child1.DefaultIfEmpty
            Group Join r2 In Sentences.AsEnumerable On a.Case_defendant_id Equals r2.Case_defendant_id Into child2 = Group
            From sentence In child2.DefaultIfEmpty
			Select New With {
				.id = a.Invest_id,
				.pacts_no = a.Case_defendant_client_id,
				.divoff_code = a.Divoff_code,
				.year = a.Year,
				.case_type = a.Case_type,
				.docket = a.Docket,
				.cs_casenumber = String.Format("{0}:{1}-{2}-{3}", If(a.Divoff_code Is Nothing, "", a.Divoff_code.Trim), If(a.Year Is Nothing, "", Microsoft.VisualBasic.Right(a.Year.Trim, 2)), If(a.Case_type Is Nothing, "", a.Case_type.Trim), If(a.Docket Is Nothing, "", a.Docket.Trim)),
				.defendant_no = a.Defendant_no,
				.officer_code = a.Officer_code,
				.last_name = If(s Is Nothing, "", If(s.Last_name Is Nothing, "", s.Last_name.Trim())),
				.first_name = If(s Is Nothing, "", If(s.First_name Is Nothing, "", s.First_name.Trim())),
				.middle_name = If(s Is Nothing, "", If(s.Middle_name Is Nothing, "", s.Middle_name.Trim())),
				.staff_initials = If(s Is Nothing, "", If(s.Staff_initials Is Nothing, "", s.Staff_initials.Trim())),
				.title = If(s Is Nothing, "", If(s.Title Is Nothing, "", s.Title.Trim())),
				.email = If(s Is Nothing, "", If(s.Email Is Nothing, "", s.Email.Trim().ToLower())),
				.officer_full_name = If(s Is Nothing, "", String.Format("{0}, {1} {2}", If(s Is Nothing, "", If(s.Last_name Is Nothing, "", s.Last_name.Trim())), If(s Is Nothing, "", If(s.First_name Is Nothing, "", s.First_name.Trim())), If(s Is Nothing, "", If(s.Middle_name Is Nothing, "", s.Middle_name.Trim())))),
				.sentence_id = If(sentence Is Nothing, Nothing, sentence.Sentence_id)
			   }).Where(Function(x) x.sentence_id = Nothing)

tmp3.dump()




'Dim tmp3 = (From a In Investigations.AsEnumerable
'                    Group Join r1 In tmpStaff.AsEnumerable On a.Officer_code Equals r1.staff_id Into child1 = Group
'                    From s In child1.DefaultIfEmpty
'                    Group Join r2 In Sentences.AsEnumerable On a.Case_defendant_id Equals r2.Case_defendant_id Into child2 = Group
'                    From sentence In child2.DefaultIfEmpty
'                    Select
'                    lcd_id = a.Lcd_id,
'                    invest_id = a.Invest_id,
'                    investigation_client_id = a.Investigation_client_id,
'                    pinvest_type = a.Pinvest_type,
'                    invest_type = a.Invest_type,
'                    prob_pts = a.Prob_pts,
'                    date_assigned = a.Date_assigned,
'                    due_date = a.Due_date,
'                    date_submitted = a.Date_submitted,
'                    case_defendant_id = a.Case_defendant_id,
'                    pacts_case_no = a.Pacts_case_no,
'                    case_id = a.Case_id,
'                    case_defendant_client_id = a.Case_defendant_client_id,
'                    pacts_no = a.Case_defendant_client_id,
'                    divoff_code = a.Divoff_code,
'                    year = a.Year,
'                    case_type = a.Case_type,
'                    docket = a.Docket,
'                    officer_code = a.Officer_code,
'                    description = a.Description,
'                    cs_casenumber = String.Format("{0}:{1}-{2}-{3}", If(a.Divoff_code Is Nothing, "", a.Divoff_code.Trim), If(a.Year Is Nothing, "", Microsoft.VisualBasic.Right(a.Year.Trim, 2)), If(a.Case_type Is Nothing, "", a.Case_type.Trim), If(a.Docket Is Nothing, "", a.Docket.Trim)),
'                    defendant_no = a.Defendant_no,
'                    staff_id = If(s Is Nothing, Nothing, s.staff_id),
'                    sentence_id = If(sentence Is Nothing, Nothing, sentence.Sentence_id),
'                    uspo_name = If(s Is Nothing, Nothing, s.uspo_name),
'                    uspo_email = If(s Is Nothing, Nothing, s.uspo_email),
'                    supervisor_name = If(s Is Nothing, Nothing, s.supervisor_name),
'                    supervisor_email = If(s Is Nothing, Nothing, s.supervisor_email)
'                    ).Where(Function(x) x.sentence_id = Nothing)
'







Dim oPACTS = (From a In tmp1
                    Select record_type = "Post Conviction",
                    a.id,
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
                    ).Concat(
                    From a In tmp2
                    Select record_type = "Pre-Trial",
                    a.id,
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





oPACTS.dump()


