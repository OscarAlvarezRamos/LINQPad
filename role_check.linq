<Query Kind="VBStatements">
  <Connection>
    <ID>155261b5-f277-46fd-b6e3-ebe68984192c</ID>
    <Persist>true</Persist>
    <Server>prd-sql-cludb.prd.circ1.dcn</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAPaDggjjBa0+MpLgY4BFySgAAAAACAAAAAAADZgAAwAAAABAAAAAgZYeXVnMnfPzRkPdAxcLvAAAAAASAAACgAAAAEAAAAOp6MEMe6CJkjImM6ydfzikQAAAArXQGXS/0vvnaebCsMA9x/BQAAAAbyDqpFqP8at6/ZM/YcDh024ASjw==</Password>
    <Database>Attorney Fees</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-fees\prd-fees\Bin\System.Linq.Dynamic.dll</Reference>
  <Namespace>System.Linq.Dynamic</Namespace>
</Query>

Dim usr As String = "alvarez"
Dim url As String = "fees"

Dim qry = (From u In users
Group Join r1 In users_roles On u.user_id Equals r1.ur_user_id Into child1 = Group
From ur In child1.DefaultIfEmpty
Group Join r2 In roles On ur.ur_role_id Equals r2.role_id Into child2 = Group
From r In child2.DefaultIfEmpty
Group Join r3 In menus_roles On r.role_id Equals r3.mr_role_id Into child3 = Group
From mr In child3.DefaultIfEmpty
Group Join r4 In menus On mr.mr_menu_id		Equals r4.menu_id Into child4 = Group
From m In child4.DefaultIfEmpty
WHERE u.user_active	  = True	AND m.menu_active	  = True	AND ur.ur_active = True	AND mr.mr_active = True And u.user_login = usr And m.menu_url = url 
Select
	u.User_id,
	u.User_login,
	u.User_password,
	u.User_description,
	u.User_last_login,
	u.User_active,
	u.User_sysdate,
	ur.Ur_id,
	ur.Ur_user_id,
	ur.Ur_role_id,
	ur.Ur_active,
	ur.Ur_sysdate,
	r.Role_id,
	r.Role_code,
	r.Role_description,
	r.Role_active_default,
	r.Role_weight,
	r.Role_sysdate,
	mr.Mr_id,
	mr.Mr_menu_id,
	mr.Mr_role_id,
	mr.Mr_active,
	mr.Mr_sysdate,
	m.Menu_id,
	m.Menu_parent_id,
	m.Menu_title,
	m.Menu_url,
	m.Menu_weight,
	m.Menu_active,
	m.Menu_sysdate).count()






Dim qry2 = From u In users
Group Join r1 In users_roles On u.user_id Equals r1.ur_user_id Into child1 = Group
From ur In child1.DefaultIfEmpty
Group Join r2 In roles On ur.ur_role_id Equals r2.role_id Into child2 = Group
From r In child2.DefaultIfEmpty
Group Join r3 In menus_roles On r.role_id Equals r3.mr_role_id Into child3 = Group
From mr In child3.DefaultIfEmpty
Group Join r4 In menus On mr.mr_menu_id		Equals r4.menu_id Into child4 = Group
From m In child4.DefaultIfEmpty
WHERE u.user_active	  = True	AND m.menu_active	  = True	AND ur.ur_active = True	AND mr.mr_active = True And u.user_login = usr And m.menu_url = url 
Select
	u.User_id,
	u.User_login,
	u.User_password,
	u.User_description,
	u.User_last_login,
	u.User_active,
	u.User_sysdate,
	ur.Ur_id,
	ur.Ur_user_id,
	ur.Ur_role_id,
	ur.Ur_active,
	ur.Ur_sysdate,
	r.Role_id,
	r.Role_code,
	r.Role_description,
	r.Role_active_default,
	r.Role_weight,
	r.Role_sysdate,
	mr.Mr_id,
	mr.Mr_menu_id,
	mr.Mr_role_id,
	mr.Mr_active,
	mr.Mr_sysdate,
	m.Menu_id,
	m.Menu_parent_id,
	m.Menu_title,
	m.Menu_url,
	m.Menu_weight,
	m.Menu_active,
	m.Menu_sysdate

qry.dump()
qry2.dump()
