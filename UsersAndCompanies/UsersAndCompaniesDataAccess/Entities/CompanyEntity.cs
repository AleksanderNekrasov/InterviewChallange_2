namespace UsersAndCompaniesDataAccess.Entities
{
    public class CompanyEntity : EntityBase
    {
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public IEnumerable<UserEntity> Users { get; set; }
    }
}
