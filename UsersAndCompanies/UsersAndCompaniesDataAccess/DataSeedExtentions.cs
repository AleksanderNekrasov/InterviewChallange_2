using Microsoft.EntityFrameworkCore;
using UsersAndCompaniesDataAccess.Entities;

namespace UsersAndCompaniesDataAccess
{
    internal static class DataSeedExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var companies = GetCompanies();
            modelBuilder.Entity<CompanyEntity>().HasData(companies);
            modelBuilder.Entity<UserEntity>()
                .HasData(GetUsersOfCompany(companies.First().Id));
        }

        private static IEnumerable<CompanyEntity> GetCompanies() 
        {
            return new[]
            {
                new CompanyEntity
                {
                    Id = Guid.NewGuid(),
                    CompanyName = "Default Company",
                    Address = "Default Address"
                }
            };
        }

        private static IEnumerable<UserEntity> GetUsersOfCompany(Guid companyId)
        {
            return new[] 
            { 
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Default User",
                    Surname = "Default User",
                    CompanyId = companyId,
                }
            };
        }
    }
}
