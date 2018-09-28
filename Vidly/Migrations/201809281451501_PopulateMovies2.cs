namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Maze Runner', 2, '2018-7-12', '2018-8-13', 20)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('DoctorStrange', 3, '1998-6-6', '1999-1-5', 5)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Titanic', 4, '2002-2-18', '2010-7-15', 2)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Mission Impossible', 1, '2005-11-28', '2008-9-11', 1)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Star Wars', 5, '1985-8-2', '2004-11-9', 0)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Harry Potter', 2, '1990-1-20', '2006-2-3', 16)");
        }
        
        public override void Down()
        {
        }
    }
}
