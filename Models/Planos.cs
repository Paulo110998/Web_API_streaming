using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Models
{
    public class Planos
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Plano' é obrigatório.")]
        public string NomePlano { get; set; }

        [Required]
        public int ValorPlano { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}
