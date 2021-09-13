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
Order By d.dk_id , p.pr_id
Select 
d.dk_id, 
p.Pr_id ,
p.Pr_fullname , 
po.po_id , 
po.po_pr_id , 
po.po_of_id ,
po.po_active  


Dim qry2 = From d In decks
Join c In cards On d.dk_id Equals c.crd_dk_id 
Join ca In Cards_assignments On c.crd_id Equals ca.ca_crd_id
Join at In Assignment_types On ca.ca_assignment_type Equals at.at_id
Let x1 = (From cl In cards_levels
Group Join rel1 In levels On cl.cl_lv_id Equals rel1.lv_id Into step1 = Group
From l In step1.defaultifempty
Where cl.Cl_active = True And cl.cl_crd_id = c.crd_id
Order By l.lv_weight Descending
Select 
cl.cl_lv_id
Take 1).SingleOrDefault
Join aw In Assignment_weights On at.at_id Equals aw.aw_at_id And aw.aw_lv_id Equals x1   
Order By d.dk_id,ca.ca_aty_pr_id
Select 
d.dk_id ,
ca.ca_aty_pr_id , 
aw.aw_weight


Dim agr1 = From widget In qry2 
Group widget By key = New With {
	Key .dk_id = widget.dk_id ,
	Key .pr_id = widget.ca_aty_pr_id
	} Into g1 = Group
Order By key.dk_id , key.pr_id
Select 
key.dk_id ,
key.pr_id ,
aw_weight = g1.sum(Function(x) x.aw_weight)


Dim qry3 = 
From tmp_a In qry1 
Group Join r1 In agr1 On tmp_a.dk_id Equals r1.dk_id And tmp_a.pr_id Equals r1.pr_id Into child1 = Group
From tmp_b In child1.defaultifempty()
Select 
tmp_a.dk_id ,
tmp_a.pr_id ,
aw_weight = If(tmp_b Is Nothing , Nothing , tmp_b.aw_weight)


Dim tot_1 = From widget In qry3
Group widget By key = New With { 
Key .dk_id = widget.dk_id 
} Into g1 = Group
Order By key.dk_id
Select 
key.dk_id ,
pr_id_count = g1.count ,
aw_weight_count = g1.sum(Function(x) If(x.aw_weight >0 ,1 ,0)) ,
aw_weight_usage_percent = ( g1.sum(Function(x) If(x.aw_weight >0 ,1 ,0)) / g1.count ) * 100







        Dim qry = From d In Decks
                  Group Join r1 In Offices On d.Dk_of_id Equals r1.Of_id Into child1 = Group
                  From o In child1.DefaultIfEmpty
                  Select
                  dk_id = d.Dk_id,
                  dk_of_id = d.Dk_of_id,
                  dk_description = d.Dk_description,
                  dk_deck_open = d.Dk_deck_open,
                  dk_deck_close = d.Dk_deck_close,
                  dk_notes = d.Dk_notes,
                  dk_sysdate = d.Dk_sysdate,
                  of_id = o.Of_id,
                  of_division = o.Of_division,
                  of_code = o.Of_code,
                  of_description = o.Of_description


qry.dump



















tot_1.dump()




qry3.dump()


'
'
''agr1.dump()
'qry2.dump()
'qry1.dump()