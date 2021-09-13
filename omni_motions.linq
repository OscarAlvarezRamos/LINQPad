<Query Kind="VBStatements">
  <Connection>
    <ID>81be3153-9f82-4b39-abe0-9321a6ebc59a</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAiorhl1FXNUqBteQJxeLlrAAAAAACAAAAAAADZgAAwAAAABAAAADjNByKGSSfRBDGS9TsJYb6AAAAAASAAACgAAAAEAAAANBIGvl+vUGln1dw7sA05tlIAAAA5JZSAaE3x1lZSg/DZ+Pi43PeDmlreU+EpThrEAE5Es/deQcb1NDvnkebyvPjynY00eES5FC4r7B6BKNq4WBoxsuyR82A8FZKFAAAAHi1N7UNNc3nSkdjWhSQ/sbsYlqf</CustomCxString>
    <Server>156.120.13.222</Server>
    <Database>omnibus</Database>
    <UserName>omni_usr</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAiorhl1FXNUqBteQJxeLlrAAAAAACAAAAAAADZgAAwAAAABAAAACWeQGpxsL8Tn++qd2dC2hYAAAAAASAAACgAAAAEAAAAFWHKIlbtKmvGpTAvTN+ZQsQAAAA77OCs8SjEc+l0YsdoHggQxQAAACNXm5LXHh+iRflLIax1xvbsZhRHQ==</Password>
    <DisplayName>omni</DisplayName>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
    </DriverData>
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

Dim searchTerm As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("<a[^>]*>(?!<[A-Z][A-Z0-9]*\b[^><]*>[^><0-9]*)([0-9]+)(?=[^><0-9]*<)</a>")

Dim qry = From m In Motions
Order By m.Do_select_text , m.De_document_num Descending
Let cacao = (From match As System.Text.RegularExpressions.Match In searchTerm.Matches(m.Dt_text) Select match.groups(1).Value)
Select New With
{
	m.De_caseid,
	m.Cs_casenumber,
	m.De_seqno,
	m.De_type,
	m.De_sub_type,
	m.De_document_num,
	m.De_date_filed,
	m.Dp_type,
	m.Dp_sub_type,
	m.Dp_date_term,
	m.Do_select_text,
	m.Dt_caseid,
	m.Dt_deseqnoptr,
	m.Dt_seqno,
	m.Dt_text
	}

qry.dump()

'Dim qry2 = From a In qry 
'Group a By key = New With {
' key .Do_select_text = a.Do_select_text
'} Into g1 = Group
'Select 
'key.Do_select_text ,
'cnt = g1.count,
'motions = g1
'
'qry2.dump
'
'
'
'
''4595
'
'