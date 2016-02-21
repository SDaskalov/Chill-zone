namespace ChillZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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

            this.AlterColumn("dbo.PostCategories", "Name", c => c.String(nullable: false, maxLength: 100));
            this.CreateIndex("dbo.PostCategories", "Name", unique: true);
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Points", "PostId", "dbo.Posts");
            this.DropForeignKey("dbo.Points", "AuthorId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            this.DropForeignKey("dbo.Comments", "AuthorId", "dbo.AspNetUsers");
            this.DropIndex("dbo.Points", new[] { "IsDeleted" });
            this.DropIndex("dbo.Points", new[] { "PostId" });
            this.DropIndex("dbo.Points", new[] { "AuthorId" });
            this.DropIndex("dbo.Comments", new[] { "IsDeleted" });
            this.DropIndex("dbo.Comments", new[] { "PostId" });
            this.DropIndex("dbo.Comments", new[] { "AuthorId" });
            this.DropIndex("dbo.PostCategories", new[] { "Name" });
            this.AlterColumn("dbo.PostCategories", "Name", c => c.String());
            this.DropTable("dbo.Points");
            this.DropTable("dbo.Comments");
        }
    }
}
