

using FluentValidation;

namespace oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Remove;

public sealed class RemoveOfficeByIdCommandValidator : AbstractValidator<RemoveOfficeByIdCommand>
{
    public RemoveOfficeByIdCommandValidator()
    {
        RuleFor(x => x.OfficeId).NotEmpty();
    }
}
