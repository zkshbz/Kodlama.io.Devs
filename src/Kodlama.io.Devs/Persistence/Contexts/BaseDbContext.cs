using Core.Security.Entities;
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
    public DbSet<UserInfo> UserInfos { get; set; }
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

        modelBuilder.Entity<User>(b =>
        {
            b.ToTable("Users").HasKey(pk => pk.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Email).HasColumnName("Email");
            b.Property(p => p.Status).HasColumnName("Status");
            b.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
            b.Property(p => p.FirstName).HasColumnName("FirstName");
            b.Property(p => p.LastName).HasColumnName("LastName");
            b.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
            b.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
            b.HasMany(n => n.RefreshTokens);
            b.HasMany(n => n.UserOperationClaims);
        });
        
        modelBuilder.Entity<OperationClaim>(b =>
        {
            b.ToTable("OperationClaims").HasKey(o => o.Id);
            b.Property(o => o.Id).HasColumnName("Id");
            b.Property(o => o.Name).HasColumnName("Name");
        });
        
        modelBuilder.Entity<UserOperationClaim>(b =>
        {
            b.ToTable("UserOperationClaims").HasKey(pk => pk.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.UserId).HasColumnName("UserId");
            b.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
            b.HasOne(p => p.User);
            b.HasOne(p => p.OperationClaim);
        });

        modelBuilder.Entity<RefreshToken>(b =>
        {
            b.ToTable("RefreshTokens").HasKey(pk => pk.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Created).HasColumnName("Created");
            b.Property(p => p.Expires).HasColumnName("Expires");
            b.Property(p => p.Revoked).HasColumnName("Revoked");
            b.Property(p => p.Token).HasColumnName("Token");
            b.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
            b.Property(p => p.UserId).HasColumnName("UserId");
            b.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
            b.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
            b.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
            b.HasOne(p => p.User);
        });

        modelBuilder.Entity<UserInfo>(b =>
        {
            b.ToTable("UserInfos").HasKey(pk => pk.Id);
            b.Property(p => p.UserId).HasColumnName("UserId");
            b.Property(p => p.GitHubLink).HasColumnName("GitHubLink");
            b.HasOne(p => p.User);
        });
    }
    #endregion
}
