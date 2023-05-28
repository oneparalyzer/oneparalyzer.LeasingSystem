using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.Repositories;

public sealed class OfficesRepository : IOfficesRepository
{
    private readonly CompaniesDbContext _context;

    public OfficesRepository(CompaniesDbContext context)
    {
        _context = context;
    }

    public async Task<Result> CreateAsync(Office office, CancellationToken cancellationToken = default)
    {
        var result = new Result();
        result.IsOk = true;

        Region? existingRegion = await _context.Regions.FirstOrDefaultAsync(x =>
            x.Title == office.Address.Street.City.Region.Title,
            cancellationToken);
        if (existingRegion is null)
        {
            existingRegion = office.Address.Street.City.Region;
        }

        City? existingCity = await _context.Cities.FirstOrDefaultAsync(x =>
            x.Title == office.Address.Street.City.Title, 
            cancellationToken);
        if (existingCity is null)
        {
            existingCity = office.Address.Street.City;
        }

        Street? existingStreet = await _context.Streets.FirstOrDefaultAsync(x => 
            x.Title == office.Address.Street.Title,
            cancellationToken);
        if (existingStreet is null)
        {
            existingStreet = office.Address.Street;
        }

        Address? existingAddress = await _context.Addresses.FirstOrDefaultAsync(x =>
            x.HouseNumber == office.Address.HouseNumber &&
            x.HouseBuilding == office.Address.HouseBuilding,
            cancellationToken);
        if (existingAddress is null)
        {
            existingAddress = office.Address;
        }

        office = new Office(new OfficeId(Guid.NewGuid()), existingAddress);

        await _context.Offices.AddAsync(office, cancellationToken);

        return result;
        
    }

    public async Task<ResultWithData<IEnumerable<Office>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = new ResultWithData<IEnumerable<Office>>();
        result.IsOk = true;

        var offices = await _context.Offices
        .Include(x => x.Address)
            .ThenInclude(x => x.Street)
            .ThenInclude(x => x.City)
            .ThenInclude(x => x.Region).ToListAsync(cancellationToken);

        result.Data = offices;
        return result;
    }

    public async Task<ResultWithData<Office>> GetByIdAsync(OfficeId officeId, CancellationToken cancellationToken = default)
    {
        var result = new ResultWithData<Office>();
        result.IsOk = true;

        Office? offices =  await _context.Offices
            .Include(x => x.Address)
                .ThenInclude(x => x.Street)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Region)
            .FirstOrDefaultAsync(x => x.Id == officeId, cancellationToken);

        result.Data = offices;
        return result;
    }

    public async Task<Result> RemoveByIdAsync(OfficeId officeId, CancellationToken cancellationToken = default)
    {
        var result = new Result();
        result.IsOk = true;

        Office? existingOffice = await _context.Offices.FirstOrDefaultAsync(x =>
            x.Id == officeId,
            cancellationToken);
        if (existingOffice is null)
        {
            result.IsOk = false;
            result.AddError("Офис не найден");
            return result;
        }

        _context.Offices.Remove(existingOffice);

        return result;       
    }

    public async Task<Result> UpdateAsync(Office office, CancellationToken cancellationToken = default)
    {
        var result = new Result();
        result.IsOk = true;

        Office? existingOffice = await _context.Offices.FirstOrDefaultAsync(x =>
            x.Id == office.Id);
        if (existingOffice is null)
        {
            result.IsOk = false;
            result.AddError("Офис не найден.");
            return result;
        }

        _context.Offices.Update(office);

        return result;
    }
}
