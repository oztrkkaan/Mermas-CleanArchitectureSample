using System.Collections.Generic;

namespace Mermas.Application.Common.Results
{
    public class Result : IResult
    {
        public Result()
        {
        }
        public Result(bool success)
        {
            Success = success;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success, IList<ValidationError> validationErrors)
        {
            Success = success;
            ValidationErrors = validationErrors;
        }

        public Result(bool success, string message, IList<ValidationError> validationErrors) : this(success, message)
        {
            ValidationErrors = validationErrors;
        }


        public bool Success { get; }
        public string Message { get; }
        public IList<ValidationError> ValidationErrors { get; }
    }
}
