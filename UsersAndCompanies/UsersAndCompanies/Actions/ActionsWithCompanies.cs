using UsersAndCompaniesApplications.Dtos;

namespace UsersAndCompanies.Actions
{
    public class ActionsWithCompanies
    {
        private readonly ILogger<ActionsWithCompanies> _logger;

        public ActionsWithCompanies(ILogger<ActionsWithCompanies> logger)
        {
            _logger = logger;
        }
        public Task<IEnumerable<CompanyDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Post(CompanyDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(CompanyDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
