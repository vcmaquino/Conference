using Conferencia.domain.Entity;

namespace Conferencia.Domain.Entity
{
    public class OrderEntity : EntityBase
    {
        public string Codigo { get; set; }
        public string NomeDoConsumidor { get; set; }
        public int Quantidade { get; set; }
        public string Bebida { get; set; }
        public string Embalagem { get; set; }
    }
}
