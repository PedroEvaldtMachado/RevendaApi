using RevendaApi.Dtos.Clientes;
using System;
using System.Threading.Tasks;

namespace RevendaApi.Services;

public interface IClienteService
{
    Task<ClienteReadDto> Create(ClienteCreateDto dto);
    Task<bool> Delete(Guid id);
    Task<ClienteReadDto> Update(Guid id, ClienteUpdateDto dto);
}
