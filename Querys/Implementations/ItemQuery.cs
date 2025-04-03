using Microsoft.EntityFrameworkCore;
using RevendaApi.Dtos.Itens;
using RevendaApi.Profiles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RevendaApi.Querys.Implementations;

public class ItemQuery : BaseQuery, IItemQuery
{
    public ItemQuery(BaseQueryParams baseParams) : base(baseParams)
    {
    }

    public async Task<List<ItemReadDto>> GetAll()
    {
        var query = 
            from item in DbContext.Value.Itens
            select item.ToDto();

        return await query.ToListAsync();
    }   

    public async Task<ItemReadDto> GetById(Guid id)
    {
        var ent = await DbContext.Value.Itens.FindAsync(id);
        if (ent is null)
        {
            return null;
        }

        return ent.ToDto();
    }
}
