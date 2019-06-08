using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts_test_task.Models
{
    public class PaginationModel
    {
        private int _count = 10;

        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

        public int page { get; set; }
        public int toSkip
        {
            get
            {
                return page * _count;
            }
        }
    }
}