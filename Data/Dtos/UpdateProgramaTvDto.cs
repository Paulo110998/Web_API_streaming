using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos
{
    public class UpdateProgramaTvDto
    {

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(50, ErrorMessage = "Total de caracteres: 50.")]
        public string TituloPrograma { get; set; }
    }
}
