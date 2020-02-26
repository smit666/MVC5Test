namespace MVC5Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentSeed : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Students Values ('Smit',27,'sm@sm.com','4654646',1,1)");
            Sql("Insert Into Students Values ('Santosh',30,'ss@sm.com','5454',2,1)");
            Sql("Insert Into Students Values ('Sanket',26,'san@sm.com','653343',3,1)");


        }

        public override void Down()
        {
        }
    }
}
