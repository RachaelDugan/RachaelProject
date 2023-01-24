using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using RachaelProject.Models;

namespace RachaelProject.Controllers
{
    public class ContactListController : Controller
    {
        private readonly IContactListRepository repo;

        public ContactListController(IContactListRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var contact = repo.GetAllContacts();
            return View(contact);
        }
        public IActionResult ViewContact(int id)
        {
            var contact = repo.GetContactById(id);
            return View(contact);
        }
        public IActionResult UpdateContact(int id)
        {
            ContactListModel contact = repo.GetContactById(id);
            if (contact == null)
            {
                return View("ContactNotFound");
            }
            return View(contact);
        }
        public IActionResult UpdateContactToDatabase(ContactListModel contact)
        {
            repo.UpdateContact(contact);

            return RedirectToAction("ViewContact", new { id = contact.ContactId });
        }
        public IActionResult InsertContact()
        {
            var contact = repo.AssignContact();
            return View(contact);
        }
        public IActionResult InsertContactToDatabase(ContactListModel ContactToInsert)
        {
            repo.InsertContact(ContactToInsert);
            return RedirectToAction("Index");
        }
    }
}


    
