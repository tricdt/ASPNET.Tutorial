using System;
using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Queries.V1.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ApiResult<CategoryDto>>
{
    public Task<ApiResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
