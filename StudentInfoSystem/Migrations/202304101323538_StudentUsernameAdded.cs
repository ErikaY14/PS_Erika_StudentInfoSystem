namespace StudentInfoSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentUsernameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Username");
        }
    }
}
