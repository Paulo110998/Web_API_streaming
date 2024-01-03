using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Models;

public class Series
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public byte[] ImagemSerie { get; set; }


    [Required(ErrorMessage = "Título da série é obrigatório!")]
    [StringLength(50, ErrorMessage = "Total de caracteres: 50")]
    public string TituloSerie { get; set; }

    [Required(ErrorMessage = "Campo 'Temporadas' é obrigatório!")]
    [Range(1, 10, ErrorMessage = "Erro! Número total de temporadas: 10 Temporadas")]
    public int Temporadas { get; set; }

    [Required(ErrorMessage = "Campo 'Episódios' é obrigatório!'")]
    [Range(1, 12, ErrorMessage = "Número total de episódios por temporadas: 1 à 12")]
    public int Episodios { get; set; }

    [Required(ErrorMessage = "Campo 'Sinopse' é obrigatório!")]
    [StringLength(200, ErrorMessage = "Total de caracteres: 200")]
    public string Sinopse { get; set; }
}