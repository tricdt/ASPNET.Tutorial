using System;
using XTLab.MvcApp.Application.ViewModels;
using XTLab.MvcApp.Utilities.DTOs;

namespace XTLab.MvcApp.Application.Interface;

public interface IContactService
{
    void Add(ContactViewModel contactVm);

    void Update(ContactViewModel contactVm);

    void Delete(int id);

    List<ContactViewModel> GetAll();
    PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize);
    ContactViewModel GetById(int id);

    void SaveChanges();
}
