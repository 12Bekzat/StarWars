using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsCards
{
    public class Context : DbContext
    {
        private readonly string connectionString;
        public Context(string connString)
        {
            Database.EnsureCreated();
            connectionString = connString;
        }

        public DbSet<Result> Elements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
