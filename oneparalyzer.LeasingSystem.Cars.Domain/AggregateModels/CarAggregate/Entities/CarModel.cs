using oneparalyzer.LeasingSystem.Cars.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;

public sealed class CarModel : Entity<Guid>
{
    public CarModel(Guid id, string title, CarBrand carBrand) : base(id)
    {
        Title = title;
        CarBrandId = CarBrand.Id;
        CarBrand = carBrand;
    }

    private CarModel(Guid id) : base(id)
    {
    }

    public string Title { get; private set; }
    public Guid CarBrandId { get; private set; }
    public CarBrand CarBrand { get; private set; }
}
