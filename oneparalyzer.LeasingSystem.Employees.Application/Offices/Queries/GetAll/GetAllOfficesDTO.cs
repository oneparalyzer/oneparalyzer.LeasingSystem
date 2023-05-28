

namespace oneparalyzer.LeasingSystem.Employees.Application.Offices.Queries.GetAll;

public class GetAllOfficesDTO
{
    public Guid OfficeId { get; set; }
    public string RegionTitle { get; set; } = null!;
    public string CityTitle { get; set; } = null!;
    public string StreetTitle { get; set; } = null!;
    public uint HouseNumber { get; set; }   
    public string? HouseBuilding { get; set; }
}
