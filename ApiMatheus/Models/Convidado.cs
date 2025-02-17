using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMatheus.Models
{
    public class Convidado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [ForeignKey("Presente")]
        public int? PresenteId { get; set; }
        
        public Presente Presente { get; set; }
    }
}