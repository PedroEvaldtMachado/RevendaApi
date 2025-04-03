using RevendaApi.Dtos.Itens;
using System;
using System.Threading.Tasks;

namespace RevendaApi.Services;

public interface IItemService
{
    Task<ItemReadDto> Create(ItemCreateDto dto);
    Task<bool> Delete(Guid id);
}