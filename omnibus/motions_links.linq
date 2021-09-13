<Query Kind="VBProgram">
  <Connection>
    <ID>fcce677d-0243-4785-a6e0-ba0f21e6efeb</ID>
    <Persist>true</Persist>
    <Server>dev-mssql12.prd.circ1.dcn</Server>
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

Sub Main

	
    Dim searchTerm As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("<a[^>]*>(?!<[A-Z][A-Z0-9]*\b[^><]*>[^><0-9]*)([0-9]+)(?=[^><0-9]*<)</a>")
	
	
	
	
	
	For Each row In motions
	
	
		Dim xyz = From match As System.Text.RegularExpressions.Match In searchTerm.Matches(row.Dt_text) Let x = Int32.Parse(match.Groups(1).Value) Select x
		
		console.writeline( String.format( "{0} {1} {2} {3}", row.id , row.cs_casenumber , row.de_document_num , row.dt_text) )
		
		For Each doc In xyz
		

			Dim qry = From m In motions Where m.de_document_num = doc Select m.id
			
			For Each item In qry
				console.writeline( String.format("fk_id {0}, pk_id {1}" , item, row.id) )
				
				
				Dim abc = New motions_links
				abc.fk_id = item
				abc.pk_id = row.id
				motions_links.InsertOnSubmit(abc)
				SubmitChanges()
				
				
				
				
			Next
			
			
			
		
		Next
		
		
	
'		console.writeline( String.format( "Text : {0}", row.dt_text ) )
		
		console.writeline("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
	
	Next
	
	

	
	
End Sub

' Define other methods and classes here
