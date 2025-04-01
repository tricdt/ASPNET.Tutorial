using System;
using System.Linq.Expressions;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.SharedKernel;
using Tedu.CoreApp.Utilities.Dtos;

namespace Tedu.CoreApp.Application;

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
