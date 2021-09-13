<Query Kind="Program">
  <Connection>
    <ID>155261b5-f277-46fd-b6e3-ebe68984192c</ID>
    <Persist>true</Persist>
    <Server>prd-sql-cludb.prd.circ1.dcn</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAPaDggjjBa0+MpLgY4BFySgAAAAACAAAAAAADZgAAwAAAABAAAAAgZYeXVnMnfPzRkPdAxcLvAAAAAASAAACgAAAAEAAAAOp6MEMe6CJkjImM6ydfzikQAAAArXQGXS/0vvnaebCsMA9x/BQAAAAbyDqpFqP8at6/ZM/YcDh024ASjw==</Password>
    <Database>Attorney Exams</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
  <Reference>D:\VBProjects\electronic-court-calendar\scripts\objects\InformixService.dll</Reference>
  <Reference>D:\VBProjects\attorney-exams\attorney-exams\Bin\LinqLib.dll</Reference>
  <Reference>D:\VBProjects\electronic-court-calendar\electronic-court-calendar\Bin\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-fees\prd-fees\Bin\System.Linq.Dynamic.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>LinqLib.Array</Namespace>
  <Namespace>LinqLib.DynamicCodeGenerator</Namespace>
  <Namespace>LinqLib.Operators</Namespace>
  <Namespace>LinqLib.Sequence</Namespace>
  <Namespace>LinqLib.Sort</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System.Linq.Dynamic</Namespace>
</Query>

void Main()
{

//
//
//	List<oUsers> qry = new List<oUsers>();
//	qry = (from u in Users.AsEnumerable()
//		select new oUsers {
//			Id = u.User_id,
//			user_id = u.User_id,
//			user_login = u.User_login,
//			pvt = (from ur in Users_roles.AsEnumerable()
//			join r1 in Roles on ur.Ur_role_id equals r1.Role_id into child1 
//			from r in child1.DefaultIfEmpty()
//			where ur.Ur_user_id == u.User_id 
//			select new oRoles  {
//			role_code = r.Role_code , 
//			ur_active = true
//			}).ToList()
//		}).ToList();
//
//	
////	qry.Dump();
//	
//	qry.Pivot(x => x.pvt , x=> x.role_code  , x=> x.ur_active , true).Dump();
//











	List<oUsers> qry = new List<oUsers>();
	qry = (from u in Users
		select new oUsers {
			ID = u.User_id,
			user_id = u.User_id,
			user_login = u.User_login,
			pvt = (from ur in Users_roles
			join r1 in Roles on ur.Ur_role_id equals r1.Role_id into child1 
			from r in child1.DefaultIfEmpty()
			where ur.Ur_user_id == u.User_id 
			select new oRoles  {
			role_code = r.Role_code , 
			ur_active = true
			}).ToList()
		}).ToList();

	
	qry.Dump();
	
	qry.Pivot(x => x.pvt , x=> x.role_code  , x=> x.ur_active , true).Dump();









}





public class oUsers
{
	public int ID  {get;set;}
	public int user_id {get;set;}
	public string user_login {get;set;}
	public List<oRoles> pvt {get;set;}
};


public class oRoles
{
	public string role_code {get;set;}
	public bool ur_active {get;set;}
};


