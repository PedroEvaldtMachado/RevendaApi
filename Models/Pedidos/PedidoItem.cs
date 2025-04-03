using RevendaApi.Infraestructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Models.Pedidos;

public class PedidoItem
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid PedidoId { get; set; }

    [Required]
    public Guid ItemEstoqueId { get; set; }

    [Required]
    public long Quantidade { get; set; }

    [Required]
    public decimal ValorUnitario { get; set; }

    public decimal ValorDesconto { get; set; } = 0;

    public StatusPedidoItem StatusPedidoItem { get; set; } = StatusPedidoItem.Criado;

    public decimal ValorTotal => (ValorUnitario * Quantidade) - ValorDesconto;

    public virtual Pedido Pedido { get; set; }
}
