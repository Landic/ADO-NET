namespace Volkov_HW_ADO_NET_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new CountryDBContext())
            {
                if (context.Database.EnsureCreated())
                {
                    context.Countries.AddRange(new List<Country>()
                    {
                        new Country(){ID = 1,Name = "Ukraine", NameCapital = "Kyiv", Population=40000000, Area = 603628, Continent="Europa"},
                        new Country(){ID = 2,Name = "Germany", NameCapital = "Berlin", Population=83200000, Area = 357592, Continent="Europa"},
                        new Country(){ID = 3,Name = "France", NameCapital = "Paris", Population=67750000, Area = 643801, Continent="Europa"},
                        new Country(){ID = 4,Name = "Spain", NameCapital = "Barcelona", Population=47420000, Area = 506030, Continent="Europa"},
                        new Country(){ID = 5,Name = "Poland", NameCapital = "Warsaw", Population=37750000, Area = 312696, Continent="Europa"}
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
