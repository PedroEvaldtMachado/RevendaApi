using RevendaApi.Dtos.Pedidos;
using System;
using System.Threading.Tasks;

namespace RevendaApi.Services;

public interface IPedidoService
{
    Task<PedidoReadDto> Create(PedidoCreateDto dto);
    Task<PedidoReadDto> CreateForCliente(Guid clienteId, PedidoCreateDto dto);
    Task<bool> Delete(Guid id);
    Task<PedidoReadDto> Update(Guid id, PedidoUpdateDto dto);
}
