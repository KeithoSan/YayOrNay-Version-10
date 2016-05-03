namespace YayOrNay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            DropColumn("dbo.Movies", "FileType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "FileType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Files", "MovieId", "dbo.Movies");
            DropIndex("dbo.Files", new[] { "MovieId" });
            DropTable("dbo.Files");
        }
    }
}
