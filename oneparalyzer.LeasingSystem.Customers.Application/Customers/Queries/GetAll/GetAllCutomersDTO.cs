

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetAll;

public class GetAllCutomersDTO
{
    public Guid CustomerId { get; set; } 
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Patronymic { get; set; } = null!;
}
    
