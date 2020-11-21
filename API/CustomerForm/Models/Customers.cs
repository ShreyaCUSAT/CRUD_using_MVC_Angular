using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerForm.Models
{
    public class Customers
    {
        public int rollno { get; set; }
        public string Full_Name { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }
}