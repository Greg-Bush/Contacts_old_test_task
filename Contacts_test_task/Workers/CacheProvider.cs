using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Contacts_test_task.Models;

namespace Contacts_test_task.Workers
{
    public class CacheProvider : IContactsRepository
    {
        static Dictionary<Guid, Item> allContacts;


        public static void Init(IContactsRepository dataProvider)
        {
            allContacts = dataProvider.GetAllContacts();
        }


        public Dictionary<Guid, Item> GetAllContacts()
        {
            return allContacts;
        }
        public void WriteAllContacts(Dictionary<Guid, Item> contacts)
        {
            allContacts = contacts;
        }
        public void AddContact(Item contact)
        {
            allContacts.Add(contact.id, contact);
        }
        public void RemoveContact(Guid id)
        {
            allContacts.Remove(id);
        }
        public void UpdateContact(Item contact)
        {
            var current = allContacts[contact.id];
            contact.date = current.date;

            allContacts[contact.id] = contact;
        }

    }
}