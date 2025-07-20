using System;
using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Queries.V1.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ApiResult<List<CategoryDto>>>
{
    public Task<ApiResult<List<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
