using BulkCertificationToolNova.Contracts;
using System;

namespace BulkCertificationToolNova.Models
{
    internal class Result<T> : IResult<T>
    {
        public Result(T result, String error)
        {
            _result = result;
            _error = error;
        }

        public Result(T result)
        {
            _result = result;
        }

        public Boolean HasError
        {
            get
            {
                return !String.IsNullOrWhiteSpace(_error);
            }
        }

        public String Error
        {
            get
            {
                return _error;
            }
        }

        public T Value
        {
            get
            {
                return _result;
            }
        }

        private readonly T _result;
        private readonly String _error;
    }
}
