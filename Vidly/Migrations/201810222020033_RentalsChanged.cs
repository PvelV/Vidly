namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalsChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RentalMovies", "Rental_Id", "dbo.Rentals");
            DropForeignKey("dbo.RentalMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropIndex("dbo.RentalMovies", new[] { "Rental_Id" });
            DropIndex("dbo.RentalMovies", new[] { "Movie_Id" });
            RenameColumn(table: "dbo.Rentals", name: "CustomerId", newName: "Customer_Id");
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Int());
            AlterColumn("dbo.Rentals", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Movie_Id");
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id");
            DropTable("dbo.RentalMovies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RentalMovies",
                c => new
                    {
                        Rental_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rental_Id, t.Movie_Id });
            
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            AlterColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Rentals", "Movie_Id");
            RenameColumn(table: "dbo.Rentals", name: "Customer_Id", newName: "CustomerId");
            CreateIndex("dbo.RentalMovies", "Movie_Id");
            CreateIndex("dbo.RentalMovies", "Rental_Id");
            CreateIndex("dbo.Rentals", "CustomerId");
            AddForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RentalMovies", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RentalMovies", "Rental_Id", "dbo.Rentals", "Id", cascadeDelete: true);
        }
    }
}
