namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v102 : DbMigration
    {
        public override void Up()
        {
            SqlFile("Migrations/Sql/v1.0.2-Up.sql");

            DropForeignKey("dbo.Tag", "BlogPost_Id", "dbo.BlogPost");
            DropForeignKey("dbo.Category", "Tag_Id", "dbo.Tag");
            RenameColumn(table: "dbo.Tag", name: "BlogPost_Id", newName: "BlogPost_BlogPostId");
            RenameColumn(table: "dbo.Category", name: "Tag_Id", newName: "Tag_TagId");
            RenameIndex(table: "dbo.Category", name: "IX_Tag_Id", newName: "IX_Tag_TagId");
            RenameIndex(table: "dbo.Tag", name: "IX_BlogPost_Id", newName: "IX_BlogPost_BlogPostId");
            DropPrimaryKey("dbo.Category");
            DropPrimaryKey("dbo.BlogPost");
            DropPrimaryKey("dbo.Tag");
            AddColumn("dbo.Category", "CategoryId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BlogPost", "BlogPostId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BlogPost", "CategoryId", c => c.Int());
            AddColumn("dbo.Tag", "TagId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Category", "CategoryId");
            AddPrimaryKey("dbo.BlogPost", "BlogPostId");
            AddPrimaryKey("dbo.Tag", "TagId");
            CreateIndex("dbo.BlogPost", "CategoryId");
            AddForeignKey("dbo.BlogPost", "CategoryId", "dbo.Category", "CategoryId");
            AddForeignKey("dbo.Tag", "BlogPost_BlogPostId", "dbo.BlogPost", "BlogPostId");
            AddForeignKey("dbo.Category", "Tag_TagId", "dbo.Tag", "TagId");
            DropColumn("dbo.Category", "Id");
            DropColumn("dbo.BlogPost", "Id");
            DropColumn("dbo.Tag", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tag", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BlogPost", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Category", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Category", "Tag_TagId", "dbo.Tag");
            DropForeignKey("dbo.Tag", "BlogPost_BlogPostId", "dbo.BlogPost");
            DropForeignKey("dbo.BlogPost", "CategoryId", "dbo.Category");
            DropIndex("dbo.BlogPost", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Tag");
            DropPrimaryKey("dbo.BlogPost");
            DropPrimaryKey("dbo.Category");
            DropColumn("dbo.Tag", "TagId");
            DropColumn("dbo.BlogPost", "CategoryId");
            DropColumn("dbo.BlogPost", "BlogPostId");
            DropColumn("dbo.Category", "CategoryId");
            AddPrimaryKey("dbo.Tag", "Id");
            AddPrimaryKey("dbo.BlogPost", "Id");
            AddPrimaryKey("dbo.Category", "Id");
            RenameIndex(table: "dbo.Tag", name: "IX_BlogPost_BlogPostId", newName: "IX_BlogPost_Id");
            RenameIndex(table: "dbo.Category", name: "IX_Tag_TagId", newName: "IX_Tag_Id");
            RenameColumn(table: "dbo.Category", name: "Tag_TagId", newName: "Tag_Id");
            RenameColumn(table: "dbo.Tag", name: "BlogPost_BlogPostId", newName: "BlogPost_Id");
            AddForeignKey("dbo.Category", "Tag_Id", "dbo.Tag", "Id");
            AddForeignKey("dbo.Tag", "BlogPost_Id", "dbo.BlogPost", "Id");
        }
    }
}
