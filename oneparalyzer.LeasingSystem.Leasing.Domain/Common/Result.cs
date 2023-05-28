

namespace oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;

public class Result
{
    private readonly List<string> _errors = new();
    public bool IsOk { get; set; } = true;
    public IReadOnlyList<string> Errors => _errors.AsReadOnly();

    public void AddError(string error)
    {
        if (IsOk)
        {
            IsOk = false;
        }

        var existingError = _errors.FirstOrDefault(x => x == error);
        if (existingError is null)
        {
            _errors.Add(error);
        }
    }

    public void AddRangeError(List<string> errors)
    {
        foreach (var error in errors)
        {
            AddError(error);
        }
    }
}
