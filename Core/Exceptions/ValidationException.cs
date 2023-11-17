using FluentValidation.Results;

namespace Core.Exceptions
{
    public class ValidationException:ApplicationException
    {
        public ValidationException():base("Se presentaron uno o mas errores de validicion")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures):this()
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
        public IDictionary<string, string[]> Errors { get; }

    }
}
