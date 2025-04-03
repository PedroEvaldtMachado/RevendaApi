using System.Collections.Generic;
using System;

namespace RevendaApi.Dtos.Pedidos
{
    public class PedidoCreateDto
    {
        public Guid Id { get; set; }

        public Guid RevendaId { get; set; }

        public Guid? ClienteId { get; set; }

        public virtual List<PedidoItemCreateDto> Itens { get; set; } = [];
    }
}
