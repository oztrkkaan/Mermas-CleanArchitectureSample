using System.Collections.Generic;

namespace Mermas.Application.Common.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        IList<ValidationError> ValidationErrors { get; }
    }
}
