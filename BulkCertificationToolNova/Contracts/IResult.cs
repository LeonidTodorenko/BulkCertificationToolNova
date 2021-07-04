using System;

namespace BulkCertificationToolNova.Contracts
{
    internal interface IResult<T>
    {
        String Error { get; }

        Boolean HasError { get; }

        T Value { get; }
    }
}
