using AutoMapper;
using oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetAll;
using oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetById;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Enums;

namespace oneparalyzer.LeasingSystem.Customers.Application.Common.Mapping;

public sealed class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<Customer, GetAllCutomersDTO>()
            .ForPath(dst => dst.Name, opt => opt.MapFrom(src => src.FullName.Name))
            .ForPath(dst => dst.Surname, opt => opt.MapFrom(src => src.FullName.Surname))
            .ForPath(dst => dst.Patronymic, opt => opt.MapFrom(src => src.FullName.Patronymic))
            .ForPath(dst => dst.CustomerId, opt => opt.MapFrom(src => src.Id));

        CreateMap<Customer, GetByIdCustomerDTO>()
            .ForPath(dst => dst.Name, opt => opt.MapFrom(src => src.FullName.Name))
            .ForPath(dst => dst.Surname, opt => opt.MapFrom(src => src.FullName.Surname))
            .ForPath(dst => dst.Patronymic, opt => opt.MapFrom(src => src.FullName.Patronymic))
            .ForPath(dst => dst.CustomerId, opt => opt.MapFrom(src => src.Id))
            .ForPath(dst => dst.RegionTitle, opt => opt.MapFrom(src => src.Address.Street.City.Region.Title))
            .ForPath(dst => dst.CityTitle, opt => opt.MapFrom(src => src.Address.Street.City.Title))
            .ForPath(dst => dst.StreetTitle, opt => opt.MapFrom(src => src.Address.Street.Title))
            .ForPath(dst => dst.HouseNumber, opt => opt.MapFrom(src => src.Address.HouseNumber))
            .ForPath(dst => dst.HouseBuilding, opt => opt.MapFrom(src => src.Address.HouseBuilding))
            .ForPath(dst => dst.ApartmentNumber, opt => opt.MapFrom(src => src.Address.ApartmentNumber))

            .ForPath(dst => dst.PassportSeria, opt => opt.MapFrom(src =>
                src.Documents.FirstOrDefault(x
                    => x.Type == DocumentType.Passport).DocumentIdentifier.Seria))

            .ForPath(dst => dst.PassportNumber, opt => opt.MapFrom(src =>
                src.Documents.FirstOrDefault(x
                    => x.Type == DocumentType.Passport).DocumentIdentifier.Number))

            .ForPath(dst => dst.PassportIssuingDepartment, opt => opt.MapFrom(src =>
                src.Documents.FirstOrDefault(x
                    => x.Type == DocumentType.Passport).IssuingDepartment.Title))

            .ForPath(dst => dst.PassportIssuingDate, opt => opt.MapFrom(src =>
                src.Documents.FirstOrDefault(x
                    => x.Type == DocumentType.Passport).IssuingDate))

            .ForPath(dst => dst.DriverLicenseSeria, opt => opt.MapFrom(src => 
                src.Documents.FirstOrDefault(x 
                    => x.Type == DocumentType.DriverLicense).DocumentIdentifier.Seria))
            
            .ForPath(dst => dst.DriverLicenseNumber, opt => opt.MapFrom(src =>
                src.Documents.FirstOrDefault(x
                    => x.Type == DocumentType.DriverLicense).DocumentIdentifier.Number))

            .ForPath(dst => dst.DriverLicenseComment, opt => opt.MapFrom(src =>
                src.Documents.FirstOrDefault(x
                    => x.Type == DocumentType.DriverLicense).Comment))

            .ForPath(dst => dst.DriverLicenseIssuingDate, opt => opt.MapFrom(src =>
                src.Documents.FirstOrDefault(x
                    => x.Type == DocumentType.DriverLicense).IssuingDate));


    }
}
