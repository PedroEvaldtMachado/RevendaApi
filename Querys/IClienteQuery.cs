using RevendaApi.Dtos.Clientes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevendaApi.Querys;

public interface IClienteQuery
{
    Task<List<ClienteReadDto>> GetAll();
    Task<ClienteReadDto> GetById(Guid id);
}
