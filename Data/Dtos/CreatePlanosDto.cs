using _2._web_API.Models;
using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos
{
    public class CreatePlanosDto
    {


        [Required(ErrorMessage = "O campo 'Plano' é obrigatório.")]
        public string NomePlano { get; set; }

        [Required]
        public int ValorPlano { get; set; }

       
    }
}
