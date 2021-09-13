<Query Kind="VBStatements">
  <Connection>
    <ID>af04a8e7-24cf-46f2-8dfd-31bbb943b4f4</ID>
    <Persist>true</Persist>
    <Server>prd-docker.prd.circ1.dcn</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAdTzPAXluy0S+PyVWeYSutwAAAAACAAAAAAADZgAAwAAAABAAAABYhn8uLYJgBfHg8XYPvfkNAAAAAASAAACgAAAAEAAAAILG9Jjh+Ein2EkyrR4vs9oQAAAATNOQHSTVkbBT/2IIjKmzcBQAAACEMv7wRd2iK7x0Lk6HUYWUZcPTUA==</Password>
    <Database>bankruptcy_motions</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
  <Reference>D:\VBProjects\electronic-court-calendar\scripts\objects\InformixService.dll</Reference>
  <Reference>D:\VBProjects\electronic-court-calendar\electronic-court-calendar\Bin\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-fees\prd-fees\Bin\System.Linq.Dynamic.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Linq.Dynamic</Namespace>
</Query>



Dim qry = From c In Cases
Group Join r1 In cases_sections On c.id Equals r1.cs_id Into child1 = Group
From cs In child1.defaultifempty
Group Join r2 In sections On  cs.sec_id Equals r2.id Into child2 = Group
From s In child2.defaultifempty
Group Join r3 In sections_events On s.id Equals r3.sec_id Into child3 = Group
From se In child3.defaultifempty
GROUP JOIN r4 IN events  On se.evt_id Equals r4.id Into child4 = Group
From e In child4.defaultifempty
Group Join r5 In motions On c.case_number Equals r5.cs_casenumber AND e.event_type Equals r5.dp_type AND e.event_sub_type Equals  r5.dp_sub_type
Into child5 = Group
From m In child5.defaultifempty
Where cs.active = True And se.active = True And s.id = 1
Select New With {
	.c_id = c.id,
	.c_case_number = c.case_number,
	.c_description = c.description,
	.cs_id = cs.id ,
	.cs_cs_id = cs.cs_id,
	.cs_sec_id = cs.sec_id,
	.cs_active = cs.active,
	.s_id = s.id,
	.s_description = s.description,
	.se_id = se.id,
	.se_sec_id = se.sec_id,
	.se_evt_id = se.evt_id,
	.se_active = se.active,
	.e_id = e.id,
	.e_description = e.description,
	.e_event_type = e.event_type,
	.e_event_sub_type = e.event_sub_type	
}


qry.dump()
