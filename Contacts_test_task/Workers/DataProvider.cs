using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Contacts_test_task.Models;
using System.IO;
using System.Web.Script.Serialization;

namespace Contacts_test_task.Workers
{
    public class DataProvider : IContactsRepository
    {
        string filePath;
        static object locker = new object();

        public DataProvider(string filePath)
        {
            this.filePath = filePath;
        }

        public Dictionary<Guid, Item> GetAllContacts()
        {
            string text;
            lock (locker)
            {
                using (var reader = new StreamReader(filePath))
                {
                    text = reader.ReadToEnd();
                }
            }
            var array = new JavaScriptSerializer().Deserialize<Item[]>(text);
            return array.ToDictionary<Item, Guid>(t => t.id);
        }

        public void WriteAllContacts(Dictionary<Guid, Item> contacts)
        {
            var array = contacts.Values;
            string text = new JavaScriptSerializer().Serialize(array);
            lock (locker)
            {
                using (var writer = new StreamWriter(filePath, false))
                {
                    writer.Write(text);
                }
            }
        }


        public void AddContact(Item contact)
        {
            throw new NotImplementedException();
        }
        public void RemoveContact(Guid id)
        {
            throw new NotImplementedException();
        }
        public void UpdateContact(Item contact)
        {
            throw new NotImplementedException();
        }
    }
}