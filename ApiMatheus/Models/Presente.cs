using System.ComponentModel.DataAnnotations;

namespace ApiMatheus.Models
{
    public class Presente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public bool Confirmado { get; set; } = false;

        public string PessoaConfirmada { get; set; }
    }
}