<Query Kind="VBStatements">
  <Connection>
    <ID>fc327214-6f71-4e3c-963f-c58f74eb8fcf</ID>
    <Persist>true</Persist>
    <Server>dc-systems-laps</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAmFTSOoOvYEWNTS4q0OMfsQAAAAACAAAAAAADZgAAwAAAABAAAAD/FKVrcnEOnqC/nhuCxeVgAAAAAASAAACgAAAAEAAAACiDlbrVqww7vUYWC3GdTX0QAAAAjaZpqNM97sSnHD3z0t4RhBQAAADeZB5bFtgE7QtkiOmw9HaG1b/QJw==</Password>
    <Database>Starter Kit</Database>
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

Dim usr As String = "oscar alvarez"
Dim rows() As String = {"admin","guest"}

'usr.dump()
'roles.dump()



For Each row In rows


	
	Dim item = (From u In users 
	Group Join r1 In users_roles On u.user_id Equals r1.ur_user_id Into child1= Group
	From ur In child1.defaultifempty
	Group Join r2 In roles On ur.ur_role_id Equals r2.role_id Into child2 = Group
	From r In child2.defaultifempty
	Where u.user_username = usr And r.role_code = row
	Select ur).ToList()(0)
	item.Ur_active = True
		

Next


submitchanges()
	







