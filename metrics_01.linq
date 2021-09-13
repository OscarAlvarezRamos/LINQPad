<Query Kind="VBExpression">
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
</Query>

From d In Decks
Group Join r1 In Cards On d.Dk_id Equals r1.Crd_dk_id  Into child1 = Group
From c In child1.DefaultIfEmpty
Group Join r2 In Cards_assignments On c.crd_id Equals r2.ca_crd_id Into child2 = Group
From ca In child2.DefaultIfEmpty
Group Join r3 In Assignment_types On ca.ca_assignment_type Equals r3.at_id Into child3 = Group
From at In child3.DefaultIfEmpty
Group Join r4 In Assignment_weights On at.At_id Equals r4.aw_at_id 
Into child4 = Group
From aw In child4.DefaultIfEmpty
Order By d.dk_id Descending
Select 
dk_id = If (d Is Nothing , Nothing,d.dk_id) , 
ca_aty_pr_id = If ( ca Is Nothing , Nothing , ca.ca_aty_pr_id) , 
aw_weight = if (aw is nothing , nothing , aw.aw_weight)



