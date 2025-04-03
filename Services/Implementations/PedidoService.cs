using RevendaApi.Dtos.Pedidos;
using RevendaApi.Profiles;
using System;
using System.Threading.Tasks;

namespace RevendaApi.Services.Implementations;

public class PedidoService : BaseService, IPedidoService
{
    public PedidoService(BaseServiceParams baseParams) : base(baseParams)
    {
    }

    public async Task<PedidoReadDto> CreateForCliente(Guid clienteId, PedidoCreateDto dto)
    {
        dto.ClienteId = clienteId;
        return await Create(dto);
    }

    public async Task<PedidoReadDto> Create(PedidoCreateDto dto)
    {
        var ent = dto.ToEntity();

        await DbContext.Value.Pedidos.AddAsync(ent);
        await DbContext.Value.SaveChangesAsync();

        return ent.ToDto();
    }

    public async Task<PedidoReadDto> Update(Guid id, PedidoUpdateDto dto)
    {
        var ent = await DbContext.Value.Pedidos.FindAsync(id);
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
        var ent = await DbContext.Value.Pedidos.FindAsync(id);
        if (ent is null)
        {
            return false;
        }

        DbContext.Value.Pedidos.Remove(ent);
        await DbContext.Value.SaveChangesAsync();

        return true;
    }
}
