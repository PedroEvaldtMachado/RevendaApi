using RevendaApi.Dtos.Revendas;
using RevendaApi.Profiles;
using System;
using System.Threading.Tasks;

namespace RevendaApi.Services.Implementations;

public class RevendaService : BaseService, IRevendaService
{
    public RevendaService(BaseServiceParams baseParams) : base(baseParams)
    {
    }

    public async Task<RevendaReadDto> Create(RevendaCreateDto dto)
    {
        var ent = dto.ToEntity();

        await DbContext.Value.Revendas.AddAsync(ent);
        await DbContext.Value.SaveChangesAsync();

        return ent.ToDto();
    }

    public async Task<RevendaReadDto> Update(Guid id, RevendaUpdateDto dto)
    {
        var ent = await DbContext.Value.Revendas.FindAsync(id);
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
        var ent = await DbContext.Value.Revendas.FindAsync(id);
        if (ent is null)
        {
            return false;
        }

        DbContext.Value.Revendas.Remove(ent);
        await DbContext.Value.SaveChangesAsync();

        return true;
    }
}
