using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Conferencia.Infra.Context
{
    public static class ContextFactory
    {
        public static void CreateDbContext(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ConferenceMercadoTechContext>(
             options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ConferenciaMercadoTech;User Id=sa;Password=sa;MultipleActiveResultsets=true;Encrypt=YES;TrustServerCertificate=YES"));
        }
    }
}
