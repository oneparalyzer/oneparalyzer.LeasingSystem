using MediatR;
using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Customers.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Enums;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Customers.Domain.Common;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Commands.Create;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result>
{
    private readonly ICustomersDbContext _context;

    public CreateCustomerCommandHandler(ICustomersDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = new Result();
        result.IsOk = true;

        Region? region = await _context.Regions.FirstOrDefaultAsync(x => 
            x.Title == command.RegionTitle, 
            cancellationToken);
        if (region is null)
        {
            region = new Region(Guid.NewGuid(), command.RegionTitle);
        }

        City? city = await _context.Cities.FirstOrDefaultAsync(x => 
            x.Title == command.CityTitle, 
            cancellationToken); 
        if (city is null)
        {
            city = new City(Guid.NewGuid(), command.CityTitle, region);
        }

        Street? street = await _context.Streets.FirstOrDefaultAsync(x => 
            x.Title == command.StreetTitle, 
            cancellationToken);
        if (street is null)
        {
            street = new Street(Guid.NewGuid(), command.StreetTitle, city);
        }

        Address? address = await _context.Addresses.FirstOrDefaultAsync(x =>
            x.HouseBuilding == command.HouseBuilding &&
            x.HouseNumber == command.HouseNumber &&
            x.ApartmentNumber == command.ApartmentNumber &&
            x.StreetId == street.Id,
            cancellationToken);
        if (address is null)
        {
            address = new Address(Guid.NewGuid(), command.HouseNumber, command.HouseBuilding, command.ApartmentNumber, street);
        }

        Department? PassportIssuingDepartment = await _context.Departments.FirstOrDefaultAsync(x => 
            x.Title == command.PassportIssuingDepartment, 
            cancellationToken);
        if (PassportIssuingDepartment is null)
        {
            PassportIssuingDepartment = new Department(Guid.NewGuid(), command.PassportIssuingDepartment);
        }

        Document? passport = await _context.Documents.FirstOrDefaultAsync(x =>
            x.DocumentIdentifier.Seria == command.PassportSeria &&
            x.DocumentIdentifier.Seria == command.PassportSeria &&
            x.Type == DocumentType.Passport, 
            cancellationToken);
        if (passport is not null)
        {
            result.IsOk = false;
            result.Errors.Add("Клиент с таким пасспортом уже существует.");
        }
        passport = new Passport(
            Guid.NewGuid(),
            new DocumentIdentifier(command.PassportSeria, command.PassportNumber),
            command.PassportIssuingDate,
            PassportIssuingDepartment);

        Document? driverLicense = await _context.Documents.FirstOrDefaultAsync(x =>
            x.DocumentIdentifier.Seria == command.DriverLicenseSeria &&
            x.DocumentIdentifier.Seria == command.DriverLicenseNumber &&
            x.Type == DocumentType.DriverLicense,
            cancellationToken);
        if (driverLicense is not null)
        {
            result.IsOk = false;
            result.Errors.Add("Клиент с таким водительским удостоверением уже существует.");
        }
        driverLicense = new DriverLicense(
            Guid.NewGuid(),
            new DocumentIdentifier(command.DriverLicenseSeria, command.DriverLicenseNumber),
            command.DriverLicenseIssuingDate,
            command.DriverLicenseComment);

        if (!result.IsOk)
        {
            return result;
        }

        var customer = new Customer(
            Guid.NewGuid(),
            new FullName(
                command.Name,
                command.Surname,
                command.Patronymic),
            command.BirthDate,
            command.Gender,
            address,
            (Passport)passport,
            (DriverLicense)driverLicense);

        await _context.Customers.AddAsync(customer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return result;
    }
}
