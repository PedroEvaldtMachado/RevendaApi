using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Models.Items;

public class Item
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Nome { get; set; }

    public virtual List<ItemEstoque> Estoques { get; set; } = [];
}
