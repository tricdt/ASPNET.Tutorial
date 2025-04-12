using System;
using Tedu.CoreApp.Application.Systems.Functions.Dtos;

namespace Tedu.CoreApp.Application.Systems.Functions;

public interface IFunctionService
{
    void Add(FunctionViewModel function);

    Task<List<FunctionViewModel>> GetAll(string filter);

    Task<List<FunctionViewModel>> GetAllWithPermission(string userName);

    IEnumerable<FunctionViewModel> GetAllWithParentId(Guid? parentId);

    FunctionViewModel GetById(Guid id);

    void Update(FunctionViewModel function);

    void Delete(Guid id);

    void Save();

    bool CheckExistedId(Guid id);

    void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items);

    void ReOrder(Guid sourceId, Guid targetId);
}
