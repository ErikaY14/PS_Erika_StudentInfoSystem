namespace StudentInfoSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarksAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        studentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Students", t => t.studentId, cascadeDelete: true)
                .Index(t => t.studentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "studentId", "dbo.Students");
            DropIndex("dbo.Marks", new[] { "studentId" });
            DropTable("dbo.Marks");
        }
    }
}
