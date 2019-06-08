using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contacts_test_task.Models;
using System.Text.RegularExpressions;

namespace Contacts_test_task.Workers
{
    public class ContactsManager
    {
        private IContactsRepository cache, dp;

        public ContactsManager(IContactsRepository dataProvider, IContactsRepository cacheProvider)
        {
            this.cache = cacheProvider;
            this.dp = dataProvider;
        }

        private IEnumerable<Item> allContacts
        {
            get
            {
                return cache.GetAllContacts().Values;
            }
        }
        private void SubmitChanges()
        {
            dp.WriteAllContacts(cache.GetAllContacts());
        }


        public void AddContact(Item contact)
        {
            cache.AddContact(contact);
            SubmitChanges();
        }
        public void RemoveContact(Guid id)
        {
            cache.RemoveContact(id);
            SubmitChanges();
        }
        public void UpdateContact(Item contact)
        {
            cache.UpdateContact(contact);
            SubmitChanges();
        }

        public ContactsViewModel GetContacts(PaginationModel pageFilter, SearchModel searchFilter = null)
        {
            var result = new ContactsViewModel();

            IEnumerable<Item> results = allContacts;

            if (searchFilter != null)
            {
                if (!string.IsNullOrWhiteSpace(searchFilter.first_name))
                {
                    results = results.Where(t => IsMatch(t.first_name, searchFilter.first_name));
                }
                if (!string.IsNullOrWhiteSpace(searchFilter.last_name))
                {
                    results = results.Where(t => IsMatch(t.last_name, searchFilter.last_name));
                }
                if (!string.IsNullOrWhiteSpace(searchFilter.job_title))
                {
                    results = results.Where(t => IsMatch(t.job_title, searchFilter.job_title));
                }
                if (!string.IsNullOrWhiteSpace(searchFilter.company_name))
                {
                    results = results.Where(t => IsMatch(t.company_name, searchFilter.company_name));
                }
            }

            result.TotalCount = results.Count();

            result.Results = results
                .OrderByDescending(t => t.date).Skip(pageFilter.toSkip).Take(pageFilter.count);

            return result;
        }

        private bool IsMatch(string value, string filter)
        {
            return value.ToLower().Contains(filter.ToLower());
        }



    }
}