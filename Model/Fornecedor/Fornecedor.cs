using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Model.Fornecedor
{
    [PrimaryKey("Id")]
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; }

        [Length(2, 100)]
        public string Nome { get; set; } = string.Empty;

        [Length(14,14)]
        public string Cnpj { get; set; } = string.Empty;

        [AllowedValues("Comércio", "Serviço", "Indústria")]
        public string Segmento { get; set; }

        public string Cep { get; set; } = string.Empty;

        public string Endereco { get; set; } = string.Empty;

        public Byte[]? Foto { get; set; }

    }
}
