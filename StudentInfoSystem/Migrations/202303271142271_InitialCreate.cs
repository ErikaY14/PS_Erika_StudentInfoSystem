namespace StudentInfoSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        LastName = c.String(),
                        Faculty = c.String(),
                        Major = c.String(),
                        Degree = c.String(),
                        Status = c.String(),
                        FacultyNumber = c.Int(nullable: false),
                        Course = c.Int(nullable: false),
                        Stream = c.Int(nullable: false),
                        Group = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        facultyNumber = c.Int(nullable: false),
                        role = c.Int(nullable: false),
                        created = c.DateTime(nullable: false),
                        activeUntil = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Students");
        }
    }
}
