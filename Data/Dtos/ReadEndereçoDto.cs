using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Data.Dtos
{
    public class ReadEndereçoDto
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
