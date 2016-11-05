namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1021 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPostTag",
                c => new
                    {
                        BlogPostTagId = c.Int(nullable: false, identity: true),
                        BlogPostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogPostTagId)
                .ForeignKey("dbo.BlogPost", t => t.BlogPostId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.BlogPostId)
                .Index(t => t.TagId);
            
            AddColumn("dbo.Tag", "BlogPost_BlogPostId", c => c.Int());
            CreateIndex("dbo.BlogPost", "CategoryId");
            CreateIndex("dbo.Tag", "BlogPost_BlogPostId");
            AddForeignKey("dbo.BlogPost", "CategoryId", "dbo.Category", "CategoryId");
            AddForeignKey("dbo.Tag", "BlogPost_BlogPostId", "dbo.BlogPost", "BlogPostId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPostTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.BlogPostTag", "BlogPostId", "dbo.BlogPost");
            DropForeignKey("dbo.Tag", "BlogPost_BlogPostId", "dbo.BlogPost");
            DropForeignKey("dbo.BlogPost", "CategoryId", "dbo.Category");
            DropIndex("dbo.Tag", new[] { "BlogPost_BlogPostId" });
            DropIndex("dbo.BlogPost", new[] { "CategoryId" });
            DropIndex("dbo.BlogPostTag", new[] { "TagId" });
            DropIndex("dbo.BlogPostTag", new[] { "BlogPostId" });
            DropColumn("dbo.Tag", "BlogPost_BlogPostId");
            DropTable("dbo.BlogPostTag");
        }
    }
}
