using RevendaApi.Dtos.Revendas;
using System;
using System.Threading.Tasks;

namespace RevendaApi.Services;

public interface IRevendaService
{
    Task<RevendaReadDto> Create(RevendaCreateDto dto);
    Task<RevendaReadDto> Update(Guid id, RevendaUpdateDto dto);
    Task<bool> Delete(Guid id);
}
