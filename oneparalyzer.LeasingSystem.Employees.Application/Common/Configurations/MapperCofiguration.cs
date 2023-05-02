using AutoMapper;
using oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Create;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;

namespace oneparalyzer.LeasingSystem.Employees.Application.Common.Configurations;

public class MapperCofiguration : Profile
{
    public MapperCofiguration()
    {
        CreateMap<CreateOfficeCommand, Office>()
            .ForPath(dst => dst.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForPath(dst => dst.Address.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForPath(dst => dst.Address.Street.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForPath(dst => dst.Address.Street.City.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForPath(dst => dst.Address.Street.City.Region.Id, opt => opt.MapFrom(src => Guid.NewGuid()))

            .ForPath(dst => dst.Address.ApartmentNumber, src => src.MapFrom(src => src.ApartmentNumber))
            .ForPath(dst => dst.Address.HouseNumber, src => src.MapFrom(src => src.HouseNumber))
            .ForPath(dst => dst.Address.HouseBuilding, src => src.MapFrom(src => src.HouseBuilding))
            .ForPath(dst => dst.Address.Street.Title, src => src.MapFrom(src => src.StreetTitle))
            .ForPath(dst => dst.Address.Street.City.Title, src => src.MapFrom(src => src.CityTitle))
            .ForPath(dst => dst.Address.Street.City.Region.Title, src => src.MapFrom(src => src.RegionTitle));
    }
}
