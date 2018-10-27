namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMigration2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('Avengers', 1, '2014-5-2', '2014-6-8', 8,8)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('Maze Runner', 2, '2018-7-12', '2018-8-13', 20,20)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('DoctorStrange', 3, '1998-6-6', '1999-1-5', 5,5)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('Titanic', 4, '2002-2-18', '2010-7-15', 2,2)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('Mission Impossible', 1, '2005-11-28', '2008-9-11', 1,1)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('Star Wars', 5, '1985-8-2', '2004-11-9', 35,35)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable) VALUES ('Harry Potter', 2, '1990-1-20', '2006-2-3', 20,20)");


            Sql(@"INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [DrivingLicense], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'bf49078c-9357-4fca-8733-a5d7b8d8c12a', N'pvel.vaverka@centrum.cz', '85666', 0, N'AMg4XObdO3+J1IKRWdGIe+5l5VI+mT8MtRZF4aHj14nbH3/SVp7Gj9U/OJ5lNfyq1g==', N'563891eb-637c-4e42-88fd-34e3f31979c2', NULL, 0, 0, NULL, 1, 0, N'pvel.vaverka@centrum.cz')");
            Sql(@"INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [DrivingLicense], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'dc9201ec-8c4b-485c-9454-64e00d943ad6', N'admin@vidly.com', '52223858', 0, N'ANE8Ty8zZXs6Fat+3hJUGHj7+mRpc+NTYtvgrPdh5k4feXUmqTnJXm/IIEqOfBLl2Q==', N'6568c6b3-bee9-45af-8634-aac1a9930a7a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')");
            Sql(@"INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'e102212f-361c-46a8-a95d-bc642c6ac81a', N'CanManageMovies')");
            Sql(@"INSERT INTO[dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES(N'dc9201ec-8c4b-485c-9454-64e00d943ad6', N'e102212f-361c-46a8-a95d-bc642c6ac81a')");
        }

        public override void Down()
        {
        }
    }
}
