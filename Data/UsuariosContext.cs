using _2._web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _2._web_API.Data;

public class UsuariosContext : DbContext
{
    public UsuariosContext(DbContextOptions<UsuariosContext> options)
    : base(options)
    {

    }

    public DbSet<Usuario> Usuarios { get; set; }
}
