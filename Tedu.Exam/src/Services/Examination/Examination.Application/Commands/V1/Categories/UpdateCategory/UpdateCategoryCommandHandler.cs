using System;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.Categories.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ApiResult<bool>>
{
    public Task<ApiResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
