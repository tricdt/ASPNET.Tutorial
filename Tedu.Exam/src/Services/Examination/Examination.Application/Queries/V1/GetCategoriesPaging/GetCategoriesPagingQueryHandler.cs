using System;
using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Queries.V1.GetCategoriesPaging;

public class GetCategoriesPagingQueryHandler : IRequestHandler<GetCategoriesPagingQuery, ApiResult<PagedList<CategoryDto>>>
{
    public Task<ApiResult<PagedList<CategoryDto>>> Handle(GetCategoriesPagingQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
