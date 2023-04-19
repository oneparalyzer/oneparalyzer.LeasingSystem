using MediatR;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Enums;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Commands.Create;

public record CreateCustomerCommand(
    string Name,
    string Surname,
    string Patronymic,
    DateTime birthDate,
    Gender gender,
    uint houseNumber, 
    string? houseBuilding, 
    string? apartmentNumber,
    string street,
    string city,
    string region,
    string passportSeria,
    string passportNumber,
    DateTime passportIssuingDate,
    string passportIssuingDepartment,
    string driverLicenseSeria,
    string driverLicenseNumber,
    DateTime driverLicenseIssuingDate,
    string? driverLicenseComment
    ) : IRequest;
