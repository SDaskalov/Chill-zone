namespace ChillZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        SharedUrl = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        IsVideo = c.Boolean(nullable: false),
                        AuthorId = c.String(nullable: false, maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.PostCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            this.CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            this.CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            this.CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            this.CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                        PostId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PostId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Points",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                        PostId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PostId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            this.DropForeignKey("dbo.Points", "PostId", "dbo.Posts");
            this.DropForeignKey("dbo.Points", "AuthorId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            this.DropForeignKey("dbo.Comments", "AuthorId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Posts", "CategoryId", "dbo.PostCategories");
            this.DropForeignKey("dbo.Posts", "AuthorId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            this.DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            this.DropIndex("dbo.Points", new[] { "IsDeleted" });
            this.DropIndex("dbo.Points", new[] { "PostId" });
            this.DropIndex("dbo.Points", new[] { "AuthorId" });
            this.DropIndex("dbo.Comments", new[] { "IsDeleted" });
            this.DropIndex("dbo.Comments", new[] { "PostId" });
            this.DropIndex("dbo.Comments", new[] { "AuthorId" });
            this.DropIndex("dbo.PostCategories", new[] { "IsDeleted" });
            this.DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            this.DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUsers", "UserNameIndex");
            this.DropIndex("dbo.Posts", new[] { "IsDeleted" });
            this.DropIndex("dbo.Posts", new[] { "AuthorId" });
            this.DropIndex("dbo.Posts", new[] { "CategoryId" });
            this.DropTable("dbo.AspNetRoles");
            this.DropTable("dbo.Points");
            this.DropTable("dbo.Comments");
            this.DropTable("dbo.PostCategories");
            this.DropTable("dbo.AspNetUserRoles");
            this.DropTable("dbo.AspNetUserLogins");
            this.DropTable("dbo.AspNetUserClaims");
            this.DropTable("dbo.AspNetUsers");
            this.DropTable("dbo.Posts");
        }
    }
}
