namespace Volkov_LAB_ADO_NET_2
{
    internal class Program
    {
        internal class Good
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public double Price {  get; set; }
            public string Category {  get; set; }
        }

        static void Main(string[] args)
        {
            List<Good> goods1 = new List<Good>()
            {
                new Good()
                { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
                new Good()
                { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
                new Good()
                { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
                new Good()
                { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
                new Good()
                { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
                new Good()
                 { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
                new Good()
                 { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
                new Good()
                 { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
                new Good()
                 { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
                new Good()
                 { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
            };



            var mobiles = goods1.Where(i => i.Category == "Mobile" && i.Price > 1000);
            foreach (var i in mobiles)
            {
                Console.WriteLine($"{i.Title} - {i.Price}");
            }

            Console.WriteLine("\n\n\n");


            var nonKitchenGoods = goods1.Where(i => i.Category != "Kitchen" && i.Price > 1000);
            foreach (var i in nonKitchenGoods)
            {
                Console.WriteLine($"{i.Title} - {i.Price}");
            }


            Console.WriteLine("\n\n\n");

            double avgPrice = goods1.Average(i => i.Price);
            Console.WriteLine($"Средняя цена: {avgPrice}");


            Console.WriteLine("\n\n\n");

            var distinct = goods1.Select(i => i.Category).Distinct();
            foreach (var i in distinct)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("\n\n\n");

            var sorted = goods1.OrderBy(i => i.Title);
            foreach (var i in sorted)
            {
                Console.WriteLine($"{i.Title} - {i.Category}");
            }


            Console.WriteLine("\n\n\n");


            int totalCount = goods1.Count(i => i.Category == "Car" || i.Category == "Mobile");
            Console.WriteLine($"Суммарное количество товаров категорий - {totalCount}");


            Console.WriteLine("\n\n\n");

            var categoryCount = goods1.GroupBy(i => i.Category).Select(i => new { Category = i.Key, Count = i.Count() });
            foreach (var i in categoryCount)
            {
                Console.WriteLine($"{i.Category} - {i.Count}");
            }
        }
    }
}
