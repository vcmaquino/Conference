using Conferencia.Domain.Entity;
using Conferencia.Domain.IRepository;
using Conferencia.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Conferencia.Infra.Repository
{
    public class RepositoryOrder : RepositoryBase<OrderEntity>, IRepositoryOrder
    {
        private DbSet<OrderEntity> _dataset;
        public RepositoryOrder(ConferenceMercadoTechContext context) : base(context)
        {
            _dataset = context.Set<OrderEntity>();
        }

    }
}
