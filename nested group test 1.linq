<Query Kind="FSharpProgram">
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



    Dim ds As New System.Data.DataSet
    Dim dt As System.Data.DataTable
    Dim col As System.Data.DataColumn

    dt = New DataTable("case_data")
	
'	
'    col = New System.Data.DataColumn
'    With col
'        .ColumnName = "id"
'        .DataType = GetType(Integer)
'        .AutoIncrement = True
'        .AutoIncrementStep = 1
'        .AutoIncrementSeed = 1
'    End With
'    dt.Columns.Add(col)
'	
	

    col = New System.Data.DataColumn
    With col
        .ColumnName = "case_number"
        .DataType = GetType(String)
    End With
    dt.Columns.Add(col)

    col = New System.Data.DataColumn
    With col
        .ColumnName = "proceeding_date"
        .DataType = GetType(datetime)
    End With
    dt.Columns.Add(col)

	col = New System.Data.DataColumn
    With col
        .ColumnName = "proceeding_desc"
        .DataType = GetType(String)
    End With
    dt.Columns.Add(col)

	col = New System.Data.DataColumn
    With col
        .ColumnName = "jud_name"
        .DataType = GetType(String)
    End With
    dt.Columns.Add(col)

	col = New System.Data.DataColumn
    With col
        .ColumnName = "party_name"
        .DataType = GetType(String)
    End With
    dt.Columns.Add(col)

	col = New System.Data.DataColumn
    With col
        .ColumnName = "attorney_name"
        .DataType = GetType(String)
    End With
    dt.Columns.Add(col)


	dt.rows.add("17-0001","12/07/2017 08:00:00","Proceeding A","ADC","Party 1","Atty 1")
	dt.rows.add("17-0001","12/07/2017 08:00:00","Proceeding A","ADC","Party 1","Atty 2")
	dt.rows.add("17-0001","12/07/2017 08:00:00","Proceeding A","ADC","Party 1","Atty 3")
	
	dt.rows.add("17-0001","12/07/2017 08:00:00","Proceeding A","ADC","Party 2","Atty 1")
	dt.rows.add("17-0001","12/07/2017 08:00:00","Proceeding A","ADC","Party 2","Atty 2")
	dt.rows.add("17-0001","12/07/2017 08:00:00","Proceeding A","ADC","Party 2","Atty 3")

	dt.rows.add("17-0002","12/07/2017 08:30:00","Proceeding A","ADC","Party 1","Atty 1")
	dt.rows.add("17-0002","12/07/2017 08:30:00","Proceeding A","ADC","Party 1","Atty 2")
	dt.rows.add("17-0002","12/07/2017 08:30:00","Proceeding A","ADC","Party 1","Atty 3")

	dt.rows.add("17-0002","12/07/2017 08:30:00","Proceeding A","CCC","Party 1","Atty a1")
	dt.rows.add("17-0002","12/07/2017 08:30:00","Proceeding A","CCC","Party 1","Atty a2")
	dt.rows.add("17-0002","12/07/2017 08:30:00","Proceeding A","CCC","Party 1","Atty a3")



    ds.Tables.Add(dt)

	
	Dim qry1 = From a In ds.tables(0).asenumerable
	Group a By dates = New With{
		Key .proceeding_date = a.field(Of datetime)("proceeding_date")
	} Into g1 = Group
	Select 
	dates.proceeding_date,
	judges = From widget In g1 Group widget By judges = New With {
			Key .jud_name = widget.field(Of String)("jud_name")
		} Into g2 = Group
		Select judges.jud_name,
		cnt = g2.count()

	qry1.dump()
	
//	Dim str As String = JsonConvert.SerializeObject(qry1)
//    str.dump()
//	
	
	
	
Dim tmp1 = JsonConvert.SerializeObject(
	New jarray(
		New jObject(
			New jProperty("case_data",
				New jarray(
					New jobject(
						New jproperty("id",1),
						New jproperty("name","John")
					),
					New jobject(
						New jproperty("id",2),
						New jproperty("name","James")
					),
					New jobject(
						New jproperty("id",3),
						New jproperty("name","Robert")
					)
				)
			)
		)
	)
)


tmp1.dump()
	