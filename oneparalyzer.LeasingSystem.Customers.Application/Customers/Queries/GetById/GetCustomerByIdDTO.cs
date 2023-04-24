using oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetAll;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Enums;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetById;

public class GetCustomerByIdDTO : GetAllCutomersDTO
{
    public Guid? UserId { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public uint HouseNumber { get; set; }
    public string? HouseBuilding { get; set; }
    public string? ApartmentNumber { get; set; }
    public string StreetTitle { get; set; } = null!;
    public string CityTitle { get; set; } = null!;
    public string RegionTitle { get; set; } = null!;
    public string PassportSeria { get; set; } = null!;
    public string PassportNumber { get; set; } = null!;
    public DateTime PassportIssuingDate { get; set; }
    public string PassportIssuingDepartment { get; set; } = null!;
    public string DriverLicenseSeria { get; set; } = null!;
    public string DriverLicenseNumber { get; set; } = null!;
    public DateTime DriverLicenseIssuingDate { get; set; }
    public string? DriverLicenseComment { get; set; }
}
