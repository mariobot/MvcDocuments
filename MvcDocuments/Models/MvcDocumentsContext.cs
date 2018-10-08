using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcDocuments.Models
{
    public class MvcDocumentsContext : DbContext
    {
        public MvcDocumentsContext() : base("name=DefaultConnection") { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Costs_group> Costs_groups { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Mail_category> Mail_categories { get; set; }
        public DbSet<Payment_status> Payment_statusses { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}