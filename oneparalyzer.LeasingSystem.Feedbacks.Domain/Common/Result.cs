

namespace oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;

public class Result
{
    public bool IsOk { get; set; }
    public List<string> Errors { get; set; } = new();
}
