using AutoMapper;
using MediatR;
using oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Create;

public sealed class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOfficeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CreateOfficeCommand command, CancellationToken cancellationToken)
    {
        /*var office = new Office(
            new OfficeId(Guid.Empty),
            new Address(
                new AddressId(Guid.Empty),
                command.HouseNumber,
                command.HouseBuilding,
                command.ApartmentNumber,
                new Street(
                    new StreetId(Guid.Empty),
                    command.StreetTitle,
                    new City(
                        new CityId(Guid.Empty),
                        command.CityTitle,
                        new Region(
                            new RegionId(Guid.Empty),
                            command.RegionTitle)))));*/

        var office = _mapper.Map<Office>(command);
        Result result = await _unitOfWork.OfficesRepository.CreateAsync(office, cancellationToken);
        if (result.IsOk)
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        return result;
    }
}
