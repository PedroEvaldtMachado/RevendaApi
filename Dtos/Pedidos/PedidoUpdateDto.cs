using System.Collections.Generic;
using System;

namespace RevendaApi.Dtos.Pedidos
{
    public class PedidoUpdateDto
    {
        public Guid Id { get; set; }

        public Guid RevendaId { get; set; }

        public Guid ClienteId { get; set; }

        public virtual List<PedidoItemReadDto> Itens { get; set; } = [];
    }
}
