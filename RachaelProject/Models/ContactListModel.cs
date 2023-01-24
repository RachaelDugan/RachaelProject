using System.ComponentModel.DataAnnotations;
using RachaelProject.Models;

namespace RachaelProject.Models
{
    public class ContactListModel
    {
        public IEnumerable<ContactListModel>? ContactList { get; set; }
        public int ContactId { get; set; }
        public string? FullName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
    }
}
