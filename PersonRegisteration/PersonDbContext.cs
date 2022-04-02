using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonRegisteration;

namespace PersonRegisteration
{
    public class PersonDbContext:DbContext
    {
        public PersonDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        public DbSet<Personality> Personality { get; set; }
        public DbSet<PersonPersonality> PersonPersonality { get; set; }
    }
}
