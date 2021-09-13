<Query Kind="VBProgram">
  <Output>DataGrids</Output>
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\LinqLib.dll</Reference>
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\System.Linq.Dynamic.dll</Reference>
  <Namespace>LinqLib.Array</Namespace>
  <Namespace>LinqLib.DynamicCodeGenerator</Namespace>
  <Namespace>LinqLib.Operators</Namespace>
  <Namespace>LinqLib.Sequence</Namespace>
  <Namespace>LinqLib.Sort</Namespace>
</Query>

Sub Main
	
	Dim result As New list(Of employee) 
	result = generator.CreateData
	
	
	
'	
'	Dim qry1 = From a In result 
'	Group a By key = New With {
'	Key a.fullname,
'	Key a.department} Into g1= Group
'	Select key .fullname,
'	key .department
	
	
	
Dim qry1 = From a In result
	Select New employee With {
		.id = a.ID,
		.fullname = a.fullname,
		.department = a.department,
		.phones = (
			From b In a.phones
			Group b By key = New With { Key b.phone_type } Into g1 = Group
				Select New phone With {
					.phone_type = key.phone_type ,
					.phone_number  =  (From b In g1 Order By b.phone_number ).Aggregate(New System.Text.StringBuilder, Function(cur, nxt) cur.AppendFormat(", {0}",  nxt.phone_number )).ToString.Substring(1)
				}	
			).tolist()
		}
	
	



'
'
'	Dim qry1 = From a In result
'	Select New employee With
'	{
'		.fullname = a.fullname,
'		.department = a.department,
'		.phones = ( From b In a.phones Select New phone With { .phone_type  = b.phone_type , .phone_number  = b.phone_number }  ).tolist()
'	}
'	
'		
'


'
'
'
'	qry1.dump()
'
'
'	result.dump()
'	result.Pivot(Function(x) x.phones , Function(x) x.phone_type , Function(x) x.phone_number, True).dump()

	qry1.Pivot(Function(x) x.phones , Function(x) x.phone_type , Function(x) x.phone_number, True).ToArray().dump()
	
	
End Sub


Public Class Generator
	Private Sub New()

	End Sub
	
	Public Shared Function CreateData() As List (Of employee)
		Return New list(Of employee)() From {
			New employee With{
				.ID = 1,
				.fullname = "John Smith",
				.department = "Sales",
				.phones = New list(Of phone)() From {
					New phone("Home","787-111-1111"),
					New phone("Work","787-222-2222"),
					New phone("Work","787-333-3333"),
					New phone("Lot 1","787-444-4444")
					}
				},
			New employee With{
				.ID = 2,
				.fullname = "Bob White",
				.department = "Marketing",
				.phones = New list(Of phone)() From {
					New phone("Home","787-999-9999"),
					New phone("Work","787-888-8888"),
					New phone("Office","787-888-8888"),
					New phone("Mobile","787-777-7777")
				}
			},
			New employee With{
				.ID = 3,
				.fullname = "Oscar Alvarez",
				.department = "System",
				.phones = New list(Of phone)() From {
					New phone("Home","787-999-1111")
				}
			}}
		
	End Function
	
	
	
	
End Class




' Define other methods and classes here
Public Class employee


	Public Property ID() As Integer
		Get 
			Return m_ID
		End Get
		Set(value As Integer)
			m_ID = value
		End Set
	End Property
	Private m_ID As Integer

	
	Public Property fullname() As String
		Get 
			Return m_fullname
		End Get
		Set(value As String)
			m_fullname = value
		End Set
	End Property
	Private m_fullname As String
	
	
	
	Public Property department() As String
		Get 
			Return m_department
		End Get
		Set(value As String)
			m_department = value
		End Set
	End Property
	Private m_department As String
	
	
	
	
	
 	Public Property phones As list(Of phone)
		Get 
			Return m_phones
		End Get
		Set(value As list(Of phone))
			m_phones = value
		End Set
	End Property
	Private m_phones As list(Of phone)


End Class




Public Class phone

	
	Public Sub New(phone_type As String, phone_number As String)
	    Me.phone_type = phone_type
	    Me.phone_number = phone_number
	End Sub
	
	Sub New()
	    ' TODO: Complete member initialization 
	End Sub




	
	Public Property phone_type() As String
		Get 
			Return m_phone_type
		End Get
		Set(value As String)
			m_phone_type = value
		End Set
	End Property
	Private m_phone_type As String
	
	
	
	
	
	Public Property phone_number() As String
		Get 
			Return m_phone_number
		End Get
		Set(value As String)
			m_phone_number = value
		End Set
	End Property
	Private m_phone_number As String
	
 



End Class