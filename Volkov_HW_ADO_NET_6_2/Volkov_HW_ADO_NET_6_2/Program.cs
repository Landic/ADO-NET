namespace Volkov_HW_ADO_NET_6_2
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
                new Department(){ Id = 1, Country = "Ukraine", City = "Lviv" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Ukraine", City = "Odesa" }
             };
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee()
                { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee()
                { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee()
                { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee()
                { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee()
                { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee()
                { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27, DepId = 4 }
            };

            var ukrainianOdessa = employees.Where(i => departments.Any(j => j.Id == i.DepId && j.Country == "Ukraine" && j.City != "Odesa")).Select(i => new { i.FirstName, i.LastName });
            Console.WriteLine("Работники работающие в Украине но не в городе Одесса:");
            foreach (var i in ukrainianOdessa)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}");
            }





            var Countries = departments.Select(i => i.Country).Distinct();
            Console.WriteLine("\n\n\nСтраны без повторений:");
            foreach (var i in Countries)
            {
                Console.WriteLine(i);
            }


            var older25 = employees.Where(i => i.Age > 25).Take(3);
            Console.WriteLine("\n\n\nСтарше 25 работники первые 3:");
            foreach (var i in older25)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}, {i.Age}");
            }


            var KyivStudents23 = employees.Where(i => departments.Any(j => j.Id == i.DepId && j.City == "Kyiv") && i.Age > 23).Select(i => new { i.FirstName, i.LastName, i.Age });
            Console.WriteLine("\n\n\nСтуденты старше 23 лет в Киеве:");
            foreach (var i in KyivStudents23)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}, {i.Age}");
            }





            Console.WriteLine("////////////////////////////////////////////////////////////////////////////");

            //////////////////////////////////////////////////////////////////////////////////////////////



            var ukrainianOdessa2 = (from i in employees
                                                 join j in departments on i.DepId equals j.Id
                                                 where j.Country == "Ukraine" && j.City != "Odesa"
                                                 select new { i.FirstName, i.LastName }).ToList();
            Console.WriteLine("\n\n\nРаботники работающие в Украине но не в городе Одесса:");
            foreach (var i in ukrainianOdessa2)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}");
            }



            var Countries2 = departments.Select(i => i.Country).Distinct().ToList();
            Console.WriteLine("\n\n\nСтраны без повторений:");
            foreach (var i in Countries2)
            {
                Console.WriteLine(i);
            }



            var older252 = employees.Where(i => i.Age > 25).Take(3).ToList();
            Console.WriteLine("\n\n\nСтарше 25 работники первые 3:");
            foreach (var i in older252)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}, Age: {i.Age}");
            }




            var KyivStudents232 = (from i in employees
                                       join j in departments on i.DepId equals j.Id
                                       where j.City == "Kyiv" && i.Age > 23
                                       select new { i.FirstName, i.LastName, i.Age }).ToList();

            Console.WriteLine("\n\n\nСтуденты старше 23 лет в Киеве:");
            foreach (var i in KyivStudents232)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}, Age: {i.Age}");
            }
        }
    }
}
