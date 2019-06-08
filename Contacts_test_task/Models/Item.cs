using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Contacts_test_task.Models
{   
    public class Item
    {
        [Required]
        public string avatar { get; set; }
        [Required]
        public string company_name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string job_title { get; set; }
        [Required]
        public string phone { get; set; }
        public GenderEnum gender { get; set; }
        public virtual DateTime date { get; set; }        
        public virtual Guid id { get; set; }
    }   

    public enum GenderEnum : byte
    {
        Male,
        Female
    }
}