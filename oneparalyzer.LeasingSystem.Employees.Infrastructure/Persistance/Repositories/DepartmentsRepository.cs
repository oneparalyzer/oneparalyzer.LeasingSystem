using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.Repositories;

public sealed class DepartmentsRepository : IDepartmentsRepository
{
    private readonly CompaniesDbContext _context;

    public DepartmentsRepository(CompaniesDbContext context)
    {
        _context = context;
    }

    public async Task<Result> CreateAsync(Department department, CancellationToken cancellationToken = default)
    {
        var result = new Result();
        result.IsOk = true;

        Department? existingDepartment = await _context.Departments.FirstOrDefaultAsync(x =>
            x.Title == department.Title,
            cancellationToken);
        if (existingDepartment is not null)
        {
            result.IsOk = false;
            result.AddError("Структурное подразделение с таким названием уже существует.");
            return result;
        }

        await _context.Departments.AddAsync(department, cancellationToken);
        return result;
    }

    public async Task<ResultWithData<IEnumerable<Department>>> GetAllByOfficeIdAsync(OfficeId officeId, CancellationToken cancellationToken = default)
    {
        var result = new ResultWithData<IEnumerable<Department>>();
        result.IsOk = true;

        IEnumerable<Department> departments = await _context.Departments
            .Include(x => x.PostIds)
            .Where(x => x.OfficeId == officeId)
            .ToListAsync(cancellationToken);

        result.Data = departments;
        return result;
    }

    public async Task<ResultWithData<Department>> GetByIdAsync(DepartmentId departmentId, CancellationToken cancellationToken = default)
    {
        var result = new ResultWithData<Department>();
        result.IsOk = true;

        Department? department = await _context.Departments
            .Include(x => x.PostIds)
            .FirstOrDefaultAsync(x =>
                x.Id == departmentId, 
                cancellationToken);

        if (department is null)
        {
            result.IsOk = false;
            result.AddError("Не найдено структурное подразделение");
            return result;
        }

        result.Data = department;
        return result;
    }

    public async Task<Result> RemoveByIdAsync(DepartmentId departmentId, CancellationToken cancellationToken = default)
    {
        var result = new Result();
        result.IsOk = true;

        Department? department = await _context.Departments
            .Include(x => x.PostIds)
            .FirstOrDefaultAsync(x =>
                x.Id == departmentId,
                cancellationToken);

        if (department is null)
        {
            result.IsOk = false;
            result.AddError("Не найдено структурное подразделение");
            return result;
        }

        _context.Departments.Remove(department);

        return result;
    }

    public async Task<Result> UpdateAsync(Department department, CancellationToken cancellationToken = default)
    {
        var result = new Result();
        result.IsOk = true;

        Department? existingDepartment = await _context.Departments
            .Include(x => x.PostIds)
            .FirstOrDefaultAsync(x =>
                x.Id == department.Id,
                cancellationToken);

        if (department is null)
        {
            result.IsOk = false;
            result.AddError("Не найдено структурное подразделение");
            return result;
        }

        _context.Departments.Update(department);

        return result;
    }
}
