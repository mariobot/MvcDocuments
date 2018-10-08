using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDocuments.Models
{
    public class Contact
    {
        //Identifier 
        public int ContactId { get; set; }
        //Company  
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        //Function 
        public int FunctionId { get; set; }
        public virtual Function Function { get; set; }
        //Title 
        public int TitleId { get; set; }
        public virtual Title Title { get; set; }
        //Contact 
        public string Surname { get; set; }
        public string Last_name { get; set; }
        //Communication 
        public string Email_address { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }
    }
}