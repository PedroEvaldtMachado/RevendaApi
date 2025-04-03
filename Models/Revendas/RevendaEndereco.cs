using System;
using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Models.Revendas;

public class RevendaEndereco
{
    [Required]
    public Guid RevendaId { get; set; }

    [Required]
    public Guid EnderecoId { get; set; }

    public virtual Revenda Revenda { get; set; }
    public virtual Endereco Endereco { get; set; }
}