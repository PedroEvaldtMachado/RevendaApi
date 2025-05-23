﻿namespace RevendaApi.Dtos.Enderecos;

public class EnderecoCreateDto
{
    public string Logradouro { get; set; }

    public string Numero { get; set; }

    public string Complemento { get; set; }

    public string Bairro { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string Cep { get; set; }
}
