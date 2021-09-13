<Query Kind="Program">
  <Connection>
    <ID>af04a8e7-24cf-46f2-8dfd-31bbb943b4f4</ID>
    <Persist>true</Persist>
    <Server>prd-docker.prd.circ1.dcn</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAdTzPAXluy0S+PyVWeYSutwAAAAACAAAAAAADZgAAwAAAABAAAABYhn8uLYJgBfHg8XYPvfkNAAAAAASAAACgAAAAEAAAAILG9Jjh+Ein2EkyrR4vs9oQAAAATNOQHSTVkbBT/2IIjKmzcBQAAACEMv7wRd2iK7x0Lk6HUYWUZcPTUA==</Password>
    <Database>jury_services</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
  <Reference>D:\Visual Studio Projects\LinqLib\sourceCode\sourceCode\LinqLib\bin\Debug\LinqLib.dll</Reference>
  <Reference>D:\VBProjects\electronic-court-calendar\electronic-court-calendar\Bin\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-fees\prd-fees\Bin\System.Linq.Dynamic.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>LinqLib.Array</Namespace>
  <Namespace>LinqLib.DynamicCodeGenerator</Namespace>
  <Namespace>LinqLib.Operators</Namespace>
  <Namespace>LinqLib.Sequence</Namespace>
  <Namespace>LinqLib.Sort</Namespace>
  <Namespace>LinqLib.Sort.Sorters</Namespace>
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

void Main()
{

	
	List<user> patapon  = Generator.CreateUsers();
	
	//users.Dump();
	
	patapon.Pivot( X=> X.users_roles , X => X.ur_role_desc , X => X.ur_active, true ).ToArray().Dump();
	
	


//	
//	
//	
//	var  qry = from u in Users
//	select new users() {
//		user_id = u.User_id,
//		user_name = u.User_name,
//		user_password_hash = u.User_password_hash,
//		user_password_salt = u.User_password_salt,
//		user_description = u.User_description,
//		user_email = u.User_email,
//		user_last_login = u.User_last_login,
//		user_active  = u.User_active,
//		user_sysdate = u.User_sysdate ,
//		
//		users_roles = (from ur in Users_roles
//		where ur.Ur_user_id == u.User_id
//		select new users_roles {
//			ur_id = ur.Ur_id,
//			ur_user_id = ur.Ur_user_id,
//			ur_role_id = ur.Ur_role_id,
//			ur_active = ur.Ur_active,
//			ur_sysdate = ur.Ur_sysdate 
//		}).ToList()
//		
//		
//		
//		};
//		
//		
//		
//		
//		qry.Dump();
		
		
		
//qry.Pivot(Function(X) X.users_roles , Function(X) X.ur_role_id , Function(X) X.ur_active,True).dump()		;

//qry.Pivot( X => X.users_roles , X => X.ur_role_id.ToString() , X => X.ur_active, true ).ToArray().Dump();


	
	
//	
//	qry.Dump();

}





public static class Generator
{

	public static  List<user> CreateUsers()
	{
		return new List<user>
		{
			new user { 
			Id = 1 , user_name = "jsmith" , user_description = "Mr. John Smith" , user_email = "jsmith@compay.co" , user_active = true , user_last_login = DateTime.Now, user_sysdate = DateTime.Now,
			users_roles = new List<user_role> 
				{ 
					new user_role { Id =1 , ur_user_id = 1 , ur_role_id = 1 , ur_role_desc = "Admin" ,  ur_active = true , ur_sysdate = DateTime.Now },
					new user_role { Id =1 , ur_user_id = 1 , ur_role_id = 1 , ur_role_desc = "User" ,  ur_active = false , ur_sysdate = DateTime.Now },
					new user_role { Id =1 , ur_user_id = 1 , ur_role_id = 1 , ur_role_desc = "Guest" ,  ur_active = false , ur_sysdate = DateTime.Now }
				}
			},
			
			new user { 
			Id = 1 , user_name = "alvarez" , user_description = "Mr. Oscar Alvarez" , user_email = "alvarez@compay.co" , user_active = false , user_last_login = DateTime.Now, user_sysdate = DateTime.Now,
			users_roles = new List<user_role> 
				{ 
					new user_role { Id =1 , ur_user_id = 1 , ur_role_id = 1 , ur_role_desc = "Admin" ,  ur_active = false , ur_sysdate = DateTime.Now },
					new user_role { Id =1 , ur_user_id = 1 , ur_role_id = 1 , ur_role_desc = "User" ,  ur_active = false , ur_sysdate = DateTime.Now },
					new user_role { Id =1 , ur_user_id = 1 , ur_role_id = 1 , ur_role_desc = "Guest" ,  ur_active = true , ur_sysdate = DateTime.Now }
				}
			}

			
			
			
			
			
			
			
			
			
		};
	}
}








public class user
{
	public int Id;

    public string user_name { get; set; }

//	public Binary  user_password_hash { get; set; }
//    public Binary user_password_salt { get; set; }
	
	
    public string user_description { get; set; }
    public string user_email { get; set; }
    public DateTime user_last_login { get; set; }
    public bool user_active { get; set; }
    public DateTime user_sysdate { get; set; }

	public  List<user_role> users_roles { get; set; }

}



public class user_role
{

	public int Id { get; set; }
	public int ur_user_id { get; set; }
	public int ur_role_id { get; set; }
	public string ur_role_desc { get; set; }
	public bool? ur_active { get; set; }
	public DateTime ur_sysdate { get; set; }
}


//
//
//public  class users
//{
//    public users()
//    {
//        users_roles = new HashSet<users_roles>();
//    }
//
//    public int user_id { get; set; }
//    public string user_name { get; set; }
//    public byte[] user_password_hash { get; set; }
//    public byte[] user_password_salt { get; set; }
//    public string user_description { get; set; }
//    public string user_email { get; set; }
//    public DateTime? user_last_login { get; set; }
//    public bool? user_active { get; set; }
//    public DateTime user_sysdate { get; set; }
//
//    public virtual ICollection<users_roles> users_roles { get; set; }
//}
//
//
//public  class users_roles
//{
//    public int ur_id { get; set; }
//    public int ur_user_id { get; set; }
//    public int ur_role_id { get; set; }
//    public bool ur_active { get; set; }
//    public DateTime ur_sysdate { get; set; }
//
//}
//