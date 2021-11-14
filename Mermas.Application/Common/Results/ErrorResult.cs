using System.Collections.Generic;

namespace Mermas.Application.Common.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
        }
        public ErrorResult(string message) : base(false, message)
        {
        }
        public ErrorResult(IList<ValidationError> validationErrors) : base(false, validationErrors)
        {
        }

        public ErrorResult(string message, IList<ValidationError> validationErrors) : base(false, message, validationErrors)
        {
        }


    }
}
