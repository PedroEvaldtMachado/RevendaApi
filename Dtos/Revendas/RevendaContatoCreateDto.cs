using System;

namespace RevendaApi.Dtos.Revendas;

public class RevendaContatoCreateDto
{
    public Guid Id { get; set; }

    public string NomeDeContato { get; set; }

    public bool Principal { get; set; }
}
