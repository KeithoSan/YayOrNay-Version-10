namespace YayOrNay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    
    public partial class Initial : DbMigration
	    {
 	        public override void Up()
 	        {
 	            CreateTable(
 	                "dbo.Movies",
 	                c => new
 	                    {
 	                        Id = c.Int(nullable: false, identity: true),
 	                        Title = c.String(),
 	                        Genre = c.String(),
 	                        Certificate = c.String(),
                            ReleaseDate = c.DateTime(),
 	                    })
 	                .PrimaryKey(t => t.Id);
 	            
 	            CreateTable(
 	                "dbo.MovieReviews",
 	                c => new
 	                    {
 	                        Id = c.Int(nullable: false, identity: true),
 	                        Rating = c.Int(nullable: false),
 	                        Comment = c.String(),
 	                        MovieId = c.Int(nullable: false),
 	                    })
 	                .PrimaryKey(t => t.Id)
 	                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
 	                .Index(t => t.MovieId);            
 	            
 	        }
 	        
 	        public override void Down()
 	        {
 	            DropIndex("dbo.MovieReviews", new[] { "MovieId" });
 	            DropForeignKey("dbo.MovieReviews", "MovieId", "dbo.Movies");
 	            DropTable("dbo.MovieReviews");
 	            DropTable("dbo.Movies");
 	        }
 	   }
 } 
