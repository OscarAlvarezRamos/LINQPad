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
	
	
	
	



Dim tmp1 = From s In Supervisions.AsEnumerable
    Group Join r1 In Staff.AsEnumerable On s.Officer_code Equals r1.Staff_id Into child1 = Group
    From uspo In child1.DefaultIfEmpty.AsEnumerable
    Group Join r2 In Staff.AsEnumerable On uspo.Reports_to Equals r2.Staff_id Into child2 = Group
    From sup In child2.DefaultIfEmpty.AsEnumerable
    Where uspo.Always_show = "Y"
    Select New With
        {
            .id = s.Supervision_id,
            .pacts_no = s.Client_id.Trim(),
            .supervision_type = s.Supervision_type.Trim(),
            .supervision_description = s.Supervision_type_description.Trim(),
            .date_assigned = s.Assign_date,
            .cs_casenumber = String.Format("{0}:{1}-{2}-{3}",
                If(s.Divoff_code Is Nothing, "", s.Divoff_code.Trim()),
                If(s.Year Is Nothing, "", Microsoft.VisualBasic.Right(s.Year.Trim(), 2)),
                If(s.Case_type Is Nothing, "", s.Case_type.Trim()),
                If(s.Docket Is Nothing, "", s.Docket.Trim())),
            .defendant_no = s.Defendant_no,
            .uspo_id = s.Officer_code,
            .uspo_name = If(uspo.Last_name Is Nothing, "",
                String.Format("{0}, {1} {2}",
                    If(uspo.Last_name Is Nothing, "", uspo.Last_name.Trim()),
                    If(uspo.First_name Is Nothing, "", uspo.First_name.Trim()),
                    If(uspo.Middle_name Is Nothing, "", uspo.Middle_name.Trim())
                    )
                ),
            .uspo_email = If(uspo.Email Is Nothing, "", uspo.Email.Trim().tolower()),
            .super_id = sup.Staff_id,
            .super_name = If(sup.Last_name Is Nothing, "",
                String.Format("{0}, {1} {2}",
                    If(sup.Last_name Is Nothing, "", sup.Last_name.Trim()),
                    If(sup.First_name Is Nothing, "", sup.First_name.Trim()),
                    If(sup.Middle_name Is Nothing, "", sup.Middle_name.Trim())
                    )
                ),
            .super_email = If(sup.Email Is Nothing, "", sup.Email.Trim().tolower())
            }




Dim tmp2 = From a In Pretrials.asenumerable
Group Join r1 In staff On a.Staff_id   Equals r1.staff_id Into child1 = Group
From s In child1.DefaultIfEmpty
Group Join r2 In Staff.AsEnumerable On s.Reports_to Equals r2.Staff_id Into child2 = Group
From sup In child2.DefaultIfEmpty.AsEnumerable
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
	.reports_to = s.reports_to,
	.super_id = sup.Staff_id,
	.super_name = If(sup.Last_name Is Nothing, "",
	String.Format("{0}, {1} {2}",
                    If(sup.Last_name Is Nothing, "", sup.Last_name.Trim()),
                    If(sup.First_name Is Nothing, "", sup.First_name.Trim()),
                    If(sup.Middle_name Is Nothing, "", sup.Middle_name.Trim())
                    )
                ),
	.super_email = If(sup.Email Is Nothing, "", sup.Email.Trim().tolower())
}
	





Dim qry = (From a In tmp1 
Select a.id,
a.pacts_no,
a.supervision_type,
a.supervision_description,
a.date_assigned,
a.cs_casenumber,
a.defendant_no,
a.uspo_id,
a.uspo_name,
a.uspo_email,
a.super_id,
a.super_name,
a.super_email).concat(From a In tmp2 
Select 
id = a.supervision_id,
a.pacts_no,
supervision_type = "PTR",
supervision_description = "Pre Trial",
date_assigned = a.assign_date,
a.cs_casenumber,
a.defendant_no,
uspo_id = a.officer_code,
uspo_name = a.officer_full_name,
uspo_email = a.email,
a.super_id,
a.super_name,
a.super_email)




qry.dump()
tmp2.dump()	
tmp1.dump()	
	
	
End Sub

' Define other methods and classes here
