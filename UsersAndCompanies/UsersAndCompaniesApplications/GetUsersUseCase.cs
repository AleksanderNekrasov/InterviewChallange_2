using UsersAndCompaniesApplications.Dtos;
using UsersAndCompaniesDataAccess;
using UsersAndCompaniesDataAccess.Entities;

namespace UsersAndCompaniesApplications
{
    public class GetUsersUseCase : IGetUsersUseCase
    {
        public IRepository<UserEntity> _repo;

        public GetUsersUseCase(IRepository<UserEntity> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(x => new UserDto { Id = x.Id, Name = x.Name, Surname = x.Surname });
        }
    }
}