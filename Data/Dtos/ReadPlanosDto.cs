using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos
{
    public class ReadPlanosDto
    {
        
        public int Id { get; set; }
              
        public string NomePlano { get; set; }

        public int ValorPlano { get; set; }
    }
}
