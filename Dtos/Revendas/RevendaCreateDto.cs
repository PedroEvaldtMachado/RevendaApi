using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Dtos.Revendas;

public class RevendaCreateDto
{
    [Required]
    public string Cnpj { get; set; }

    [Required]
    public string RazaoSocial { get; set; }

    [Required]
    public string NomeFantasia { get; set; }

    [Required]
    public string Email { get; set; }

    public string Telefone { get; set; }

    public List<RevendaContatoCreateDto> Contatos { get; set; } = [];

    public List<RevendaEnderecoCreateDto> Enderecos { get; set; } = [];
}
