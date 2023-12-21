using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos
{
    public class CreateUsuariosDto
    {

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(70, ErrorMessage = "Total de caracteres: 70")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Total de caracteres: 50")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(10, ErrorMessage = "total de caracteres: 10")]
        public string Senha { get; set; }
    }
}
