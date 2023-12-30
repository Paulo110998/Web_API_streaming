using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Logradouro { get; set; }

    [Required]
    public int Numero { get; set; }

    // Relacionando com a entidade "Cinema"
    public virtual Cinema Cinema { get; set; }
}
