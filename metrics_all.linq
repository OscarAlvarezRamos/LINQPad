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
</Query>

Dim qry1 = 
From p In persons
Group Join r1 In Persons_offices On p.pr_id Equals r1.po_pr_id Into child1 = Group
From po In child1.DefaultIfEmpty
Join d In Decks On po.po_of_id Equals d.Dk_of_id 
Where p.pr_type = "aty" And
p.Pr_terminated_date Is Nothing And 
( Not (From pex In Persons_Excludes Where  pex.Pex_start_date <= DateTime.Now AndAlso pex.Pex_end_date >= DateTime.Now   Select pex.Pex_pr_id).contains(p.Pr_id) ) And 
po.po_active = True
Order By d.dk_id , p.pr_fullname
Select 
d.dk_id, 
p.Pr_id ,
p.Pr_fullname 
', 
'po.po_id , 
'po.po_pr_id , 
'po.po_of_id ,
'po.po_active  
'


Dim qry2 = From d In Decks
Group Join r1 In Cards On d.Dk_id Equals r1.Crd_dk_id  Into child1 = Group
From c In child1.DefaultIfEmpty
Group Join r2 In Cards_assignments On c.crd_id Equals r2.ca_crd_id Into child2 = Group
From ca In child2.DefaultIfEmpty
Group Join r3 In Assignment_types On ca.ca_assignment_type Equals r3.at_id Into child3 = Group
From at In child3.DefaultIfEmpty
Let x1 = (From cl In cards_levels
Group Join rel1 In levels On cl.cl_lv_id Equals rel1.lv_id Into step1 = Group
From l In step1.defaultifempty
Where cl.Cl_active = True And cl.cl_crd_id = c.crd_id
Order By l.lv_weight Descending
Select 
cl.cl_lv_id
Take 1).SingleOrDefault
Group Join r4 In Assignment_weights On at.At_id Equals r4.aw_at_id  And r4.aw_lv_id Equals x1   Into child4 = Group
From aw In child4.DefaultIfEmpty
Order By d.dk_id , ca.ca_aty_pr_id
Select 
dk_id = If(d Is Nothing , Nothing ,d.dk_id) , 
ca_aty_pr_id = If(ca Is Nothing , Nothing ,ca.ca_aty_pr_id ), 
aw_weight = If (aw Is Nothing , Nothing , aw.aw_weight)





Dim agr1 = From widget In qry2 
Group widget By key = New With {
	Key .dk_id = widget.dk_id ,
	Key .pr_id = widget.ca_aty_pr_id
	} Into g1 = Group
Order By key.dk_id , key.pr_id
Select 
key.dk_id ,
key.pr_id ,
aw_weight = g1.sum(Function(x) x.aw_weight) ,
aw_weight_cnt = g1.count()




Dim qry3 = From a In qry1
Group Join r1 In agr1 On a.pr_id Equals r1.pr_id  And  a.dk_id Equals r1.dk_id  Into child1 = Group
From w In child1.Defaultifempty()
Select a.dk_id ,
a.pr_id ,
a.pr_fullname ,
aw_weight = If ( w Is Nothing , Nothing , w.aw_weight )










'
'Dim qry3 = 
'From cl In cards_levels
'Group Join rel1 In levels On cl.cl_lv_id Equals rel1.lv_id Into step1 = Group
'From l In step1.defaultifempty
'Where cl.Cl_active = True 
'Order By cl.cl_crd_id , l.lv_weight Descending
'Select 
'cl.cl_lv_id
'Take 1


'
'
'Dim tmp1 = From p In persons Where p.pr_id = 171
'tmp1.dump()



''qry3.dump()
qry2.dump()
''agr1.dump()
qry1.dump()