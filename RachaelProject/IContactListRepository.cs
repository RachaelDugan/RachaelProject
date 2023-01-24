using RachaelProject.Models;

namespace RachaelProject
{
    public interface IContactListRepository
    {
        public IEnumerable<ContactListModel> GetAllContacts();
        public IEnumerable<ContactListModel> GetContacts();
        public ContactListModel GetContactById(int id);
        public void UpdateContact(ContactListModel contact);
        public void InsertContact(ContactListModel contactToInsert);
        public ContactListModel AssignContact();
    }
}
