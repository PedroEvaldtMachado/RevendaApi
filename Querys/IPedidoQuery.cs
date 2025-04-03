using RevendaApi.Dtos.Pedidos;
using RevendaApi.Infraestructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevendaApi.Querys;

public interface IPedidoQuery
{
    Task<List<PedidoReadDto>> GetAll();
    Task<List<PedidoReadDto>> GetByClienteId(Guid clienteId);
    Task<PedidoReadDto> GetById(Guid id);
    Task<List<PedidoReadDto>> GetByRevendaId(Guid revendaId);
    Task<List<PedidoReadDto>> GetByRevendaIdAndStatus(Guid revendaId, IEnumerable<StatusPedidoItem> statusPedidoItem);
}