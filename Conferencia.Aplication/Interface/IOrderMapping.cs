
using Conferencia.Aplication.DTO;
using System.Collections.Generic;

namespace Conferencia.Aplication.Interface
{
    public interface IOrderMapping
    {
        void SaveToOrder(List<OrderDto> listaDePedidosDto);
    }
}
