namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
