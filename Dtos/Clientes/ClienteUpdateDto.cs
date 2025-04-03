using RevendaApi.Dtos.Enderecos;
using RevendaApi.Infraestructure;
using System;

namespace RevendaApi.Dtos.Clientes
{
    public class ClienteUpdateDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EnderecoUpdateDto Endereco { get; set; }
    }
}
