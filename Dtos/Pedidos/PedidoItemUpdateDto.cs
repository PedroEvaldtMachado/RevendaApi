using System;

namespace RevendaApi.Dtos.Pedidos
{
    public class PedidoItemUpdateDto
    {
        public Guid Id { get; set; }

        public Guid PedidoId { get; set; }

        public Guid ItemEstoqueId { get; set; }

        public long Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorDesconto { get; set; } = 0;
    }
}
