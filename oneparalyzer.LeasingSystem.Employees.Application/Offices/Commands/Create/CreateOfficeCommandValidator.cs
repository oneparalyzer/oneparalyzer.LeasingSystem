using FluentValidation;

namespace oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Create;

public sealed class CreateOfficeCommandValidator : AbstractValidator<CreateOfficeCommand>
{
    public CreateOfficeCommandValidator()
    {
        RuleFor(x => x.RegionTitle).NotEmpty().MinimumLength(5).MaximumLength(100);
        RuleFor(x => x.CityTitle).NotEmpty().MinimumLength(5).MaximumLength(100);
        RuleFor(x => x.StreetTitle).NotEmpty().MinimumLength(5).MaximumLength(100);
        RuleFor(x => x.HouseNumber).NotEmpty();
    }
}
