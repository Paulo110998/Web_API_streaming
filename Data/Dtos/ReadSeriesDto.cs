
using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos;

public class ReadSeriesDto
{
    public int Id { get; set; }

    public byte[] ImagemSerie { get; set; }

    public string TituloSerie { get; set; }

    public int Temporadas { get; set; }

    public int Episodios { get; set; }

    public string Sinopse { get; set; }
}
