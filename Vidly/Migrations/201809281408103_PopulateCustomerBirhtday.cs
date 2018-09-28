namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerBirhtday : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '1980.5.2' WHERE Id = 1");

        }

        public override void Down()
        {
        }
    }
}
