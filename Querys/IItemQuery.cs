using RevendaApi.Dtos.Itens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevendaApi.Querys;

public interface IItemQuery
{
    Task<List<ItemReadDto>> GetAll();
    Task<ItemReadDto> GetById(Guid id);
}