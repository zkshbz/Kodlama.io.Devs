using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    #region injections
    protected IConfiguration Configuration { get; set; }
    
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }
    #endregion
    
    #region ctor
    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }
    #endregion
    
    #region methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProgrammingLanguage>(b =>
        {
            b.ToTable("ProgrammingLanguages").HasKey(pk => pk.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");
        });

        modelBuilder.Entity<ProgrammingLanguageTechnology>(b =>
        {
            b.ToTable("ProgrammingLanguageTechnology").HasKey(pk => pk.Id);
            b.Property(p => p.Name).HasColumnName("Name");
        });
    }
    #endregion
}
