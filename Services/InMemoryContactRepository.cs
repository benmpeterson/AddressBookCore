using System;
using System.Collections.Generic;
using AddressBook.Models;
using System.Linq;

namespace AddressBook.Services
{
    public class InMemoryContactRepository : IContactRepository
    {
        private List<Contact> _contacts = new List<Contact>
        {
            new Contact { id = 1, FirstName = "Ben", LastName = "Peterson", PhoneNumber = "12232", EmailAddress = "test@test.com"},
            new Contact { id = 2, FirstName = "John", LastName = "Peterson", PhoneNumber = "12232", EmailAddress = "test2@test.com"},
            new Contact { id = 3, FirstName = "James", LastName = "Peterson", PhoneNumber = "12232", EmailAddress = "test3@test.com"},                        
        };

        public void AddContact(Contact Contact)
        {
            Contact.id =  _contacts.Max( c => c.id) + 1;
            _contacts.Add(Contact);
        }

        IEnumerable<Contact> IContactRepository.GetAllContacts()
        {
            return _contacts;
        }
    }
}