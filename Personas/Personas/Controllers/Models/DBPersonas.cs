using Personas.Controllers.Entities;

using Microsoft.EntityFrameworkCore;

namespace DBPersonas
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PersonasDb");
        }
        public DbSet<Persona> Personas { get; set; }
    }
}
