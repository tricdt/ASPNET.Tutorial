using System;
using FluentValidation;

namespace Tedu.KnowledgeSpace.ViewModels.Systems;

public class RoleVmValidator : AbstractValidator<RoleVm>
{
    public RoleVmValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id value is required")
            .MaximumLength(50).WithMessage("Role id cannot over limit 50 characters");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Role name is required");
    }
}
