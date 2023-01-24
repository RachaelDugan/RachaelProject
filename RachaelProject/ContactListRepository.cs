using Dapper;
using RachaelProject.Models;
using System.Data;

namespace RachaelProject
{
    public class ContactListRepository : IContactListRepository
    {
        private readonly IDbConnection _conn;
        public ContactListRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<ContactListModel> GetAllContacts()
        {
            return _conn.Query<ContactListModel>("SELECT * FROM contactlist;");
        }
        public ContactListModel GetContactById(int id) 
        {

            return _conn.QuerySingle<ContactListModel>("SELECT * FROM contactlist " +
                "WHERE ContactId = @id, new {id = id}");
        }
        public void UpdateContact(ContactListModel contact)
        {
            _conn.Execute("UPDATE contactlist " +
                "SET ContactId = @contactid, " +
                "FullName = @fullname, " +
                "EmailAddress = @emailaddress, " +
                "PhoneNumber = @phonenumber " +
                "WHERE ContactId = @contactid",
                    new
                    {
                        ContactId = contact.ContactId,
                        FullName = contact.FullName,
                        EmailAddress = contact.EmailAddress,
                        PhoneNumber = contact.PhoneNumber
                    });
        }
        public void InsertContact(ContactListModel contactToInsert)
        {
            _conn.Execute("INSERT INTO contactlist (ContactId, FullName, EmailAddress, PhoneNumber)" +
                "VALUES (@contactid, @fullname, @emailaddress, @phonenumber);",
                new
                {
                    ContactId = contactToInsert.ContactId,
                    FullName = contactToInsert.FullName,
                    EmailAddress = contactToInsert.EmailAddress,
                    PhoneNumber = contactToInsert.PhoneNumber
                });
        }
        public IEnumerable<ContactListModel> GetContacts()
        {
            return _conn.Query<ContactListModel>("SELECT * FROM contactlist;");
        }
        public ContactListModel AssignContact()
        {
            var contactList = GetContacts();
            var contact = new ContactListModel();
            contact.ContactList = contactList;
            return contact;
        }
    }
}
            
           
            
            
