using System;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Tedu.Shop.Infrastructure.Enums;
using Tedu.Shop.Infrastructure.Interfaces;
using Tedu.Shop.Infrastructure.SharedKernel;
using Tedu.Shop.Utilities.Dtos;

namespace Tedu.Shop.Application;

/// <summary>
    /// Base webserice for all services
    /// Creator: Toanbn
    /// Created Date: May 10, 2018
    /// </summary>
    /// <typeparam name="TEntity">Main entity for WS</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type for main entity</typeparam>
    /// <typeparam name="ViewModel">View Model class</typeparam>
    public abstract class WebServiceBase<TEntity, TPrimaryKey, ViewModel> : IWebServiceBase<TEntity, TPrimaryKey, ViewModel>
        where ViewModel : class
        where TEntity : DomainEntity<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        protected WebServiceBase(IRepository<TEntity, TPrimaryKey> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual void Add(ViewModel viewModel)
        {
            var model = _mapper.Map<ViewModel, TEntity>(viewModel);
            _repository.Insert(model);
        }

        public virtual void Delete(TPrimaryKey id)
        {
            _repository.Delete(id);
        }

        public virtual ViewModel GetById(TPrimaryKey id)
        {
            return _mapper.Map<TEntity, ViewModel>(_repository.GetById(id));
        }

        public virtual List<ViewModel> GetAll()
        {
            return _repository.GetAll().ProjectTo<ViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public virtual PagedResult<ViewModel> GetAllPaging(Expression<Func<TEntity, bool>> predicate, Func<TEntity, bool> orderBy,
            SortDirection sortDirection, int pageIndex, int pageSize)
        {
            var query = _repository.GetAll().Where(predicate);

            int totalRow = query.Count();

            if (sortDirection == SortDirection.Ascending)
            {
                query = query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable();
            }
            else
            {
                query = query.OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable();
            }

            var data = query.ProjectTo<ViewModel>(_mapper.ConfigurationProvider).ToList();
            var paginationSet = new PagedResult<ViewModel>()
            {
                Results = data,
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public virtual void Save()
        {
            _unitOfWork.Commit();
        }

        public virtual void Update(ViewModel viewModel)
        {
            var model = _mapper.Map<ViewModel, TEntity>(viewModel);
            _repository.Update(model);
        }
    }