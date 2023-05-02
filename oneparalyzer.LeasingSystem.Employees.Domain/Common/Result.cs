

namespace oneparalyzer.LeasingSystem.Employees.Domain.Common;

public class Result
{
    private readonly List<string> _errors = new();
    public bool IsOk { get; set; } = true;
    public IReadOnlyList<string> Errors => _errors.AsReadOnly();

    public void AddError(string error)
    {
        var existingError = _errors.FirstOrDefault(x => x.Equals(error));
        if (existingError is null)
        {
            _errors.Add(error);
        }
    }
}
