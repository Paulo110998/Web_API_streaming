using _2._web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _2._web_API.Data;

public class ProgramaTvContext : DbContext
{
    public ProgramaTvContext(DbContextOptions<ProgramaTvContext> options) 
        : base(options)
    {

    }

    public DbSet<ProgramaTv> ProgramaTv { get; set;}
}
