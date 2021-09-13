<Query Kind="VBStatements">
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

Dim service As New InformixService ()
service.Url = "http://localhost:26364/InformixService.asmx"
'service.HelloWorld().Dump()




'Dim str As String = "{data:[{'id':1,'name':'alpha'},{'id':99,'name':'bravo'}]}"


'Dim str As String =  "{'d':" + service.ScheduleRead("12/01/2016","12/15/2016") + "}" 
Dim str As String =   service.ScheduleRead("12/01/2016","12/15/2016")



Dim db As  jarray = jarray.parse(str)




Dim qry = From a In db
Select New With {
	.setting = a("sd_setting")
}








qry.dump()

'
'service.ScheduleRead("12/01/2016","12/10/2016").dump()

