namespace _2._web_API.Data.Dtos
{
    public class ReadPerfilDto
    {
        public int Id { get; set; }
        public string NomeDoPerfil { get; set; }

        public ReadPlanosDto ReadPlanosDto { get; set; }
    }
}
