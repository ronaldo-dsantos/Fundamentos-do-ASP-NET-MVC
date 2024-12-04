using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeiraApp.Models
{
    public class Aluno
    {
        [Key] // [Key] = Para mapear a chave primária, desta forma irá gerar no banco de dados e não no formulário
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")] // parametro {0} referece ao nome do campo
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")] // [StringLength] = Ramanho do campo
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")] // [Required] = Campo obrigatório
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está em formato incorreto")] // [DataType] = Tipo de dado
        [Display(Name = "Data de Nascimento")] // [Display] = Como o nome do campo vai ser exibido na aplicação
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")] 
        [StringLength(60, ErrorMessage = "O campo {0} precisa ter no máximo {1} caracteres")]
        //[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "O campo {0} está em formato inválido")] // [RegularExpression] = Expressão regular para validar e-mail
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")] // [EmailAddress] = Para validação de e-mail
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Confirme o e-mail")]
        [Compare("Email", ErrorMessage = "Os e-mails informados não são identicos")] // [Compare] = Para comparação de valores
        [NotMapped] // [NotMapped] = Para não mapear esse campo no banco de dados, apenas no formulário
        public string? EmailConfirmacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")] 
        [Range(1, 5, ErrorMessage = "O campo {0} deve estar entre {1} e {2}")] // [Range] = Range de valores permitidos
        public int Avaliacao { get; set; }

        public bool Ativo { get; set; }
    }
}
