

namespace oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;

public sealed class ResultWithData<TData> : Result
{
    public TData? Data { get; set; }
}
