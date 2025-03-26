using System;
using AutoMapper;
using XTLab.MvcApp.Application.Interface;
using XTLab.MvcApp.Application.ViewModels;
using XTLab.MvcApp.Data.Entities;
using XTLab.MvcApp.Infrastructure.Interfaces;
using XTLab.MvcApp.Utilities.DTOs;

namespace XTLab.MvcApp.Application.Implementation;

public class ContactService : IContactService, IDisposable
{
    private IRepository<Contact, int> _contactRepository;
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ContactService(IRepository<Contact, int> contactRepository,
    IUnitOfWork unitOfWork, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public void Add(ContactViewModel contactVm)
    {
        var page = _mapper.Map<ContactViewModel, Contact>(contactVm);
        _contactRepository.Insert(page);
    }

    public void Delete(int id)
    {
        _contactRepository.Delete(e => e.Id == id);
    }

    public List<ContactViewModel> GetAll()
    {
        return _mapper.ProjectTo<ContactViewModel>(
            _contactRepository.GetAll()).ToList();
    }

    public ContactViewModel GetById(int id)
    {
        return _mapper.Map<Contact, ContactViewModel>(_contactRepository.FirstOrDefault(id));
    }

    public void SaveChanges()
    {
        _unitOfWork.Commit();
    }

    public void Update(ContactViewModel contactVm)
    {
        var page = _mapper.Map<ContactViewModel, Contact>(contactVm);
        _contactRepository.Update(page);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize)
    {
        var query = _contactRepository.GetAll();
        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(x => x.FullName.Contains(keyword));

        int totalRow = query.Count();
        var data = query.OrderByDescending(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        var paginationSet = new PagedResult<ContactViewModel>()
        {
            Results = _mapper.ProjectTo<ContactViewModel>(data).ToList(),
            CurrentPage = page,
            RowCount = totalRow,
            PageSize = pageSize
        };

        return paginationSet;
    }
}
