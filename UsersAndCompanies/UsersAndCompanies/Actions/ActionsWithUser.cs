using UsersAndCompaniesApplications;
using UsersAndCompaniesApplications.Dtos;

namespace UsersAndCompanies.Actions
{
    public class ActionsWithUser
    {
        private readonly ILogger<ActionsWithUser> _logger;
        private readonly IGetUsersUseCase _getAllUsersCase;

        public ActionsWithUser(ILogger<ActionsWithUser> logger, IGetUsersUseCase getAllUsersCase)
        {
            _logger = logger;
            _getAllUsersCase = getAllUsersCase;
        }

        public async Task<IEnumerable<UserDto>> GetAll() =>
            await _getAllUsersCase.GetAllUsers();

        public Task<UserDto> Get(Guid id) 
        {
            throw new NotImplementedException();
        }

        public Task<bool> Post(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id) 
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(UserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
