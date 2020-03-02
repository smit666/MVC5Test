namespace MVC5Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentModelUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Age", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "MobileNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "MobileNo", c => c.String());
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "Age", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
