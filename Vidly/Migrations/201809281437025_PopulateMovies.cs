namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Avengers', 1, '2014-5-2', '2014-6-8', 8)");
         
        }
        
        public override void Down()
        {
        }
    }
}
