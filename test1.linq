<Query Kind="Program">
  <Output>DataGrids</Output>
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\LinqLib.dll</Reference>
  <Reference>D:\VBProjects\prd-special-rpt\prd-special-rpt\bin\Debug\System.Linq.Dynamic.dll</Reference>
  <Namespace>LinqLib.Array</Namespace>
  <Namespace>LinqLib.DynamicCodeGenerator</Namespace>
  <Namespace>LinqLib.Operators</Namespace>
  <Namespace>LinqLib.Sequence</Namespace>
  <Namespace>LinqLib.Sort</Namespace>
  <Namespace>System.Linq.Dynamic</Namespace>
</Query>

void Main()
{
 List<Contact> contacts = Generator.CreateContacts();
//contacts.Dump();



contacts.Pivot(X => X.Phones, X => X.PhoneType, X => string.Concat("(", X.AreaCode, ") ", X.PhoneNumber), true);




}



public class Contact
  {
    public int Id;

    public string FirstName { get; set; }
    public string LastName { get; set; }
 
    public List<Phone> Phones { get; set; }
   }

 public class Phone
  {
    public Phone(string phoneType, string areaCode, string phoneNumber)
    {
      this.PhoneType = phoneType;
      this.AreaCode = areaCode;
      this.PhoneNumber = phoneNumber;
    }

    public string PhoneType { get; set; }
    public string AreaCode { get; set; }
    public string PhoneNumber { get; set; }
	}
	
	
	
 public static class Generator
  {
    public static List<Contact> CreateContacts()
    {
      return new List<Contact>
      {
        new Contact { Id = 1, FirstName = "John"  , LastName = "Doe", Phones = new List<Phone> { new Phone("Home",   "305", "555-1111"),
                                                                                                 new Phone("Office", "305", "555-2222"),
                                                                                                 new Phone("Cell",   "305", "555-3333")} },
        new Contact { Id = 2, FirstName = "Jane"  , LastName = "Doe", Phones = new List<Phone> { new Phone("Home",   "305", "555-1111"),
                                                                                                 new Phone("Office", "305", "555-4444"),
                                                                                                 new Phone("Cell",   "305", "555-5555")} },
        new Contact { Id = 3, FirstName = "Jerome", LastName = "Doe", Phones = new List<Phone> { new Phone("Home",   "305", "555-6666"),
                                                                                                 new Phone("Office", "305", "555-2222"),
                                                                                                 new Phone("Cell",   "305", "555-7777")} },
        new Contact { Id = 4, FirstName = "Joel", LastName = "Smith", Phones = new List<Phone> { new Phone("Fax",    "305", "555-6666"),
                                                                                                 new Phone("Office", "305", "555-2222"),
                                                                                                 new Phone("Cell2",  "305", "555-7778"),
                                                                                                 new Phone("Cell",   "305", "555-7777")}
      } };
    }
  }

	
  
  