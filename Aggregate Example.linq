<Query Kind="VBProgram">
  <Output>DataGrids</Output>
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\LinqLib.dll</Reference>
  <Reference>D:\VBProjects\prd-assignment-dft\packages\System.DirectoryServices.Linq.1.2.2.1\lib\net45\System.DirectoryServices.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\System.Linq.Dynamic.dll</Reference>
  <Namespace>LinqLib.Array</Namespace>
  <Namespace>LinqLib.DynamicCodeGenerator</Namespace>
  <Namespace>LinqLib.Operators</Namespace>
  <Namespace>LinqLib.Sequence</Namespace>
  <Namespace>LinqLib.Sort</Namespace>
</Query>

Sub Main
	Dim ds As  dataset = CLUEDO()



        ds.Tables("Suspects_Weapons").Rows.Add(Nothing, 1, 2)
        ds.Tables("Suspects_Weapons").Rows.Add(Nothing, 1, 3)
        ds.Tables("Suspects_Weapons").Rows.Add(Nothing, 1, 6)
        ds.Tables("Suspects_Weapons").Rows.Add(Nothing, 1, 5)
        ds.Tables("Suspects_Weapons").Rows.Add(Nothing, 2, 4)
        ds.Tables("Suspects_Weapons").Rows.Add(Nothing, 3, 5)

	

	
'	For Each dt As datatable In ds.tables
'		dt.dump()
'	Next
	
	
	
	
	
Dim qry = From sus In ds.tables!Suspects
Group Join r1 In ds.tables!suspects_weapons On sus.field(Of int32)("id") Equals r1.field(Of int32)("SuspectsID") Into child1 = Group
From sw In child1.DefaultIfEmpty
Group Join r2 In ds.tables!weapons On If( sw Is Nothing , 0 , sw.field(Of int32)("WeaponsID")) Equals   r2.field(Of int32)("id") Into child2 = Group
From w In child2.DefaultIfEmpty
Select New With {
.id = sus.field(Of int32)("id"),
.suspect = sus.field(Of String)("description"),
.weapon = If(w Is Nothing , "" , w.field(Of String)("description"))
}





Dim qry2 = From a In qry
Group a By key = New With{
	Key .id = a.id,
	Key .suspect = a.suspect
} Into g1 = Group
Select 
key.id ,
key.suspect,
weapon =  (From widget In g1.asenumerable Where widget.weapon Isnot Nothing).Aggregate(
New System.Text.StringBuilder, 
Function(cur, nxt) cur.AppendFormat(", {0}", nxt.weapon.ToString)).ToString.substring(2)



'
'
'
'
'Dim qry = From sus In ds.tables!Suspects
'Group Join r1 In ds.tables!suspects_weapons On sus.field(Of int32)("id") Equals r1.field(Of int32)("SuspectsID") Into child1 = Group
'From sw In child1.DefaultIfEmpty
'Group Join r2 In ds.tables!weapons On If( sw Is Nothing , 0 , sw.field(Of int32)("WeaponsID")) Equals   r2.field(Of int32)("id") Into child2 = Group
'From w In child2.DefaultIfEmpty
'Group sus By key = New With{
'	Key .id = sus.field(Of int32)("id"),
'	Key .suspect_name = sus.field(Of String)("description")
'} Into g1 = Group
'Select New With {
'	.id = Key.id,
'	.suspect_name = Key.suspect_name
'}






'Select New With{
'	.id = sus.field(Of int32)("id"),
'	.suspect_name = sus.field(Of String)("description"),
'	.suspectsid = If(sw Is Nothing , Nothing, sw.field(Of int32)("SuspectsID")),
'	.weaponsid = If(sw Is Nothing , Nothing, sw.field(Of int32)("WeaponsID")),
'	.weapon_name = If(w Is Nothing , Nothing  , w.field(Of String)("description"))
'}
	

qry2.dump()
qry.dump()


	
	
	
	
	
End Sub


