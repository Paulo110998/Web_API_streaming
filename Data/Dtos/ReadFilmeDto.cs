

namespace _2._web_API.Data.Dtos;

public class ReadFilmeDto
{
    
    public string Titulo { get; set; }
 
    public string Genero { get; set; }
  
    public int Duracao { get; set; }

    // Adicionando DateTime na hora da consulta
    public DateTime HoraDaConsulta { get; set;} = DateTime.Now;
}
