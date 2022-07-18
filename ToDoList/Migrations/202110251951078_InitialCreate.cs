namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        User_id = c.Int(nullable: false),
                        Status_id = c.Int(nullable: false),
                        DeadLine = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .ForeignKey("dbo.Status", t => t.Status_id)
                .Index(t => t.User_id)
                .Index(t => t.Status_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Mail = c.String(nullable: false),
                        Role = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Status_id", "dbo.Status");
            DropForeignKey("dbo.Tasks", "User_id", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "Status_id" });
            DropIndex("dbo.Tasks", new[] { "User_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Status");
        }
    }
}
