using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Contacts_test_task.Models;

namespace Contacts_test_task.Workers
{
    public interface IRepository<T_Id, T_Item, TList>
    {
        TList GetAllContacts();
        void WriteAllContacts(TList contacts);
        void AddContact(T_Item contact);
        void RemoveContact(T_Id id);
        void UpdateContact(T_Item contact);
    }

    public interface IContactsRepository : IRepository<Guid, Item, Dictionary<Guid, Item>>
    { }
}