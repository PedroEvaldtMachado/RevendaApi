using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Models.Pedidos;

public class Pedido
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid RevendaId { get; set; }

    [Required]
    public Guid ClienteId { get; set; }

    public virtual List<PedidoItem> Itens { get; set; } = [];
}
