using RevendaApi.Dtos.Apis;
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
    private readonly Lazy<IRevendaQuery> _revendaQuery;

    public FabricaService(BaseServiceParams baseParams, Lazy<IFabricaApiService> fabricaApiService, Lazy<IRevendaQuery> revendaQuery) : base(baseParams)
    {
        _fabricaApiService = fabricaApiService;
        _revendaQuery = revendaQuery;
    }

    public async Task<FabricaApiPedidoReadDto> CreatePedido(Guid revendaId, List<FabricaApiPedidoItemCreateDto> itens)
    {
        if (itens.Sum(i => i.Quantidade) < 1000)
        {
            return null;
        }

        var revenda = await _revendaQuery.Value.GetById(revendaId);
        if (revenda is null) {
            return null;
        }

        var dto = new FabricaApiPedidoCreateDto
        {
            Cnpj = revenda.Cnpj,
            Itens = itens
        };

        return await _fabricaApiService.Value.CreatePedido(dto);
    }
}
