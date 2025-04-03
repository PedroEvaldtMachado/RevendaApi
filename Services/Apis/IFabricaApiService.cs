using RevendaApi.Dtos.Apis;
using System.Threading.Tasks;

namespace RevendaApi.Services.Apis;

public interface IFabricaApiService
{
    Task<FabricaApiPedidoReadDto> CreatePedido(FabricaApiPedidoCreateDto dto);
}