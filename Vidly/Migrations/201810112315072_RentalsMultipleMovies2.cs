namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalsMultipleMovies2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RentalMovies", name: "MovieIds", newName: "Rental_Id");
            RenameIndex(table: "dbo.RentalMovies", name: "IX_MovieIds", newName: "IX_Rental_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RentalMovies", name: "IX_Rental_Id", newName: "IX_MovieIds");
            RenameColumn(table: "dbo.RentalMovies", name: "Rental_Id", newName: "MovieIds");
        }
    }
}
