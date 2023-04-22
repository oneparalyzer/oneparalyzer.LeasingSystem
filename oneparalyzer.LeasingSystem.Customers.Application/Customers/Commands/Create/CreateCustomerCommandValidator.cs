using FluentValidation;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Commands.Create;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Surname).NotEmpty();
        RuleFor(x => x.Patronymic).NotEmpty();
        RuleFor(x => x.DriverLicenseSeria).MinimumLength(4).MaximumLength(4);
        RuleFor(x => x.DriverLicenseNumber).MinimumLength(6).MaximumLength(6);
    }
}
