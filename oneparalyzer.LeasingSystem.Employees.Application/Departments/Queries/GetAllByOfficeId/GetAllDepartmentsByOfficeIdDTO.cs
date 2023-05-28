

namespace oneparalyzer.LeasingSystem.Employees.Application.Departments.Queries.GetAllByOfficeId;

public class GetAllDepartmentsByOfficeIdDTO
{
    public Guid DepartmentId { get; set; }
    public string Title { get; set; } = null!;
}
