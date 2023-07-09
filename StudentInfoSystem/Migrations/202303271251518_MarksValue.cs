namespace StudentInfoSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarksValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marks", "MarkValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marks", "MarkValue");
        }
    }
}
