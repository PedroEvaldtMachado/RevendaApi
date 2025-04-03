using RevendaApi.Dtos.Clientes;
using RevendaApi.Profiles;
using System;
using System.Threading.Tasks;

namespace RevendaApi.Services.Implementations;

public class ClienteService : BaseService, IClienteService
{
    public ClienteService(BaseServiceParams baseParams) : base(baseParams)
    {
    }

    public async Task<ClienteReadDto> Create(ClienteCreateDto dto)
    {
        var ent = dto.ToEntity();

        await DbContext.Value.Clientes.AddAsync(ent);
        await DbContext.Value.SaveChangesAsync();

        return ent.ToDto();
    }

    public async Task<ClienteReadDto> Update(Guid id, ClienteUpdateDto dto)
    {
        var ent = await DbContext.Value.Clientes.FindAsync(id);
        if (ent is null)
        {
            return null;
        }

        dto.CopyTo(ent);
        await DbContext.Value.SaveChangesAsync();
        return ent.ToDto();
    }

    public async Task<bool> Delete(Guid id)
    {
        var ent = await DbContext.Value.Clientes.FindAsync(id);
        if (ent is null)
        {
            return false;
        }

        DbContext.Value.Clientes.Remove(ent);
        await DbContext.Value.SaveChangesAsync();
        return true;
    }
}
