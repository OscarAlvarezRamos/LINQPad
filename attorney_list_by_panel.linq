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
  <Output>DataGrids</Output>
</Query>

From p In Persons 
Group Join r1 In Persons_offices On p.pr_id Equals r1.po_pr_id Into child1 = Group
From po In child1.DefaultIfEmpty
Group Join r2 In Decks On po.po_of_id Equals r2.dk_of_id Into child2 = Group
From d In child2.DefaultIfEmpty
Where p.Pr_type = "aty"  And 
po.po_active = True And
p.Pr_terminated_date Is Nothing And 
Not (From pex In Persons_Excludes Where  pex.Pex_start_date <= DateTime.Now AndAlso pex.Pex_end_date >= DateTime.Now   Select pex.Pex_pr_id).contains(p.Pr_id)
Order By d.dk_id Descending , p.Pr_fullname
Select 
dk_id = d.Dk_id ,
pr_id = p.pr_id ,
pr_fullname = p.Pr_fullname

