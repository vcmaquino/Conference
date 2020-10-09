using AutoMapper;
using Conferencia.Aplication.DTO;
using Conferencia.Aplication.Interface;
using Conferencia.Domain.Entity;
using Conferencia.Domain.IRepository;
using System.Collections.Generic;

namespace Conferencia.Aplication.mapping
{
    public class OrderMapping : IOrderMapping
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryOrder _repositoryOrder;
        public OrderMapping(IMapper mapper, IRepositoryOrder repositoryOrder)
        {
            _mapper = mapper;
            _repositoryOrder = repositoryOrder;
        }

        public void SaveToOrder(List<OrderDto> OrderListDto)
        {
            foreach (var orderDto in OrderListDto)
            {
                var order = _mapper.Map<OrderEntity>(orderDto);
                _repositoryOrder.Add(order);
            }
        }
    }
}
