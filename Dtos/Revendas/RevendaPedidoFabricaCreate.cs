using System;

namespace RevendaApi.Dtos.Revendas
{
    public class RevendaPedidoFabricaCreate
    {
        public Guid ItemId { get; set; }
        public long Quantidade { get; set; }
    }
}
