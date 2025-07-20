using System;
using Examination.Shared.Categories;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Queries.V1;

public class GetAllCategoriesQuery : IRequest<ApiResult<List<CategoryDto>>>
{

}
