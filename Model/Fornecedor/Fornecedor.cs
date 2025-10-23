using CadastroCliente.Model.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CadastroCliente.Model.Fornecedor
{
    [PrimaryKey("Id")]
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; }

        [Length(2, 100, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        [ShouldHaveLastName(ErrorMessage = "Precisa conter sobrenome")]
        public string Nome { get; set; } = string.Empty;

        [Length(14, 14, ErrorMessage = "O CNPJ deve ter exatamente 14 caracteres")]
        [DisplayName("CNPJ")]
        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        public string Cnpj { get; set; } = string.Empty;

        [AllowedValues(Segmento.Comércio, Segmento.Indústria, Segmento.Serviço)]
        [Required(ErrorMessage = "O segmento é obrigatório")]
        public Segmento Segmento { get; set; }

        [Length(8, 8, ErrorMessage = "O CEP deve ter exatamente 8 caracteres")]
        [DisplayName("CEP")]
        [Required(ErrorMessage = "O CEP é obrigatório")]
        public string Cep { get; set; } = string.Empty;

        [Length(10, 255, ErrorMessage = "O endereço deve ter entre 10 e 255 caracteres")]
        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string Endereco { get; set; } = string.Empty;

        [RegularExpression(".+\\..+")]     
        public string? FotoUrl { get; set; }

    }
}
