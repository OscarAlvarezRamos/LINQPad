<Query Kind="Program">
  <Output>DataGrids</Output>
  <Reference>D:\VBProjects\electronic-court-calendar\scripts\objects\InformixService.dll</Reference>
  <Reference>D:\VBProjects\electronic-court-calendar\electronic-court-calendar\Bin\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>D:\VBProjects\prd-fees\prd-fees\Bin\System.Linq.Dynamic.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
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
	

	List<employee> employees= new List<employee>()
	{
		new employee() { id = 1, parent_id = 0, fname = "Leila", lname = "Houston", email = "mauris.Morbi.non@luctussit.com", dob = DateTime.ParseExact("02/10/2016", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 2, parent_id = 1, fname = "Joseph", lname = "Wright", email = "Phasellus.nulla@Morbi.org", dob = DateTime.ParseExact("09/24/1971", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 3, parent_id = 2, fname = "Harding", lname = "Morgan", email = "iaculis@elitfermentum.com", dob = DateTime.ParseExact("11/17/1995", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 4, parent_id = 2, fname = "Neville", lname = "Sykes", email = "lorem.vehicula.et@etmalesuada.co.uk", dob = DateTime.ParseExact("09/10/1977", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 5, parent_id = 2, fname = "Iris", lname = "Harper", email = "sed.sapien@viverraMaecenas.ca", dob = DateTime.ParseExact("08/17/2014", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 6, parent_id = 1, fname = "Cassidy", lname = "Arnold", email = "Phasellus@justositamet.co.uk", dob = DateTime.ParseExact("06/08/1983", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 7, parent_id = 1, fname = "Laurel", lname = "Macias", email = "ante.blandit.viverra@metussitamet.com", dob = DateTime.ParseExact("08/19/1981", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 8, parent_id = 6, fname = "Abigail", lname = "Conley", email = "hendrerit.consectetuer.cursus@felisullamcorper.com", dob = DateTime.ParseExact("08/16/1971", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 9, parent_id = 5, fname = "Daniel", lname = "Abbott", email = "Etiam.imperdiet.dictum@amet.co.uk", dob = DateTime.ParseExact("08/02/1959", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 10, parent_id = 0, fname = "Margaret", lname = "Griffin", email = "pharetra.sed.hendrerit@Duis.edu", dob = DateTime.ParseExact("02/18/1954", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 11, parent_id = 5, fname = "Leroy", lname = "Fernandez", email = "nibh.Quisque@odioEtiam.net", dob = DateTime.ParseExact("02/03/1958", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 12, parent_id = 2, fname = "Ulric", lname = "Rios", email = "turpis.nec@orciUtsemper.net", dob = DateTime.ParseExact("06/09/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 13, parent_id = 3, fname = "Ivy", lname = "Parker", email = "Duis.dignissim@Sed.co.uk", dob = DateTime.ParseExact("03/10/1974", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 14, parent_id = 11, fname = "Tiger", lname = "Swanson", email = "lectus@turpis.co.uk", dob = DateTime.ParseExact("12/25/1980", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 15, parent_id = 13, fname = "Hiram", lname = "Levy", email = "ipsum@velconvallis.edu", dob = DateTime.ParseExact("06/16/1986", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 16, parent_id = 6, fname = "Olivia", lname = "Petersen", email = "nec.ante.Maecenas@ligulaAenean.com", dob = DateTime.ParseExact("03/24/1947", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 17, parent_id = 2, fname = "Fredericka", lname = "Riggs", email = "in@convallis.net", dob = DateTime.ParseExact("02/04/1985", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 18, parent_id = 6, fname = "Bertha", lname = "Hebert", email = "cursus@Nuncac.com", dob = DateTime.ParseExact("06/06/1974", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 19, parent_id = 9, fname = "Noble", lname = "Fulton", email = "gravida.sagittis@maurisanunc.com", dob = DateTime.ParseExact("07/13/1986", "MM/dd/yyyy", CultureInfo.InvariantCulture) },
		new employee() { id = 20, parent_id = 19, fname = "Austin", lname = "Heath", email = "amet.lorem.semper@PhasellusornareFusce.ca", dob = DateTime.ParseExact("09/22/2018", "MM/dd/yyyy", CultureInfo.InvariantCulture) }
	};

	
	List<employee> hierarchy = new List<employee>();
            hierarchy = employees
                            .Where(c => c.parent_id == 0)
                            .Select(c => new employee() { 
                                  id = c.id, 
                                  fname = c.fname, 
								  lname=c.lname,
								  email=c.email,
								  dob=c.dob,
                                  parent_id = c.parent_id,
								  Children = GetChildren(employees, c.id)}
								  )
                            .ToList();


var tmp = JsonConvert.SerializeObject(hierarchy, Newtonsoft.Json.Formatting.Indented);



	hierarchy.Dump();
	
	tmp.ToString().Dump();
	



	
}

// Define other methods and classes here



public static class RecursiveJoinExtensions
{
   public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
      Func<TSource, TKey> parentKeySelector,
      Func<TSource, TKey> childKeySelector,
      Func<TSource, IEnumerable<TResult>, TResult> resultSelector)
   {
      return RecursiveJoin(source, parentKeySelector, childKeySelector,
         resultSelector, Comparer<TKey>.Default);
   }

   public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
      Func<TSource, TKey> parentKeySelector,
      Func<TSource, TKey> childKeySelector,
      Func<TSource, int, IEnumerable<TResult>, TResult> resultSelector)
   {
      return RecursiveJoin(source, parentKeySelector, childKeySelector,
         (TSource element, int depth, int index, IEnumerable<TResult> children)
            => resultSelector(element, index, children));
   }

   public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
      Func<TSource, TKey> parentKeySelector,
      Func<TSource, TKey> childKeySelector,
      Func<TSource, IEnumerable<TResult>, TResult> resultSelector,
      IComparer<TKey> comparer)
   {
      return RecursiveJoin(source, parentKeySelector, childKeySelector,
         (TSource element, int depth, int index, IEnumerable<TResult> children)
            => resultSelector(element, children), comparer);
   }

   public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
      Func<TSource, TKey> parentKeySelector,
      Func<TSource, TKey> childKeySelector,
      Func<TSource, int, IEnumerable<TResult>, TResult> resultSelector,
      IComparer<TKey> comparer)
   {
      return RecursiveJoin(source, parentKeySelector, childKeySelector,
         (TSource element, int depth, int index, IEnumerable<TResult> children)
            => resultSelector(element, index, children), comparer);
   }

   public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
      Func<TSource, TKey> parentKeySelector,
      Func<TSource, TKey> childKeySelector,
      Func<TSource, int, int, IEnumerable<TResult>, TResult> resultSelector)
   {
      return RecursiveJoin(source, parentKeySelector, childKeySelector,
         resultSelector, Comparer<TKey>.Default);
   }

   public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
      Func<TSource, TKey> parentKeySelector,
      Func<TSource, TKey> childKeySelector,
      Func<TSource, int, int, IEnumerable<TResult>, TResult> resultSelector,
      IComparer<TKey> comparer)
   {
      // prevent source being enumerated more than once per RecursiveJoin call
      source = new LinkedList<TSource>(source);

      // fast binary search lookup
      SortedDictionary<TKey, TSource> parents = new SortedDictionary<TKey, TSource>(comparer);
      SortedDictionary<TKey, LinkedList<TSource>> children
         = new SortedDictionary<TKey, LinkedList<TSource>>(comparer);

      foreach (TSource element in source)
      {
         parents[parentKeySelector(element)] = element;

         LinkedList<TSource> list;

         TKey childKey = childKeySelector(element);

         if (!children.TryGetValue(childKey, out list))
         {
            children[childKey] = list = new LinkedList<TSource>();
         }

         list.AddLast(element);
      }

      // initialize to null otherwise compiler complains at single line assignment
      Func<TSource, int, IEnumerable<TResult>> childSelector = null;

      childSelector = (TSource parent, int depth) =>
      {
         LinkedList<TSource> innerChildren = null;

         if (children.TryGetValue(parentKeySelector(parent), out innerChildren))
         {
            return innerChildren.Select((child, index)
               => resultSelector(child, index, depth, childSelector(child, depth + 1)));
         }

         return Enumerable.Empty<TResult>();
      };

      return source.Where(element => !parents.ContainsKey(childKeySelector(element)))
         .Select((element, index) => resultSelector(element, index, 0, childSelector(element, 1)));
   }
}


































   public class employee
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public string fname { get; set; }        
        public string lname { get; set; }        
        public string email { get; set; }        
		public DateTime dob{get;set;}
        public List<employee> Children { get; set; }
    }




        public static List<employee> GetChildren(List<employee> employees, int parent_id)
        {
            return employees
                    .Where(c => c.parent_id== parent_id)
                    .Select(c => new employee { 
						id = c.id, 
						fname = c.fname, 
						lname=c.lname,
						email=c.email,
						dob=c.dob,
						parent_id = c.parent_id,						
						Children = GetChildren(employees, c.id)})
                    .ToList();
        }