using MediatR;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Enums;
using oneparalyzer.LeasingSystem.Customers.Domain.Common;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Commands.Create;

public record CreateCustomerCommand(
    string Name,
    string Surname,
    string Patronymic,
    DateTime BirthDate,
    Gender Gender,
    uint HouseNumber, 
    string? HouseBuilding, 
    string? ApartmentNumber,
    string StreetTitle,
    string CityTitle,
    string RegionTitle,
    string PassportSeria,
    string PassportNumber,
    DateTime PassportIssuingDate,
    string PassportIssuingDepartment,
    string DriverLicenseSeria,
    string DriverLicenseNumber,
    DateTime DriverLicenseIssuingDate,
    string? DriverLicenseComment) : IRequest<Result>;
