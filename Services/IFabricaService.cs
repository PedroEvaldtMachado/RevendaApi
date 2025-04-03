using RevendaApi.Dtos.Apis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevendaApi.Services;

public interface IFabricaService
{
    Task<FabricaApiPedidoReadDto> CreatePedido(Guid revendaId, List<FabricaApiPedidoItemCreateDto> itens);
}