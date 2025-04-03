using System;
using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Models.Items;

public class ItemEstoque
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid ItemId { get; set; }

    [Required]
    public Guid RevendaId { get; set; }

    [Required]
    public decimal ValorUnitario { get; set; }

    [Required]
    public long Quantidade { get; set; }

    public virtual Item Item { get; set; }
}
