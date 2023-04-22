using UsersAndCompaniesApplications.Dtos;

namespace UsersAndCompaniesApplications
{
    public interface IGetUsersUseCase
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
    }
}