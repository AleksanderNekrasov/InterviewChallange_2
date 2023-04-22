using FluentValidation;
using UsersAndCompaniesApplications.Dtos;

namespace UsersAndCompaniesApplications.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator() 
        {
            RuleFor(user => user.Id).NotNull();
            RuleFor(user => user.Id).NotEqual(Guid.Empty);
            RuleFor(user => user.Name).NotNull();
            RuleFor(user => user.Surname).NotNull();
        }
    }
}
