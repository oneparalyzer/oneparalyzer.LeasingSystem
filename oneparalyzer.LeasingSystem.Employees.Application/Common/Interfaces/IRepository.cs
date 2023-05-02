

using oneparalyzer.LeasingSystem.Employees.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;

public interface IRepository<TEntity, TId> where TEntity : AggregateRoot<TId> where TId : class
{
}
