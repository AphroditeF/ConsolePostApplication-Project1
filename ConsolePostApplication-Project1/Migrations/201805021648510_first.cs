namespace ConsolePostApplication_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(maxLength: 250),
                        Date = c.DateTime(nullable: false),
                        ConditionEdited = c.Boolean(nullable: false),
                        SenderUsername = c.String(nullable: false, maxLength: 128),
                        ReceiverName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ReceiverName)
                .ForeignKey("dbo.Users", t => t.SenderUsername)
                .Index(t => t.SenderUsername)
                .Index(t => t.ReceiverName);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Role = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "SenderUsername", "dbo.Users");
            DropForeignKey("dbo.Posts", "ReceiverName", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "ReceiverName" });
            DropIndex("dbo.Posts", new[] { "SenderUsername" });
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
        }
    }
}
