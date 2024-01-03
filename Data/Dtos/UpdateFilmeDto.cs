using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos;

public class UpdateFilmeDto
{
    [Required]
    public byte[] Imagem { get; set; }

    [Required(ErrorMessage = "Campo 'Título' é obrigatório!")]
    [StringLength(50, ErrorMessage = "Total de caracteres: 50")]
    public string Titulo { get; set; }

    [Required]
    public string Genero { get; set; }

    [Required]
    [Range(70, 100, ErrorMessage = "O duração deve ter entre 70 e 100min")]
    public int Duracao { get; set; }
}

