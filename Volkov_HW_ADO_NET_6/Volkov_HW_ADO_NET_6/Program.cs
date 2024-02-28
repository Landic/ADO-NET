
namespace Volkov_HW_ADO_NET_6
{
    internal class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
        }

        public static void Output(string output, IEnumerable<Person> person)
        {
            Console.WriteLine(output);
            foreach (var i in person)
            {
                Console.WriteLine($"{i.Name}, {i.Age}, {i.City}");
            }
        }

        static void Main(string[] args)
        {
            List<Person> person = new List<Person>()
            {
                new Person(){ Name = "Andrey", Age = 24, City = "Kyiv"},
                new Person(){ Name = "Liza", Age = 18, City = "Odesa" },
                new Person(){ Name = "Oleg", Age = 15, City = "London" },
                new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
                new Person(){ Name = "Sergey", Age = 32, City = "Lviv" }
            };

            var older25 = person.Where(i => i.Age > 25);
            Output("Старше 25:", older25);


            var Not_In_London = person.Where(i => i.City != "London");
            Output("\n\nНаходящиеся не в Лондоне:", Not_In_London);



            var kyiv = person.Where(i => i.City == "Kyiv").Select(i => i.Name);
            Console.WriteLine("\n\nКиев:");
            foreach (var i in kyiv)
            {
                Console.WriteLine(i);
            }



            var Older_35_Sergeys = person.Where(i => i.Name == "Sergey" && i.Age > 35);
            Output("\n\nСергеи старше 35:", Older_35_Sergeys);


            var Live_Odessa = person.Where(i => i.City == "Odesa");
            Output("\n\nЖивущие в Одессе:", Live_Odessa);
        }
    }
}
