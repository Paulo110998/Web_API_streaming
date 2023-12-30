using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "Campo 'Nome' é obrigatório")]
        public string Nome { get; set; }
    }
}
