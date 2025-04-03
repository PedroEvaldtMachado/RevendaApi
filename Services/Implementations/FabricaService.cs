using RevendaApi.Dtos.Apis;
using RevendaApi.Dtos.Revendas;
using RevendaApi.Querys;
using RevendaApi.Services.Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevendaApi.Services.Implementations;

public class FabricaService : BaseService, IFabricaService
{
    private readonly Lazy<IFabricaApiService> _fabricaApiService;
    private readonly Lazy<IItemQuery> _itemQuery;
    private readonly Lazy<IRevendaQuery> _revendaQuery;

    public FabricaService(BaseServiceParams baseParams, Lazy<IFabricaApiService> fabricaApiService, Lazy<IRevendaQuery> revendaQuery, Lazy<IItemQuery> itemQuery) : base(baseParams)
    {
        _fabricaApiService = fabricaApiService;
        _revendaQuery = revendaQuery;
        _itemQuery = itemQuery;
    }

    public async Task<FabricaApiPedidoReadDto> CreatePedido(Guid revendaId, List<RevendaPedidoFabricaCreate> itens)
    {
        if (itens.Sum(i => i.Quantidade) < 1000)
        {
            return null;
        }

        var revenda = await _revendaQuery.Value.GetById(revendaId);
        if (revenda is null) {
            return null;
        }

        var itensNames = await _itemQuery.Value.GetByIds(itens.Select(i => i.ItemId));
        if (itens.Any(n => !itensNames.Any(i => n.ItemId == i.Id)))
        {
            return null;
        }

        var dto = new FabricaApiPedidoCreateDto
        {
            Cnpj = revenda.Cnpj,
            Itens = itens.Select(i => new FabricaApiPedidoItemCreateDto 
            { 
                Nome = itensNames.FirstOrDefault(n => n.Id == i.ItemId)?.Nome,
                Quantidade = i.Quantidade
            }).ToList(),
        };

        return await _fabricaApiService.Value.CreatePedido(dto);
    }
}
