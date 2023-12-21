using _2._web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _2._web_API.Data;

public class SeriesContext : DbContext
{
    public SeriesContext(DbContextOptions<SeriesContext> opts)
        : base(opts)
    {

    }

    public DbSet<Series> Seriess { get; set; }
}
