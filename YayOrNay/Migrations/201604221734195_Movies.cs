namespace YayOrNay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "FileType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "FileType");
        }
    }
}
