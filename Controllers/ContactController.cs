using Microsoft.AspNetCore.Mvc;
using AddressBook.Services;
using AddressBook.Models;

namespace AddressBook.Controllers

{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            var model = _contactRepository.GetAllContacts();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if(ModelState.IsValid)
            {
                _contactRepository.AddContact(contact);
                return RedirectToAction("Index");
            }


            return View();
        }

    }
}