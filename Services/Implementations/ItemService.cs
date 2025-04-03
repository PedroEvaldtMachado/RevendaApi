using RevendaApi.Dtos.Itens;
using System.Threading.Tasks;
using RevendaApi.Profiles;
using System;

namespace RevendaApi.Services.Implementations;

public class ItemService : BaseService, IItemService
{
    public ItemService(BaseServiceParams baseParams) : base(baseParams)
    {
    }

    public async Task<ItemReadDto> Create(ItemCreateDto dto)
    {
        var ent = dto.ToEntity();

        await DbContext.Value.Itens.AddAsync(ent);
        await DbContext.Value.SaveChangesAsync();

        return ent.ToDto();
    }

    public async Task<bool> Delete(Guid id)
    {
        var ent = await DbContext.Value.Itens.FindAsync(id);
        if (ent is null)
        {
            return false;
        }

        DbContext.Value.Itens.Remove(ent);
        await DbContext.Value.SaveChangesAsync();
        return true;
    }
}
