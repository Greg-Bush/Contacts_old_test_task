using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts_test_task.Models
{
    public class ContactsViewModel
    {
        public IEnumerable<Item> Results { get; set; }
        public int TotalCount { get; set; }
    }
}