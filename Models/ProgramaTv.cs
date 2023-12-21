using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Models;

public class ProgramaTv
{
    [Key]
    [Required]
    public int Id  { get; set; }

    [Required(ErrorMessage = "Campo obrigatório.")]
    [StringLength(50, ErrorMessage = "Total de caracteres: 50.")]
    public string TituloPrograma { get; set; }

}
