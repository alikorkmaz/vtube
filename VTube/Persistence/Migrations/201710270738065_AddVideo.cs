namespace VTube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 64),
                        Description = c.String(maxLength: 1024),
                        Path = c.String(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        UpdatedDateTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Videos", new[] { "UserId" });
            DropTable("dbo.Videos");
        }
    }
}
