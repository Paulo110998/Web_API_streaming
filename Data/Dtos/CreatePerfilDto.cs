using _2._web_API.Models;
using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos
{
    public class CreatePerfilDto
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(30)]
        public string NomeDoPerfil { get; set; }

        public int PlanosId { get; set; }

    }
}
