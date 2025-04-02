﻿using System;

namespace RevendaApi.Dtos.Revendas;

public class RevendaEnderecoCreateDto
{
    public Guid Id { get; set; }

    public string Logradouro { get; set; }

    public string Numero { get; set; }

    public string Complemento { get; set; }

    public string Bairro { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string Cep { get; set; }
}
