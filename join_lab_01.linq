<Query Kind="VBProgram">
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

Sub Main
	
	Dim result As New list(Of food) 
	result = foods.CreateData
	
	
'	
'	result.dump()
	
	
	
'	
'	Dim qry1 = From f In result
	
	
	
	Dim doc As xdocument = New xdocument(
			New xelement("table" ,New xattribute("border",1),New xattribute("style","width:100%"), 
				New xelement("thead",
					New xelement("tr",
						New xelement("th","Type"),
						New xelement("th","Name"),
						New xelement("th","Store")
						)), 
				New xelement("tbody",
						From r In result 
						Select New xelement("tr",
							New xelement("td",r.type),
							New xelement("td",r.name),							
							New xelement("td", r.store)
						)
				)))
	
	
	
	doc.tostring.dump()
	
	
	
	result.dump()
	
	
	
	
	
	
End Sub

' Define other methods and classes here


Public Class foods
	Private Sub New()

	End Sub
	
	
	Public Shared Function CreateData() As list(Of food)
	Return New list(Of food)() From {	
		New food With{
			.ID = 1,
			.type = "Fruit",
			.name="Apple",
			.store = "Alpha Store"
			},
		New food With{
			.ID = 2,
			.type = "Fruit",
			.name="Apple",
			.store = "Lorem ipsum <font color=red>dolor sit</FONT> amet, consectetur adipiscing elit."
			},
		New food With{
			.ID = 3,
			.type = "Fruit",
			.name="Banana",
			.store = "Alpha Store"
			}
	}	
	End Function
	


End Class


Public Class food


	Public Property ID() As Integer
		Get 
			Return m_ID
		End Get
		Set(value As Integer)
			m_ID = value
		End Set
	End Property
	Private m_ID As Integer





	Public Property type() As String
		Get 
			Return m_type
		End Get
		Set(value As String)
			m_type = value
		End Set
	End Property
	Private m_type As String
	
	Public Property name() As String
		Get 
			Return m_name
		End Get
		Set(value As String)
			m_name = value
		End Set
	End Property
	Private m_name As String
	
	
	Public Property store() As String
		Get 
			Return m_store
		End Get
		Set(value As String)
			m_store = value
		End Set
	End Property
	Private m_store As String


End Class