using Microsoft.EntityFrameworkCore;
using R_home.Core.Models;
using R_home.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_home.Data
{
    public class DataContext: DbContext
    {

        public DbSet<Baby> babies { get; set; }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Room> rooms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=my_db");
        }

        


    }
}
