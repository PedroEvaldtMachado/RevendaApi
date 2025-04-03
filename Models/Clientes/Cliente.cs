using RevendaApi.Infraestructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Models.Clientes;

public class Cliente
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public TipoPessoa TipoPessoa { get; set; }

    [Required]
    public string CpfCnpj { get; set; }

    [Required]
    public string Email { get; set; }

    public string Telefone { get; set; }

    [Required]
    public Guid EnderecoId { get; set; }

    public virtual Endereco Endereco { get; set; }
}
