using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }

    // Criando uma relação de uma sessão com um filme
    [Required]
    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }


}
 