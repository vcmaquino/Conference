using Conferencia.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Conferencia.Infra.Context
{
    public class ConferenceMercadoTechContext : DbContext
    {
        public DbSet<OrderEntity> Order { get; set; }


        public ConferenceMercadoTechContext(DbContextOptions<ConferenceMercadoTechContext> options) : base(options)
        {
          //  Database.EnsureCreated();
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              base.OnConfiguring(optionsBuilder);
        }
    }
}