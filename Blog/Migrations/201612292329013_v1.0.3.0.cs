namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1030 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogPost", "CategoryId", "dbo.Category");
            DropColumn("dbo.BlogPost", "CategoryId");
            DropTable("dbo.Category");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BlogPost_BlogPostId = c.Int(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.BlogPostTag",
                c => new
                    {
                        BlogPostTagId = c.Int(nullable: false, identity: true),
                        BlogPostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogPostTagId);
            
            AddColumn("dbo.BlogPost", "CategoryId", c => c.Int());
            CreateIndex("dbo.Tag", "BlogPost_BlogPostId");
            CreateIndex("dbo.BlogPost", "CategoryId");
            CreateIndex("dbo.BlogPostTag", "TagId");
            CreateIndex("dbo.BlogPostTag", "BlogPostId");
            AddForeignKey("dbo.BlogPostTag", "TagId", "dbo.Tag", "TagId", cascadeDelete: true);
            AddForeignKey("dbo.BlogPostTag", "BlogPostId", "dbo.BlogPost", "BlogPostId", cascadeDelete: true);
            AddForeignKey("dbo.Tag", "BlogPost_BlogPostId", "dbo.BlogPost", "BlogPostId");
            AddForeignKey("dbo.BlogPost", "CategoryId", "dbo.Category", "CategoryId");
        }
    }
}
