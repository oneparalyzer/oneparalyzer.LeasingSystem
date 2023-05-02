using MediatR;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Create;

public record CreateOfficeCommand(
    string RegionTitle,
    string CityTitle,
    string StreetTitle,
    uint HouseNumber, 
    string? HouseBuilding, 
    string? ApartmentNumber) : IRequest<Result>;
