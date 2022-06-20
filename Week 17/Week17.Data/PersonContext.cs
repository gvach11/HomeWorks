using Microsoft.EntityFrameworkCore;
using Week17.Domain;

namespace Week17.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext()
        {
        }

        public PersonContext(DbContextOptions<PersonContext> options) :
        base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }


    }
}
