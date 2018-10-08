namespace MvcDocuments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentsDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Company_name = c.String(),
                        Address = c.String(),
                        Postal_Code = c.String(),
                        City = c.String(),
                        StateId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Website_Uri = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        FunctionId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                        Surname = c.String(),
                        Last_name = c.String(),
                        Email_address = c.String(),
                        Phone = c.String(),
                        Cellphone = c.String(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Functions", t => t.FunctionId, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.FunctionId)
                .Index(t => t.TitleId);
            
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        FunctionId = c.Int(nullable: false, identity: true),
                        Function_name = c.String(),
                    })
                .PrimaryKey(t => t.FunctionId);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleId = c.Int(nullable: false, identity: true),
                        Title_name = c.String(),
                    })
                .PrimaryKey(t => t.TitleId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Country_name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        Document_date = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        Mail_categoryID = c.Int(nullable: false),
                        Costs_groupId = c.Int(nullable: false),
                        Payment_statusId = c.Int(nullable: false),
                        Reference = c.String(),
                        Note = c.String(),
                        AmoutExVat = c.Double(nullable: false),
                        Vat = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        Document_uri = c.String(),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Costs_group", t => t.Costs_groupId, cascadeDelete: true)
                .ForeignKey("dbo.Mail_category", t => t.Mail_categoryID, cascadeDelete: true)
                .ForeignKey("dbo.Payment_status", t => t.Payment_statusId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.Mail_categoryID)
                .Index(t => t.Costs_groupId)
                .Index(t => t.Payment_statusId);
            
            CreateTable(
                "dbo.Costs_group",
                c => new
                    {
                        Costs_groupId = c.Int(nullable: false, identity: true),
                        Cost_group_name = c.String(),
                    })
                .PrimaryKey(t => t.Costs_groupId);
            
            CreateTable(
                "dbo.Mail_category",
                c => new
                    {
                        Mail_categoryId = c.Int(nullable: false, identity: true),
                        Mail_category_name = c.String(),
                    })
                .PrimaryKey(t => t.Mail_categoryId);
            
            CreateTable(
                "dbo.Payment_status",
                c => new
                    {
                        Payment_statusId = c.Int(nullable: false, identity: true),
                        Payment_status_name = c.String(),
                    })
                .PrimaryKey(t => t.Payment_statusId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        State_name = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "StateId", "dbo.States");
            DropForeignKey("dbo.Documents", "Payment_statusId", "dbo.Payment_status");
            DropForeignKey("dbo.Documents", "Mail_categoryID", "dbo.Mail_category");
            DropForeignKey("dbo.Documents", "Costs_groupId", "dbo.Costs_group");
            DropForeignKey("dbo.Documents", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Contacts", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Contacts", "FunctionId", "dbo.Functions");
            DropForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Documents", new[] { "Payment_statusId" });
            DropIndex("dbo.Documents", new[] { "Costs_groupId" });
            DropIndex("dbo.Documents", new[] { "Mail_categoryID" });
            DropIndex("dbo.Documents", new[] { "CompanyId" });
            DropIndex("dbo.Contacts", new[] { "TitleId" });
            DropIndex("dbo.Contacts", new[] { "FunctionId" });
            DropIndex("dbo.Contacts", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "CountryId" });
            DropIndex("dbo.Companies", new[] { "StateId" });
            DropTable("dbo.States");
            DropTable("dbo.Payment_status");
            DropTable("dbo.Mail_category");
            DropTable("dbo.Costs_group");
            DropTable("dbo.Documents");
            DropTable("dbo.Countries");
            DropTable("dbo.Titles");
            DropTable("dbo.Functions");
            DropTable("dbo.Contacts");
            DropTable("dbo.Companies");
        }
    }
}
