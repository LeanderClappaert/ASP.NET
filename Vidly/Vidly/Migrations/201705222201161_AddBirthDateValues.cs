namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateValues : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = CAST('1991-09-21' AS DATETIME) WHERE id = 1");
            Sql("UPDATE Customers SET Birthdate = NULL WHERE id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
