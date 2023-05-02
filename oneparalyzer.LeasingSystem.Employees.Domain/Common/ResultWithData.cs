

namespace oneparalyzer.LeasingSystem.Employees.Domain.Common;

public sealed class ResultWithData<TData> : Result
{
    public TData? Data { get; set; }
}
