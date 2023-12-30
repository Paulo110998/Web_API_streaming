using _2._web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _2._web_API.Data;

public class GeneroContext : DbContext
{
    public GeneroContext(DbContextOptions<GeneroContext> options)
        : base(options)
    {

    }

    public DbSet<Genero> Generos { get; set; }
}
