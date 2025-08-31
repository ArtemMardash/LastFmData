using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MusicFM.API.Infrastructure.Persistence.DbEntities;

namespace MusicFM.API.Infrastructure;

public class MusicFmDbContext: DbContext
{
    public DbSet<AlbumDb> Albums { get; set; }
    
    public DbSet<ArtistDb> Artists { get; set; }
    
    public DbSet<TagDb> Tags { get; set; }

    public MusicFmDbContext(DbContextOptions options): base(options)
    {
    }
    
    
    /// <summary>
    /// Data to db
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArtistDb>().HasKey(a => a.Mbid);
        modelBuilder.Entity<AlbumDb>().HasKey(a => a.Mbid);
        modelBuilder.Entity<TagDb>().HasKey(t => t.Id);
        modelBuilder.Entity<TagDb>().HasIndex(t => t.Name);

        modelBuilder.Entity<ArtistDb>().HasMany<AlbumDb>(ar => ar.Albums)
            .WithOne(a => a.Artist).HasForeignKey(a => a.ArtistsMbid);
        modelBuilder.Entity<ArtistDb>().HasMany<TagDb>(ar => ar.Tags).WithMany();
    }
}

public class UserContextFactory : IDesignTimeDbContextFactory<MusicFmDbContext>
{
    public MusicFmDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MusicFmDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=LastFm;Username=postgres;Password=postgres",
            builder => builder.MigrationsAssembly(typeof(MusicFmDbContext).Assembly.GetName().Name));

        return new MusicFmDbContext(optionsBuilder.Options);
    }
}