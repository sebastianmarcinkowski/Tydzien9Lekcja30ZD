namespace MailClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MailEntities",
                c => new
                    {
                        MailId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        SenderName = c.String(nullable: false),
                        To = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        AttachmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MailId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MailEntities", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.MailEntities", new[] { "UserId" });
            DropTable("dbo.MailEntities");
        }
    }
}
