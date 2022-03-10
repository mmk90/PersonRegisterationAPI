using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonRegisteration
{
    public class PersonDbContext:DbContext
    {
        public PersonDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
