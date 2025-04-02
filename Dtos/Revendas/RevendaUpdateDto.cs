using System.Collections.Generic;
using System;

namespace RevendaApi.Dtos.Revendas;

public class RevendaUpdateDto
{
    public string Cnpj { get; set; }

    public string RazaoSocial { get; set; }

    public string NomeFantasia { get; set; }

    public string Email { get; set; }

    public string Telefone { get; set; }

    public List<RevendaContatoUpdateDto> Contatos { get; set; } = [];

    public List<RevendaEnderecoUpdateDto> Enderecos { get; set; } = [];
}
