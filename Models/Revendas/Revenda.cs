using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Models.Revendas;

public class Revenda
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Cnpj { get; set; }

    [Required]
    public string RazaoSocial { get; set; }

    [Required]
    public string NomeFantasia { get; set; }

    [Required]
    public string Email { get; set; }

    public string Telefone { get; set; }

    public virtual List<RevendaContato> Contatos { get; set; } = [];

    public virtual List<Endereco> Enderecos { get; set; } = [];
}