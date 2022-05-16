using Microsoft.EntityFrameworkCore;

namespace PptNemocnice.Api.Data;

public class NemocniceDbContext : DbContext
{
    public NemocniceDbContext
        (DbContextOptions<NemocniceDbContext> options)
        : base(options)
    {

    }

protected override void OnModelCreating(ModelBuilder builder)
{

    Guid idVybaveniSRevizi = new Guid("aaaca371-e28b-4107-845c-ac9823893da4");
    builder.Entity<Vybaveni>().HasData(
        new Vybaveni() {Id = idVybaveniSRevizi, Name = "CT", BoughtDateTime = new DateTime(2017,6,6), PriceCzk = 100_000 },
        new Vybaveni() {Id = new Guid("111ca371-e28b-4107-845c-ac9823893da4"), Name = "MRI", BoughtDateTime = new DateTime(2015,6,6), PriceCzk = 10_000 }
        );

    builder.Entity<Revize>().HasData(
        new Revize() {Id = new Guid("bbbca371-e28b-4107-845c-ac9823893da4"), VybaveniId = idVybaveniSRevizi, Name = "Přísná revize", DateTime = new DateTime(2020,2,2) },
        new Revize() {Id = new Guid("dddca371-e28b-4107-845c-ac9823893da4"), VybaveniId = idVybaveniSRevizi, Name = "Nicmoc revize", DateTime = new DateTime(2022, 6, 22) }
        );
}

    public DbSet<Vybaveni> Vybavenis  => Set<Vybaveni>();
    public DbSet<Revize> Revizes  => Set<Revize>();
    public DbSet<Ukon> Ukons  => Set<Ukon>();
}
