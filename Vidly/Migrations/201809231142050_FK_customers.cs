namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK_customers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Movies", new[] { "Customer_Id" });
            CreateTable(
                "dbo.MovieCustomers",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Customer_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Customer_Id);
            
            DropColumn("dbo.Movies", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Customer_Id", c => c.Int());
            DropForeignKey("dbo.MovieCustomers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.MovieCustomers", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MovieCustomers", new[] { "Customer_Id" });
            DropIndex("dbo.MovieCustomers", new[] { "Movie_Id" });
            DropTable("dbo.MovieCustomers");
            CreateIndex("dbo.Movies", "Customer_Id");
            AddForeignKey("dbo.Movies", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
