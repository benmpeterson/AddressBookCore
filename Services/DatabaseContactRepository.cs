using System;
using System.Collections.Generic;
using AddressBook.Models;
using AddressBook.Data;

namespace AddressBook.Services
{
    public class DatabaseContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DatabaseContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        void IContactRepository.AddContact(Contact Contact)
        {
            _dbContext.Contacts.Add(Contact);
            _dbContext.SaveChanges();
        }

        IEnumerable<Contact> IContactRepository.GetAllContacts()
        {
            return _dbContext.Contacts;
        }
    }
}