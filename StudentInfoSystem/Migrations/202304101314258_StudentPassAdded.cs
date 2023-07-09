namespace StudentInfoSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentPassAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Password");
        }
    }
}
