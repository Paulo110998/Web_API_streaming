using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Models;

public class Perfil
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(30)]
    public string NomeDoPerfil { get; set; }

    public int PlanosId { get; set; }

    public virtual Planos Planos { get; set; }
}
