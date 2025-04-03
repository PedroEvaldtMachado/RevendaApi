using Microsoft.EntityFrameworkCore;
using RevendaApi.Dtos.Revendas;
using RevendaApi.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevendaApi.Querys.Implementations;

public class RevendaQuery : BaseQuery, IRevendaQuery
{
    public RevendaQuery(BaseQueryParams baseParams) : base(baseParams)
    {
    }

    public async Task<IEnumerable<RevendaReadDto>> GetAll()
    {
        var revendas = 
            from rev in DbContext.Value.Revendas
            select rev.ToDto();

        return await revendas.ToListAsync();
    }

    public async Task<RevendaReadDto> GetById(Guid id)
    {
        var revenda =
            from rev in DbContext.Value.Revendas
            where rev.Id == id
            select rev.ToDto();

        return await revenda.FirstOrDefaultAsync();
    }
}
