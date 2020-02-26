namespace MVC5Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Departments Values ('Test',1)");
            Sql("Insert into Departments Values ('Test1',1)");
            Sql("Insert into Departments Values ('Test2',1)");
            Sql("Insert into Departments Values ('Test3',1)");

        }
        
        public override void Down()
        {
        }
    }
}
