namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'003edf25-fdbc-4b2c-9c12-0a1ca6d83d19', N'admin@vidly.com', 0, N'AGP55067sSdDmp7Uv9ZSXza+9PUerkvy/EmLePRX+Yz7t+FPrKZX5jXLu5deNmqDnA==', N'abc24ef5-3632-4fb9-b4af-39cf46b7d686', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3a1ec175-b93a-447e-bd59-e44a9bb6ee16', N'guest@vidly.com', 0, N'AGFDbGHkyo8VB9LXTfXGahRWSiMbsOasKhA3NSFWbkEXYCrJMW/u7EMG2dIwdz21rQ==', N'49bbd9d0-42bf-4f5d-ac59-44c22d9907ea', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f675f45c-3ef3-4c47-a472-d3fc3337f196', N'CanManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'003edf25-fdbc-4b2c-9c12-0a1ca6d83d19', N'f675f45c-3ef3-4c47-a472-d3fc3337f196')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
