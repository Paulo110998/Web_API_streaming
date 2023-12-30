using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo 'Título' é obrigatório!")]
    [MaxLength(50, ErrorMessage ="Total de caracteres: 50")]
    public string Titulo { get; set; }

    [Required]
    public string Genero { get; set;}

    [Required]
    [Range(70, 100, ErrorMessage ="O duração deve ter entre 70 e 100min")]
    public int Duracao { get; set; }

    // Criando a relação do filme com uma sessão, através de uma coleção (lista) de sessões
    public virtual ICollection<Sessao> Sessoes { get; set; }
}
