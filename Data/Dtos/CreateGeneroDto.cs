using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos;

public class CreateGeneroDto
{
    [Required]
    [StringLength(100, ErrorMessage = "Total de caracteres: 100")]
    public string GeneroNome { get; set; }
}
