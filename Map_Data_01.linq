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
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\LinqLib.dll</Reference>
  <Reference>D:\VBProjects\prd-assignment-dft\packages\System.DirectoryServices.Linq.1.2.2.1\lib\net45\System.DirectoryServices.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\System.Linq.Dynamic.dll</Reference>
  <Namespace>LinqLib.Array</Namespace>
  <Namespace>LinqLib.DynamicCodeGenerator</Namespace>
  <Namespace>LinqLib.Operators</Namespace>
  <Namespace>LinqLib.Sequence</Namespace>
  <Namespace>LinqLib.Sort</Namespace>
</Query>

Dim qry1 = From s In States.asenumerable
Group Join r1 In Counties On s.st_state_fp Equals r1.cnt_state_fp  Into child1 = Group
From c In child1.DefaultIfEmpty
Where s.St_state_fp = "72" 
Select New With 
{
	.st_id = s.St_id,
	.st_state_fp=s.St_state_fp,
	.st_state_ab = s.St_state_ab,
	.st_state_name = s.St_state_name,
	.cnt_county_name = If(c Is Nothing , Nothing , c.cnt_county_name),
	.cnt_geoid = If(c Is Nothing , Nothing , c.cnt_geoid),
	.placemark = ( From p In placemarks.asenumerable
					Where p.pm_geoid = c.cnt_geoid
					Select New With {
					.pm_id = p.Pm_id,
					.pm_geoid = p.Pm_geoid,
					.pm_state_fp = p.Pm_state_fp,
					.pm_county_fp = p.Pm_county_fp,
					.pm_internal_point_lat = p.Pm_internal_point_lat,
					.pm_internal_point_lng = p.Pm_internal_point_lng,
					.shape = ( From sh In shapes.asenumerable
								Where sh.shp_pm_geoid = p.pm_geoid
								Select New With {
								.shp_id = sh.shp_id,
								.shp_pm_geoid = sh.shp_pm_geoid,
								.polygon = ( From pl In polygons.asenumerable
												Where pl.pl_shp_id = sh.shp_id
												Select New With {
													.pl_id = pl.pl_id,
													.pl_latitude = pl.pl_latitude,
													.pl_longitude = pl.pl_longitude
												})
								})
				})
}



qry1.dump()


'
'Dim qry2 = From sh In shapes
'Group Join r1 In polygons On sh.shp_id Equals r1.pl_shp_id Into child1 = Group
'From pl In child1.DefaultIfEmpty
'Select New With 
'{
'	.shp_id = sh.shp_id,
'	.shp_pm_geoid = sh.shp_pm_geoid,
'	.pl_id = pl.pl_id,
'	.pl_lat = pl.pl_latitude,
'	.pl_lng = pl.pl_longitude
'}
'
'
'qry2.dump()