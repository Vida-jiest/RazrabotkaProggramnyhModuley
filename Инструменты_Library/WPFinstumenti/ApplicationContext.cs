using Microsoft.EntityFrameworkCore;
using protected_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFinstumenti
{

    internal class ApplicationContext : DbContext
    {
    public DbSet<Protected> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KUAK6NE\\SQLEXPRESS;Database=protected_Library; TrustServerCertificate=True");
        }
    }
}