using System;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.Categories.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ApiResult<bool>>
{
    public Task<ApiResult<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
