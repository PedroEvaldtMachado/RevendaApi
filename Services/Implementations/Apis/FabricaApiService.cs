using Microsoft.Extensions.Logging;
using RevendaApi.Dtos.Apis;
using RevendaApi.Services.Apis;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace RevendaApi.Services.Implementations.Apis;

public class FabricaApiService : IFabricaApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<FabricaApiService> _logger;
    private readonly string _endPoint = "https://fabricaapi/pedido";

    public FabricaApiService(IHttpClientFactory httpClientFactory, ILogger<FabricaApiService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public virtual async Task<FabricaApiPedidoReadDto> CreatePedido(FabricaApiPedidoCreateDto dto)
    {
        var client = _httpClientFactory.CreateClient("FabricaApi");
        var response = await client.PostAsync(_endPoint, JsonContent.Create(dto));

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<FabricaApiPedidoReadDto>();
        }
        else
        {
            var errorResponse = await response.Content?.ReadAsStringAsync();

            _logger.LogError($"Api: {_endPoint}"
                + $" | Erro código: {response.StatusCode}"
                + $" | Dados envio: {JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = false })}"
                + $" | Resposta: {errorResponse}");

            return null;
        }
    }
}

public class FabricaApiServiceMock : FabricaApiService
{
    public FabricaApiServiceMock(IHttpClientFactory httpClientFactory, ILogger<FabricaApiService> logger) : base(httpClientFactory, logger)
    {
    }

    public override async Task<FabricaApiPedidoReadDto> CreatePedido(FabricaApiPedidoCreateDto dto)
    {
        await Task.Delay(250);

        return new FabricaApiPedidoReadDto
        {
            NumeroPedido = "123456",
            Itens = dto.Itens
        };
    }
}
