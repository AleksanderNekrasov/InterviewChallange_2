using Microsoft.EntityFrameworkCore;
using UsersAndCompaniesDataAccess.Entities;

namespace UsersAndCompaniesDataAccess
{
    public class UsersAndCompaniesContext : DbContext
    {
        public UsersAndCompaniesContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<UserEntity> UserSet { get; set; }

        public DbSet<CompanyEntity> CompanySet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<UserEntity>().HasKey(x => x.Id)
                .HasName("PrimaryKey_Users");
            modelBuilder.Entity<UserEntity>().HasIndex(i => i.Name).IsUnique();
            modelBuilder.Entity<UserEntity>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<UserEntity>().HasIndex(i => i.Surname).IsUnique();
            modelBuilder.Entity<UserEntity>().Property(x => x.Surname).IsRequired();
            modelBuilder.Entity<UserEntity>().HasOne(x => x.Company);

            modelBuilder.Entity<CompanyEntity>().HasKey(x => x.Id)
                .HasName("PrimaryKey_Companies");
            modelBuilder.Entity<CompanyEntity>().ToTable("Companies");
            modelBuilder.Entity<CompanyEntity>().HasMany(x => x.Users);
            modelBuilder.Entity<CompanyEntity>().Property(x => x.Address).IsRequired();
            modelBuilder.Entity<CompanyEntity>().Property(x => x.CompanyName).IsRequired();

            modelBuilder.Seed();
        }
    }
}