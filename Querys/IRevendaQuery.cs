using RevendaApi.Dtos.Revendas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevendaApi.Querys
{
    public interface IRevendaQuery
    {
        Task<IEnumerable<RevendaReadDto>> GetAll();
        Task<RevendaReadDto> GetById(Guid id);
    }
}
