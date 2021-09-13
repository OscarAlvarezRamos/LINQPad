<Query Kind="Program">
  <Output>DataGrids</Output>
  <Reference>D:\VBProjects\electronic-court-calendar\scripts\objects\InformixService.dll</Reference>
  <Reference>D:\Visual Studio Projects\LinqLib\sourceCode\sourceCode\LinqLib\bin\Debug\LinqLib.dll</Reference>
  <Reference>D:\VBProjects\electronic-court-calendar\electronic-court-calendar\Bin\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-fees\prd-fees\Bin\System.Linq.Dynamic.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>LinqLib.Array</Namespace>
  <Namespace>LinqLib.DynamicCodeGenerator</Namespace>
  <Namespace>LinqLib.Operators</Namespace>
  <Namespace>LinqLib.Sequence</Namespace>
  <Namespace>LinqLib.Sort</Namespace>
  <Namespace>LinqLib.Sort.Sorters</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Linq.Dynamic</Namespace>
</Query>

void Main()
{
	
	    List<Contact> contacts = Generator.CreateContacts();
		
		contacts.Pivot(X => X.Phones, X => X.PhoneType, X => string.Concat("(", X.AreaCode, ") ", X.PhoneNumber), true).ToArray().Dump();
		contacts.Pivot(X => X.Addresses, X => X.AddressType, X => string.Concat(X.City, " [", X.State, "]", X.Active  ), true).ToArray().Dump();	
	
		contacts.Dump();
		
	
}

// Define other methods and classes here

  public static class Generator
  {
    public static List<Contact> CreateContacts()
    {
      return new List<Contact>
      {
        new Contact { Id = 1, FirstName = "John"  , LastName = "Doe", Phones = new List<Phone> { new Phone("Home",   "305", "555-1111"),
                                                                                                 new Phone("Office", "305", "555-2222"),
                                                                                                 new Phone("Cell",   "305", "555-3333")}
                                                                , Addresses = new List<Address>{ new Address{ AddressType ="Home",   City="Miami", State="FL", Street="123 Main Street",Active = true},
                                                                                                 new Address{ AddressType ="Office", City="Miami", State="FL", Street="123 Main Street",Active = false}}},

		
		
		new Contact { Id = 2, FirstName = "Jane"  , LastName = "Doe", Phones = new List<Phone> { new Phone("Home",   "305", "555-1111"),
                                                                                                 new Phone("Office", "305", "555-4444"),
                                                                                                 null,
                                                                                                 new Phone("Cell",   "305", "555-5555")}
                                                                , Addresses = new List<Address>{ new Address{ AddressType ="Home",   City="Davie",   State="FL", Street="123 Main Street",Active = true},
                                                                                                 new Address{ AddressType ="Office", City="Pompano", State="FL", Street="123 Main Street",Active = true}}},
        new Contact { Id = 3, FirstName = "Jerome", LastName = "Doe", Phones = new List<Phone> { new Phone("Home",   "305", "555-6666"),
                                                                                                 new Phone("Office", "305", "555-2222"),
                                                                                                 new Phone("Cell",   "305", "555-7777")}},


          new Contact {
              Id = 4,
              FirstName = "Joel",
              LastName = "Smith",
              Phones = new List<Phone> {
                  new Phone("Fax",    "305", "555-6666"),
                  new Phone("Office", "305", "555-2222"),
                  new Phone("Cell2",  "305", "555-7778"),
                  new Phone("Cell",   "305", "555-7777"),
                  new Phone("Cell",   "888", "111-2222")
          }
      }};
    }
  }




 public class Contact
  {
    public int Id;

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PhonesCount { get { return Phones.Count; } }

    public List<Phone> Phones { get; set; }
    public List<Address> Addresses { get; set; }
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
  
  
  
  
  
    public class Address
  {
    public string AddressType { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
	public bool Active { get; set; }
	
  }