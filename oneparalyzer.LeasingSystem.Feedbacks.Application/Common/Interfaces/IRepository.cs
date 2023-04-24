using oneparalyzer.LeasingSystem.Feedbacks.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Interfaces;

public interface IRepository<T> where T : AggregateRoot<Guid>
{
}