Function CLUEDO() As System.Data.DataSet





    Dim ds As New System.Data.DataSet
    Dim dt As System.Data.DataTable
    Dim col As System.Data.DataColumn

    dt = New DataTable("Suspects")
    col = New System.Data.DataColumn
    With col
        .ColumnName = "id"
        .DataType = GetType(Integer)
        .AutoIncrement = True
        .AutoIncrementStep = 1
        .AutoIncrementSeed = 1
    End With
    dt.Columns.Add(col)

    col = New System.Data.DataColumn
    With col
        .ColumnName = "description"
        .DataType = GetType(String)
    End With
    dt.Columns.Add(col)


    dt.Rows.Add(Nothing, "Miss Scarlett")
    dt.Rows.Add(Nothing, "Colonel Mustard")
    dt.Rows.Add(Nothing, "Mrs. White")
    dt.Rows.Add(Nothing, "Reverend Green")
    dt.Rows.Add(Nothing, "Mrs. Peacock")
    dt.Rows.Add(Nothing, "Professor Plum")

    ds.Tables.Add(dt)




    dt = New DataTable("Weapons")
    col = New System.Data.DataColumn
    With col
        .ColumnName = "id"
        .DataType = GetType(Integer)
        .AutoIncrement = True
        .AutoIncrementStep = 1
        .AutoIncrementSeed = 1
    End With
    dt.Columns.Add(col)

    col = New System.Data.DataColumn
    With col
        .ColumnName = "description"
        .DataType = GetType(String)
    End With
    dt.Columns.Add(col)


    dt.Rows.Add(Nothing, "Candlestick")
    dt.Rows.Add(Nothing, "Dagger")
    dt.Rows.Add(Nothing, "Lead pipe")
    dt.Rows.Add(Nothing, "Revolver")
    dt.Rows.Add(Nothing, "Rope")
    dt.Rows.Add(Nothing, "Spanner/wrench")

    ds.Tables.Add(dt)






    dt = New DataTable("Rooms")
    col = New System.Data.DataColumn
    With col
        .ColumnName = "id"
        .DataType = GetType(Integer)
        .AutoIncrement = True
        .AutoIncrementStep = 1
        .AutoIncrementSeed = 1
    End With
    dt.Columns.Add(col)

    col = New System.Data.DataColumn
    With col
        .ColumnName = "description"
        .DataType = GetType(String)
    End With
    dt.Columns.Add(col)

    dt.Rows.Add(Nothing, "Ballroom")
    dt.Rows.Add(Nothing, "Kitchen")
    dt.Rows.Add(Nothing, "Conservatory")
    dt.Rows.Add(Nothing, "Dining Room")
    dt.Rows.Add(Nothing, "Cellar")
    dt.Rows.Add(Nothing, "Billiard Room")
    dt.Rows.Add(Nothing, "Library")
    dt.Rows.Add(Nothing, "Hall")
    dt.Rows.Add(Nothing, "Lounge")
    dt.Rows.Add(Nothing, "Study")

    ds.Tables.Add(dt)












    dt = New DataTable("Suspects_Weapons")
    col = New System.Data.DataColumn
    With col
        .ColumnName = "id"
        .DataType = GetType(Integer)
        .AutoIncrement = True
        .AutoIncrementStep = 1
        .AutoIncrementSeed = 1
    End With
    dt.Columns.Add(col)

    col = New System.Data.DataColumn
    With col
        .ColumnName = "SuspectsID"
        .DataType = GetType(Integer)
    End With
    dt.Columns.Add(col)
    col = New System.Data.DataColumn
    With col
        .ColumnName = "WeaponsID"
        .DataType = GetType(Integer)
    End With
    dt.Columns.Add(col)

    ds.Tables.Add(dt)






    dt = New DataTable("Weapons_Rooms")
    col = New System.Data.DataColumn
    With col
        .ColumnName = "id"
        .DataType = GetType(Integer)
        .AutoIncrement = True
        .AutoIncrementStep = 1
        .AutoIncrementSeed = 1
    End With
    dt.Columns.Add(col)

    col = New System.Data.DataColumn
    With col
        .ColumnName = "WeaponsID"
        .DataType = GetType(Integer)
    End With
    dt.Columns.Add(col)

    col = New System.Data.DataColumn
    With col
        .ColumnName = "RoomsID"
        .DataType = GetType(Integer)
    End With
    dt.Columns.Add(col)



    ds.Tables.Add(dt)



    Return ds


End Function
