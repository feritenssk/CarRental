using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Entities;

namespace CarRental.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options) 
        {
        } 

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }
}
