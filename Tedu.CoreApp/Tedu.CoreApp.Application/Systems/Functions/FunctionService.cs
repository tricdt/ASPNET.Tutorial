using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tedu.CoreApp.Application.Systems.Functions.Dtos;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Data.Entities.System;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.Interfaces;

namespace Tedu.CoreApp.Application.Systems.Functions;


public class FunctionService : IFunctionService
{
    private IRepository<Function, Guid> _functionRepository;
    private IRepository<Permission, Guid> _permissionRepository;
    private RoleManager<AppRole> _roleManager;
    private UserManager<AppUser> _userManager;
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FunctionService(IMapper mapper,
            RoleManager<AppRole> roleManager,
            UserManager<AppUser> userManager,
            IRepository<Permission, Guid> permissionRepository,
            IRepository<Function, Guid> functionRepository,
            IUnitOfWork unitOfWork)
    {
        _functionRepository = functionRepository;
        _userManager = userManager;
        _roleManager = roleManager;
        _permissionRepository = permissionRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public bool CheckExistedId(Guid id)
    {
        return _functionRepository.GetById(id) != null;
    }

    public void Add(FunctionViewModel functionVm)
    {
        var function = _mapper.Map<Function>(functionVm);
        _functionRepository.Insert(function);
    }

    public void Delete(Guid id)
    {
        _functionRepository.Delete(id);
    }

    public FunctionViewModel GetById(Guid id)
    {
        var function = _functionRepository.Single(x => x.Id == id);
        return _mapper.Map<Function, FunctionViewModel>(function);
    }

    public Task<List<FunctionViewModel>> GetAll(string filter)
    {
        var query = _functionRepository.GetAll().Where(x => x.Status == Status.Actived);
        if (!string.IsNullOrEmpty(filter))
            query = query.Where(x => x.Name.Contains(filter));
        return _mapper.ProjectTo<FunctionViewModel>(query.OrderBy(x => x.ParentId)).ToListAsync();
    }

    public IEnumerable<FunctionViewModel> GetAllWithParentId(Guid? parentId)
    {
        var query = _functionRepository.GetAll().Where(x => x.ParentId == parentId);
        return _mapper.ProjectTo<FunctionViewModel>(query);
    }

    public async Task<List<FunctionViewModel>> GetAllWithPermission(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        var roles = await _userManager.GetRolesAsync(user);

        var query = (from f in _functionRepository.GetAll()
                     join p in _permissionRepository.GetAll() on f.Id equals p.FunctionId
                     join r in _roleManager.Roles on p.RoleId equals r.Id
                     where roles.Contains(r.Name)
                     select f);

        var parentIds = query.Select(x => x.ParentId).Distinct();

        query = query.Union(_functionRepository.GetAll().Where(f => parentIds.Contains(f.Id)));

        return await _mapper.ProjectTo<FunctionViewModel>(query.OrderBy(x => x.ParentId)).ToListAsync();
    }

    public void Save()
    {
        _unitOfWork.Commit();
    }

    public void Update(FunctionViewModel functionVm)
    {
        var functionDb = _functionRepository.GetById(functionVm.Id);
        var function = _mapper.Map<Function>(functionVm);
    }

    public void ReOrder(Guid sourceId, Guid targetId)
    {
        var source = _functionRepository.GetById(sourceId);
        var target = _functionRepository.GetById(targetId);
        int tempOrder = source.SortOrder;

        source.SortOrder = target.SortOrder;
        target.SortOrder = tempOrder;

        _functionRepository.Update(source);
        _functionRepository.Update(target);
    }

    public void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items)
    {
        //Update parent id for source
        var category = _functionRepository.GetById(sourceId);
        category.ParentId = targetId;
        _functionRepository.Update(category);

        //Get all sibling
        var sibling = _functionRepository.GetAll().Where(x => items.ContainsKey(x.Id));
        foreach (var child in sibling)
        {
            child.SortOrder = items[child.Id];
            _functionRepository.Update(child);
        }
    }
}
