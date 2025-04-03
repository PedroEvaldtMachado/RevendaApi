using System;
using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Models.Revendas;

public class RevendaContato
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid RevendaId { get; set; }

    [Required]
    public string NomeDeContato { get; set; }

    public bool Principal { get; set; }

    public virtual Revenda Revenda { get; set; }
}