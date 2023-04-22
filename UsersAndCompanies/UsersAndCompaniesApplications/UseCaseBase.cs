using FluentValidation.Results;
using System.Text;

namespace UsersAndCompaniesApplications
{
    public abstract class UseCaseBase
    {
        protected string GetErrorFromValidationResult(ValidationResult result)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var failure in result.Errors)
            {
                builder.AppendLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }

            return builder.ToString();
        }
    }
}
