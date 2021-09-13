<Query Kind="VBStatements">
  <Connection>
    <ID>155261b5-f277-46fd-b6e3-ebe68984192c</ID>
    <Persist>true</Persist>
    <Server>prd-sql-cludb.prd.circ1.dcn</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAPaDggjjBa0+MpLgY4BFySgAAAAACAAAAAAADZgAAwAAAABAAAAAgZYeXVnMnfPzRkPdAxcLvAAAAAASAAACgAAAAEAAAAOp6MEMe6CJkjImM6ydfzikQAAAArXQGXS/0vvnaebCsMA9x/BQAAAAbyDqpFqP8at6/ZM/YcDh024ASjw==</Password>
    <Database>Attorney Assignments</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
  <Reference>D:\Visual Studio Projects\LinqLib\sourceCode\sourceCode\LinqLib\bin\Debug\LinqLib.dll</Reference>
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\System.Linq.Dynamic.dll</Reference>
  <Namespace>LinqLib.Array</Namespace>
  <Namespace>LinqLib.DynamicCodeGenerator</Namespace>
  <Namespace>LinqLib.Operators</Namespace>
  <Namespace>LinqLib.Sequence</Namespace>
  <Namespace>LinqLib.Sort</Namespace>
</Query>

Dim qry1 = From a In Users
Group Join r1 In users_roles On a.user_id Equals r1.ur_user_id Into child1 = Group
From ur In child1.defaultifempty
Select 
a.user_id , 
a.user_login,
ur.ur_role_id ,
ur_active = If(ur.ur_active ,1,0)

'', ur = (From b In users_roles Where b.ur_user_id = a.user_id Select b.ur_role_id , b.ur_active )

''qry1.Pivot(Function(x) x.ur , Function(x) x.ur_role_id , Function(x) x.ur_active,True).ToList().dump()



Dim qry2 = From a In Users





qry2.Pivot(Function(x) x.users_roles , Function(x) x.ur_role_id , Function(x) x.ur_active,True).dump()




users.dump()