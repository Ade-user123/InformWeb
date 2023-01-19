using InformWeb.Repository.Entities;
using InformWeb.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;


namespace InformWeb.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactService contactService, ILogger<ContactsController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }
        public ActionResult Index()
        {
            try
            {
                var lstContactsData = _contactService.GetAll();
                return View(lstContactsData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        public ActionResult Details(Guid Id)
        {
            var contactData = _contactService.GetById(Id);
            return View(contactData);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactService.Add(contact);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        public ActionResult Edit(Guid id)
        {
            try
            {
                var contactInfo = _contactService.GetById(id);
                return View(contactInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _contactService.Update(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return View(model);
        }

        public ActionResult Delete(Guid Id)
        {
            _contactService.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
