<Query Kind="VBStatements">
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

'Dim str As String = "Response to Debtor&#039;s Objection to Claims (Number(s): 10701) Re: <a href='https://ecf.prb.uscourts.gov/doc1/158025419082'>4417</a> MOTION Puerto Rico Sales Tax Financing Corporation&#039;s Thirteenth Omnibus Objection (Non-Substantive) To Duplicate Bond Claims filed by PUERTO RICO SALES TAX FINANCING CORPORATION (COFINA), MOTION to reschedule the hearing on the Omnibus Objection set for March 13, 2019 re:<a href='https://ecf.prb.uscourts.gov/doc1/158025419082'>4417</a> MOTION Puerto Rico Sales Tax Financing Corporation&#039;s Thirteenth Omnibus Objection (Non-Substantive) To Duplicate Bond Claims filed by PUERTO RICO SALES TAX FINANCING CORPORATION (COFINA), OBJECTION to <a href='https://ecf.prb.uscourts.gov/doc1/158025384028'>4363</a> Notice Second Amended Plan of Adjustment of Puerto Rico Sales Tax Financing Corporation (Attachments: # <a href='https://ecf.prb.uscourts.gov/doc1/158125505563'>1</a> Exhibit Envelope) filed by Peter C. Hein, pro se. [Tacoronte, Carmen]. Modified on 1/2/2019 to add link to <a href='https://ecf.prb.uscourts.gov/doc1/158025384028'>4363</a> (Rodriguez, Jesus)."




Dim str As String = "Response to Debtor&#039;s Objection to Claims (Number(s): 20186) Re: <a href='https://ecf.prb.uscourts.gov/doc1/158025418907'>4408</a> MOTION Puerto Rico Sales Tax Financing Corporation&#039;s Fourth Omnibus Objection (Non-Substantive) to Deficient Claims. filed by PUERTO RICO SALES TAX FINANCING CORPORATION (COFINA), The Financial Oversight and Management Board for Puerto Rico, as Representative of the Commonwealth of Puerto Rico, et al. (Attachments: # <a href='https://ecf.prb.uscourts.gov/doc1/158125535336'>1</a> Exhibit *RESTRICTED* Report on Disability Evaluation # <a href='https://ecf.prb.uscourts.gov/doc1/158125535337'>2</a> Exhibit Envelope) filed by Juan Cruz Rodriguez pro se in the Spanish language. [Tacoronte, Carmen]"
''Dim str As String = "Lorem lipsum"


Dim searchTerm As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(?i)(abc)")

Dim qry = (From match As System.Text.RegularExpressions.Match In searchTerm.Matches(str) Select match




qry.dump()





			
''xyz.Match(str).Value().dump()
'
'
'Dim m As match = xyz.Match(str)
'
'
'
'
'
'While m.success
'
'	
'	Dim n As Integer = 0	
'	For Each g In m.groups()
'	
'		console.writeline (g.Captures)
'	
'	Next
'	
'	
'	
'	m = m.NextMatch()
'End While
'
'

'
'
'console.writeline ("----------------------------")
'
'For Each x In xyz.Match(str).groups
'
'console.writeline (x.value)
'
'Next



''xyz.dump()

''str.dump()