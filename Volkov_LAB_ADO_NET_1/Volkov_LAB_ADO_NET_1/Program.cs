namespace Volkov_LAB_ADO_NET_1
{
    internal class Program
    {
        class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public int DepId { get; set; }
        }
        class Department
        {
            public int Id { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
        }

        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>()
            { 
                new Department(){ Id = 1, Country = "Ukraine", City = "Odesa"},
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = " Ukraine ", City = "Lviv"}    
            };
            List<Employee> employees = new List<Employee>()
             {
             new Employee()
             {
                Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2
             },
             new Employee()
             {
             Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1
             },
             new Employee()
             {
             Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3
             },
             new Employee()
             {
             Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2
             },
             new Employee()
             {
             Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4
             },
             new Employee()
             {
             Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2
             },
             new Employee()
             {
             Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4
             }
             };


            var res = from i in employees
                         join j in departments on i.DepId equals j.Id
                         where j.Country.Trim().ToLower() == "ukraine"
                         orderby i.LastName, i.FirstName
                         select new
                         {
                             FullName = $"{i.FirstName} {i.LastName}",
                             Department = j.City
                         };

            foreach (var i in res)
            {
                Console.WriteLine($"Name: {i.FullName}, Department: {i.Department}");
            }

            Console.WriteLine("\n\n");


            var res2 = employees.OrderByDescending(i => i.Age).Select(i => new { i.Id, i.FirstName, i.LastName, i.Age });

            foreach (var i in res2)
            {
                Console.WriteLine($"Id: {i.Id}, FirstName: {i.FirstName}, LastName: {i.LastName}, Age: {i.Age}");
            }



            Console.WriteLine("\n\n");

            var res3 = employees.GroupBy(i => i.Age).Select(i => new { Age = i.Key, Count = i.Count() });

            foreach (var i in res3)
            {
                Console.WriteLine($"Age: {i.Age}, Count: {i.Count}");
            }
        }
    }
}
