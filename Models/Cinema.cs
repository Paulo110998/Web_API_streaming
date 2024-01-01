using System.ComponentModel.DataAnnotations;

namespace _2._web_API.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo 'Nome' é obrigatório")]
    public string Nome { get; set; }

    // Relacionando com a entidade "Endereço"
    public int EnderecoId { get; set; }

    public virtual Endereco Endereco { get; set; }

    // Relacionando com a entidade "Sessao"
    public virtual ICollection<Sessao> Sessao { get; set; }
}
