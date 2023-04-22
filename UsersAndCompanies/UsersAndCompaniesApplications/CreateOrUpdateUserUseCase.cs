using UsersAndCompaniesDataAccess.Entities;
using UsersAndCompaniesDataAccess;
using UsersAndCompaniesApplications.Dtos;
using UsersAndCompaniesApplications.Validations;

namespace UsersAndCompaniesApplications
{
    public class CreateOrUpdateUserUseCase : UseCaseBase
    {
        private readonly IRepository<UserEntity> _repo;

        private readonly UserDtoValidator _validator;

        public CreateOrUpdateUserUseCase(IRepository<UserEntity> repo)
        {
            _repo = repo;
            _validator = new UserDtoValidator();
        }

        public async Task<int> CreateUser(UserDto userDto)
        {
            var result = _validator.Validate(userDto);

            if (!result.IsValid)
            {
                var error = GetErrorFromValidationResult(result);
                throw new ArgumentException(error);
            }

            return await _repo.InsertAsync(
                new UserEntity { 
                    Id = userDto.Id, 
                    Name = userDto.Name, 
                    Surname = userDto.Surname, 
                    CompanyId = userDto.CompanyId });
        }

        public async Task<int> UpdateUser(UserDto userDto)
        {
            var result = _validator.Validate(userDto);

            if (!result.IsValid)
            {
                var error = GetErrorFromValidationResult(result);
                throw new ArgumentException(error);
            }

            return await _repo.UpdateAsync(
                new UserEntity
                {
                    Id = userDto.Id,
                    Name = userDto.Name,
                    Surname = userDto.Surname,
                    CompanyId = userDto.CompanyId
                });
        }

        public async Task<int> DeleteUser(Guid id) => 
            await _repo.DeleteAsync(id);
    }
}
