using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos;

public class ReadGeneroDto
{
    public string GeneroNome { get; set; }

    public DateTime HoraConsultaGenero { get; set; }
}
