using System.Collections.Generic;

namespace RevendaApi.Dtos.Apis
{
    public class FabricaApiPedidoReadDto
    {
        public string NumeroPedido { get; set; }
        public List<FabricaApiPedidoItemCreateDto> Itens { get; set; } = [];
    }
}
