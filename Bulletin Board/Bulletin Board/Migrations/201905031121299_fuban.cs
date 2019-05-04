namespace Bulletin_Board.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuban : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessageModels", "fuban", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MessageModels", "fuban");
        }
    }
}
