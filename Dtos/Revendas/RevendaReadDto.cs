using System.Collections.Generic;
using System;

namespace RevendaApi.Dtos.Revendas;

public class RevendaReadDto
{
    public Guid Id { get; set; }

    public string Cnpj { get; set; }

    public string RazaoSocial { get; set; }

    public string NomeFantasia { get; set; }

    public string Email { get; set; }

    public string Telefone { get; set; }

    public List<RevendaContatoReadDto> Contatos { get; set; } = [];

    public List<RevendaEnderecoReadDto> Enderecos { get; set; } = [];
}
