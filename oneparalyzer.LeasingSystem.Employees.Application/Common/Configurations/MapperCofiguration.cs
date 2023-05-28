using AutoMapper;
using oneparalyzer.LeasingSystem.Employees.Application.Departments.Queries.GetAllByOfficeId;
using oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Create;
using oneparalyzer.LeasingSystem.Employees.Application.Offices.Queries.GetAll;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Employees.Application.Common.Configurations;

public class MapperCofiguration : Profile
{
    public MapperCofiguration()
    {
        CreateMap<CreateOfficeCommand, Office>()
            .ForPath(dst => dst.Id, opt => opt.MapFrom(src => new OfficeId(Guid.NewGuid())))
            .ForPath(dst => dst.Address.Id, opt => opt.MapFrom(src => new AddressId(Guid.NewGuid())))
            .ForPath(dst => dst.Address.Street.Id, opt => opt.MapFrom(src => new StreetId(Guid.NewGuid())))
            .ForPath(dst => dst.Address.Street.City.Id, opt => opt.MapFrom(src => new CityId(Guid.NewGuid())))
            .ForPath(dst => dst.Address.Street.City.Region.Id, opt => opt.MapFrom(src => new RegionId(Guid.NewGuid())))

            .ForPath(dst => dst.Address.HouseNumber, src => src.MapFrom(src => src.HouseNumber))
            .ForPath(dst => dst.Address.HouseBuilding, src => src.MapFrom(src => src.HouseBuilding))
            .ForPath(dst => dst.Address.Street.Title, src => src.MapFrom(src => src.StreetTitle))
            .ForPath(dst => dst.Address.Street.City.Title, src => src.MapFrom(src => src.CityTitle))
            .ForPath(dst => dst.Address.Street.City.Region.Title, src => src.MapFrom(src => src.RegionTitle));

        CreateMap<Office, GetAllOfficesDTO>()
            .ForPath(dst => dst.OfficeId, opt => opt.MapFrom(src => src.Id.Value))
            .ForPath(dst => dst.RegionTitle, opt => opt.MapFrom(src => src.Address.Street.City.Region.Title))
            .ForPath(dst => dst.CityTitle, opt => opt.MapFrom(src => src.Address.Street.City.Title))
            .ForPath(dst => dst.StreetTitle, opt => opt.MapFrom(src => src.Address.Street.Title))
            .ForPath(dst => dst.HouseBuilding, opt => opt.MapFrom(src => src.Address.HouseBuilding))
            .ForPath(dst => dst.HouseNumber, opt => opt.MapFrom(src => src.Address.HouseNumber));

        CreateMap<Department, GetAllDepartmentsByOfficeIdDTO>()
            .ForPath(dst => dst.DepartmentId, opt => opt.MapFrom(src => src.Id.Value));
    }
}
