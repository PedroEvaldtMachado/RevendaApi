using RevendaApi.Dtos.Revendas;
using RevendaApi.Profiles;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RevendaApi.Services.Implementations;

public class RevendaService : BaseService, IRevendaService
{
    public RevendaService(BaseServiceParams baseParams) : base(baseParams)
    {
    }

    public async Task<RevendaReadDto> Create(RevendaCreateDto dto)
    {
        SetContatosPrincipais(dto);

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

        SetContatosPrincipais(dto);

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

    private void SetContatosPrincipais(RevendaCreateDto dto)
    {
        var countContatosPrincipais = dto.Contatos.Count(e => e.Principal);
        if (countContatosPrincipais > 1)
        {
            var contatoPrincipal = dto.Contatos.First(e => e.Principal);
            foreach (var contato in dto.Contatos.Where(c => c.Principal && c != contatoPrincipal))
            {
                contato.Principal = false;
            }
        }
    }

    private void SetContatosPrincipais(RevendaUpdateDto dto)
    {
        var countContatosPrincipais = dto.Contatos.Count(e => e.Principal);
        if (countContatosPrincipais > 1)
        {
            var contatoPrincipal = dto.Contatos.First(e => e.Principal);
            foreach (var contato in dto.Contatos.Where(c => c.Principal && c != contatoPrincipal))
            {
                contato.Principal = false;
            }
        }
    }
}
