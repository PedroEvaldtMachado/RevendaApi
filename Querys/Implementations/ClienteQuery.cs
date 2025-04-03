using RevendaApi.Dtos.Clientes;
using RevendaApi.Profiles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RevendaApi.Querys.Implementations;

public class ClienteQuery : BaseQuery, IClienteQuery
{
    public ClienteQuery(BaseQueryParams baseParams) : base(baseParams)
    {
    }

    public async Task<List<ClienteReadDto>> GetAll()
    {
        var query =
            from cliente in DbContext.Value.Clientes
            select cliente.ToDto();

        return await query.ToListAsync();
    }

    public async Task<ClienteReadDto> GetById(Guid id)
    {
        var ent = await DbContext.Value.Clientes
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == id);

        return ent?.ToDto();
    }
}
