using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDocuments.Models
{
    public class Company
    {
        //Identifier  
        public int CompanyId { get; set; }
        //Company 
        public string Company_name { get; set; }
        public string Address { get; set; }
        public string Postal_Code { get; set; }
        public string City { get; set; }
        // State 
        public int StateId { get; set; }
        public virtual State State { get; set; }
        //Country  
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        //Communication 
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website_Uri { get; set; }
        //List Contacts 
        public virtual List<Contact> Contacts { get; set; }
        //List Documents 
        public virtual List<Document> Documents { get; set; }
    }
}