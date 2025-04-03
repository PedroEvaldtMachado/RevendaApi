using System.Collections.Generic;

namespace RevendaApi.Dtos.Apis
{
    public class FabricaApiPedidoCreateDto
    {
        public string Cnpj { get; set; }
        public List<FabricaApiPedidoItemCreateDto> Itens { get; set; } = [];
    }
}
