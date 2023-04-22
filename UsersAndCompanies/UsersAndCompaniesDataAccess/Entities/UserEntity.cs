namespace UsersAndCompaniesDataAccess.Entities
{
    public class UserEntity : EntityBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Guid CompanyId { get; set; }

        public CompanyEntity Company { get; set; }
    }
}
