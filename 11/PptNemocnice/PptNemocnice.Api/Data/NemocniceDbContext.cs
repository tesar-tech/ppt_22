using Microsoft.EntityFrameworkCore;

namespace PptNemocnice.Api.Data;

public class NemocniceDbContext : DbContext
{
    public NemocniceDbContext
        (DbContextOptions<NemocniceDbContext> options)
        : base(options)
    {

    }

    public DbSet<Vybaveni> Vybavenis  => Set<Vybaveni>();
    public DbSet<Revize> Revizes  => Set<Revize>();
}
