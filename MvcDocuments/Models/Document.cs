using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcDocuments.Models
{
    public class Document
    {
        //Identifier 
        public int DocumentId { get; set; }
        //Document date 
        [Required]
        public DateTime Document_date { get; set; }
        //Company 
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        //Mail category 
        public int Mail_categoryID { get; set; }
        public virtual Mail_category Mail_category { get; set; }
        //Costs group 
        public int Costs_groupId { get; set; }
        public virtual Costs_group Costs_group { get; set; }
        //Payment status 
        public int Payment_statusId { get; set; }
        public virtual Payment_status Payment_status { get; set; }
        //Bill
        [Required]
        public string Reference { get; set; }
        //Note
        [Required]
        public string Note { get; set; }
        //Financial 
        [Required]
        public double AmoutExVat { get; set; }
        [Required]
        public double Vat { get; set; }
        [Required]
        public double Amount { get; set; }
        //.PDF Link 
        [Required]
        public string Document_uri { get; set; }
    }
}