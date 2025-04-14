using System;
using System.Linq.Expressions;
using Tedu.Shop.Infrastructure.Enums;
using Tedu.Shop.Infrastructure.SharedKernel;
using Tedu.Shop.Utilities.Dtos;

namespace Tedu.Shop.Application;

public interface IWebServiceBase<TEntity, TPrimaryKey, ViewModel> where ViewModel : class
       where TEntity : DomainEntity<TPrimaryKey>
{
    void Add(ViewModel viewModel);

    void Update(ViewModel viewModel);

    void Delete(TPrimaryKey id);

    ViewModel GetById(TPrimaryKey id);

    List<ViewModel> GetAll();

    PagedResult<ViewModel> GetAllPaging(Expression<Func<TEntity, bool>> predicate, Func<TEntity, bool> orderBy,
        SortDirection sortDirection, int pageIndex, int pageSize);

    void Save();
}
