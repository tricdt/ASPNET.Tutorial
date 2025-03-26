using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XTLab.MvcApp.Application.Interface;
using XTLab.MvcApp.Application.ViewModels;
using XTLab.MvcApp.Data.EF;
using XTLab.MvcApp.Data.Entities;

namespace XTLab.MvcApp.Areas.Contact.Controllers
{
    [Area("Contact")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;
        public ContactController(AppDbContext context, IMapper mapper, IContactService contactService)
        {
            _context = context;
            _mapper = mapper;
            _contactService = contactService;
        }
        [HttpGet("/admin/contact")]
        public IActionResult Index()
        {
            return View(_contactService.GetAll());
        }

        [HttpGet("/admin/contact/detail/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _contactService.GetById((int)id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpGet("/contact/")]
        [AllowAnonymous]
        public IActionResult SendContact()
        {
            return View();
        }
        [HttpPost("/contact/")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendContact([Bind("FullName,Email,Message,Phone")] ContactViewModel contactVm)
        {
            if (ModelState.IsValid)
            {

                contactVm.DateSent = DateTime.Now;

                _contactService.Add(contactVm);
                _contactService.SaveChanges();

                StatusMessage = "Liên hệ của bạn đã được gửi";

                return RedirectToAction("Index", "Home");
            }
            return View(contactVm);
        }
                [HttpGet("/admin/contact/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _contactService.GetById((int)id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost("/admin/contact/delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           _contactService.Delete(id);
           _contactService.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [TempData]
        public string StatusMessage { set; get; }
    }
}
