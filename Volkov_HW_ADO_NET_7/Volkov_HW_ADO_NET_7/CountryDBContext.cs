using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_ADO_NET_7
{
    internal class CountryDBContext : DbContext
    {

        public DbSet<Country> Countries { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=DESKTOP-1147B1S;Database=Countrys;Integrated Security=SSPI;TrustServerCertificate=true");
        }
    }
}
