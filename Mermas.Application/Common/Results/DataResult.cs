using System.Collections.Generic;

namespace Mermas.Application.Common.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {

        public DataResult(T data, bool success, string message, IList<ValidationError> validationErrors) : base(success, message, validationErrors)
        {
            Data = data;
        }

        public DataResult(T data, bool success, IList<ValidationError> validationErrors) : base(success, validationErrors)
        {
            Data = data;
        }
        public DataResult(bool success, string message, IList<ValidationError> validationErrors) : base(success, message, validationErrors)
        {

        }
        public DataResult(bool success, IList<ValidationError> validationErrors) : base(success, validationErrors)
        {

        }
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
