using RevendaApi.Dtos.Enderecos;
using RevendaApi.Infraestructure;

namespace RevendaApi.Dtos.Clientes
{
    public class ClienteCreateDto
    {
        public string Nome { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EnderecoCreateDto Endereco { get; set; }
    }
}