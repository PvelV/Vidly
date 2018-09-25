namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer_IsSubscribed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribed");
        }
    }
}
