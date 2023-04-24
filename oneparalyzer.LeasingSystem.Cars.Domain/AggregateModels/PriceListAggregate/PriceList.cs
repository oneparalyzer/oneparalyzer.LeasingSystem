using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.Entities;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Cars.Domain.Common;
using oneparalyzer.LeasingSystem.Cars.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate;

public sealed class PriceList : AggregateRoot<Guid>
{
    private readonly List<PriceListPosition> _priceListPositions = new();

    public PriceList(Guid id, DateTime dateConfirm, Guid approvedEmployeeId) : base(id)
    {
        DateConfirm = dateConfirm;
        ApprovedEmployeeId = approvedEmployeeId;
    }

    public DateTime DateConfirm { get; private set; }
    public Guid ApprovedEmployeeId { get; private set; }
    public IReadOnlyList<PriceListPosition> PriceListPositions => _priceListPositions;

    public Result AddPosition(Guid carId, Price price)
    {
        var result = new Result();
        result.IsOk = true;

        PriceListPosition? position = _priceListPositions.FirstOrDefault(x => x.CarId == carId);
        if (position is not null)
        {
            result.IsOk = false;
            result.Errors.Add("Такая позиция уже существует.");
            return result;
        }

        position = new PriceListPosition(Guid.NewGuid(), carId, price);
        _priceListPositions.Add(position);
        return result;
    }
}
