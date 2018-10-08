namespace MvcDocuments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDocument : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "Reference", c => c.String(nullable: false));
            AlterColumn("dbo.Documents", "Note", c => c.String(nullable: false));
            AlterColumn("dbo.Documents", "Document_uri", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "Document_uri", c => c.String());
            AlterColumn("dbo.Documents", "Note", c => c.String());
            AlterColumn("dbo.Documents", "Reference", c => c.String());
        }
    }
}
