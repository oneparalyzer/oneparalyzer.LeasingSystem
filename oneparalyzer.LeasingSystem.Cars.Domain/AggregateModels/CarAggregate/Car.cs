using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Enums;
using oneparalyzer.LeasingSystem.Cars.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate;

public sealed class Car : AggregateRoot<Guid>
{
    private readonly List<CarDocument> _documents = new();

    public Car(
        Guid id,
        CarInsurance insuranceDocument,
        CarPassport passportDocument,
        СarRegistrationCertificate registrationCertificateDocument,
        CarCategory category,
        string vinNumber,
        DateTime issuingDate,
        CarEcologicalClass ecologicalClass,
        uint maxWeight,
        uint weightWithoutLoad,
        string customsRestrictions,
        string customsDeclarationNumber,
        string approvalCertificateNumber,
        CarType type,
        string bodyNumber,
        string frameNumber,
        string color,
        string engineNumber,
        uint enginePower,
        uint engineCapacity,
        EngineType engineType,
        string modelEngine,
        Country importCountry,
        Guid importCountryId,
        CarModel carModel,
        Guid carModelId,
        Guid officeId) : base(id)
    {
        _documents.Add(insuranceDocument);
        _documents.Add(passportDocument);
        _documents.Add(registrationCertificateDocument);
        Category = category;
        VinNumber = vinNumber;
        IssuingDate = issuingDate;
        EcologicalClass = ecologicalClass;
        MaxWeight = maxWeight;
        WeightWithoutLoad = weightWithoutLoad;
        CustomsRestrictions = customsRestrictions;
        CustomsDeclarationNumber = customsDeclarationNumber;
        ApprovalCertificateNumber = approvalCertificateNumber;
        Type = type;
        BodyNumber = bodyNumber;
        FrameNumber = frameNumber;
        Color = color;
        EngineNumber = engineNumber;
        EnginePower = enginePower;
        EngineCapacity = engineCapacity;
        EngineType = engineType;
        ModelEngine = modelEngine;
        ImportCountry = importCountry;
        ImportCountryId = importCountryId;
        CarModel = carModel;
        CarModelId = carModelId;
        OfficeId = officeId;
    }

    private Car(Guid id) : base(id)
    {
    }

    public CarCategory Category { get; private set; }
    public string VinNumber { get; private set; }
    public DateTime IssuingDate { get; private set; }
    public CarEcologicalClass EcologicalClass { get; private set; }
    public uint MaxWeight { get; private set; }
    public uint WeightWithoutLoad { get; private set; }
    public string CustomsRestrictions { get; private set; }
    public string CustomsDeclarationNumber { get; private set; }
    public string ApprovalCertificateNumber { get; private set; }
    public CarType Type { get; private set; }
    public string BodyNumber { get; private set; }
    public string FrameNumber { get; private set; }
    public string Color { get; private set; }
    public string EngineNumber { get; private set; }
    public uint EnginePower { get; private set; }
    public uint EngineCapacity { get; private set; }
    public EngineType EngineType { get; private set; }
    public string ModelEngine { get; private set; }
    public Country ImportCountry { get; private set; }
    public Guid ImportCountryId { get; private set; }
    public CarModel CarModel { get; private set; }
    public Guid CarModelId { get; private set; }
    public Guid OfficeId { get; private set; }
    public IReadOnlyList<CarDocument> Documents => _documents;
}
