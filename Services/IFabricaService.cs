using RevendaApi.Dtos.Apis;
using RevendaApi.Dtos.Revendas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevendaApi.Services;

public interface IFabricaService
{
    Task<FabricaApiPedidoReadDto> CreatePedido(Guid revendaId, List<RevendaPedidoFabricaCreate> itens);
}