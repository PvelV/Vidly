namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalsMultipleMovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "MovieId", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "MovieId" });
            CreateTable(
                "dbo.RentalMovies",
                c => new
                    {
                        Rental_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rental_Id, t.Movie_Id })
                .ForeignKey("dbo.Rentals", t => t.Rental_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Rental_Id)
                .Index(t => t.Movie_Id);
            
            DropColumn("dbo.Rentals", "MovieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "MovieId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RentalMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.RentalMovies", "Rental_Id", "dbo.Rentals");
            DropIndex("dbo.RentalMovies", new[] { "Movie_Id" });
            DropIndex("dbo.RentalMovies", new[] { "Rental_Id" });
            DropTable("dbo.RentalMovies");
            CreateIndex("dbo.Rentals", "MovieId");
            AddForeignKey("dbo.Rentals", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
