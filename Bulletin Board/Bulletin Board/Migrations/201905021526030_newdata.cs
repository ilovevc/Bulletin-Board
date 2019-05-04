namespace Bulletin_Board.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessageModels", "screenwidth", c => c.Int(nullable: false));
            AddColumn("dbo.MessageModels", "screenheight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MessageModels", "screenheight");
            DropColumn("dbo.MessageModels", "screenwidth");
        }
    }
}
