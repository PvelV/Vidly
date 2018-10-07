namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bf49078c-9357-4fca-8733-a5d7b8d8c12a', N'pvel.vaverka@centrum.cz', 0, N'AMg4XObdO3+J1IKRWdGIe+5l5VI+mT8MtRZF4aHj14nbH3/SVp7Gj9U/OJ5lNfyq1g==', N'563891eb-637c-4e42-88fd-34e3f31979c2', NULL, 0, 0, NULL, 1, 0, N'pvel.vaverka@centrum.cz')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc9201ec-8c4b-485c-9454-64e00d943ad6', N'admin@vidly.com', 0, N'ANE8Ty8zZXs6Fat+3hJUGHj7+mRpc+NTYtvgrPdh5k4feXUmqTnJXm/IIEqOfBLl2Q==', N'6568c6b3-bee9-45af-8634-aac1a9930a7a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e102212f-361c-46a8-a95d-bc642c6ac81a', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dc9201ec-8c4b-485c-9454-64e00d943ad6', N'e102212f-361c-46a8-a95d-bc642c6ac81a')
");
        }

        public override void Down()
        {
        }
    }
}
