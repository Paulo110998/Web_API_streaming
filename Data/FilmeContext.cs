using _2._web_API.Models;
using Microsoft.EntityFrameworkCore;
namespace _2._web_API.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options)
        : base(options) 
    {
        
    }

    // Propriedade de acesso aos filmes
    public DbSet<Filme> Filmes { get; set; }
}   
