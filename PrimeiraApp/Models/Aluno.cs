using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeiraApp.Models
{
    public class Aluno
    {
        [Key] // mapeando a chave primária, desta forma irá gerar no banco de dados e não no formulário
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")] // parametro {0} referece ao nome do campo
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está em formato incorreto")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")] 
        [StringLength(60, ErrorMessage = "O campo {0} precisa ter no máximo {1} caracteres")]
        //[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "O campo {0} está em formato inválido")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Confirme o e-mail")]
        [Compare("Email", ErrorMessage = "Os e-mails informados não são identicos")]
        [NotMapped] // não mapear esse campo no banco de dados, apenas no formulário
        public string? EmailConfirmacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")] 
        [Range(1, 5, ErrorMessage = "O campo {0} deve estar entre {1} e {2}")]
        public int Avaliacao { get; set; }

        public bool Ativo { get; set; }
    }
}
