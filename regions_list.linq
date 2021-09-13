<Query Kind="VBStatements">
  <Connection>
    <ID>155261b5-f277-46fd-b6e3-ebe68984192c</ID>
    <Persist>true</Persist>
    <Server>prd-sql-cludb.prd.circ1.dcn</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAPaDggjjBa0+MpLgY4BFySgAAAAACAAAAAAADZgAAwAAAABAAAAAgZYeXVnMnfPzRkPdAxcLvAAAAAASAAACgAAAAEAAAAOp6MEMe6CJkjImM6ydfzikQAAAArXQGXS/0vvnaebCsMA9x/BQAAAAbyDqpFqP8at6/ZM/YcDh024ASjw==</Password>
    <Database>Probation Regions Map</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-fees\prd-fees\Bin\System.Linq.Dynamic.dll</Reference>
  <Namespace>System.Linq.Dynamic</Namespace>
</Query>

Dim qry = From r In regions.AsEnumerable
Order By r.rg_regions_name
Select New With {
	.id = r.rg_id,
	.regions_name = r.rg_regions_name,
	.color_code = r.rg_color_code,
	.persons = (From rp In regions_persons.AsEnumerable
	Where rp.rgpr_regions_id = r.rg_id
	Group Join r1 In persons On rp.rgpr_persons_id Equals r1.pr_id Into child1 = Group
	From p In child1.DefaultIfEmpty	
	Select New With {
		.pr_id = p.Pr_id,
		.pr_first_name = p.Pr_first_name,
		.pr_middle_name = p.Pr_middle_name,
		.pr_last_name = p.Pr_last_name,
		.pr_title = p.Pr_title,
		.pr_fullname = p.Pr_fullname		
		})}



qry.dump()
