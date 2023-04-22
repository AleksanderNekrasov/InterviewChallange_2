using FluentValidation;
using UsersAndCompaniesApplications.Dtos;

namespace compsAndCompaniesApplications.Validations
{
    public class CompanyDtoValidator : AbstractValidator<CompanyDto>
    {
        public CompanyDtoValidator()
        {
            RuleFor(comp => comp.Id).NotNull();
            RuleFor(comp => comp.Id).NotEqual(Guid.Empty);
            RuleFor(comp => comp.CompanyName).NotNull();
            RuleFor(comp => comp.Address).NotNull();
        }
    }
}
