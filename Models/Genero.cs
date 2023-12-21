using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Models;

public class Genero
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Total de caracteres: 100")]
    public string GeneroNome { get; set; }
}
