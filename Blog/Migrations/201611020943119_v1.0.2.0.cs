namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Tag_Id", "dbo.Tag");
            DropForeignKey("dbo.Tag", "BlogPost_Id", "dbo.BlogPost");

            DropIndex("dbo.Category", new[] { "Tag_Id" });
            DropIndex("dbo.Tag", new[] { "BlogPost_Id" });
            
            DropPrimaryKey("dbo.Category");
            DropPrimaryKey("dbo.BlogPost");
            DropPrimaryKey("dbo.Tag");

            DropColumn("dbo.Category", "Id");
            DropColumn("dbo.Category", "Tag_Id");
            DropColumn("dbo.BlogPost", "Id");
            DropColumn("dbo.Tag", "Id");

            AddColumn("dbo.Category", "CategoryId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BlogPost", "BlogPostId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BlogPost", "CategoryId", c => c.Int());
            AddColumn("dbo.Tag", "TagId", c => c.Int(nullable: false, identity: true));
           
            AddPrimaryKey("dbo.Category", "CategoryId");
            AddPrimaryKey("dbo.BlogPost", "BlogPostId");
            AddPrimaryKey("dbo.Tag", "TagId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tag", "BlogPost_Id", c => c.Int());
            AddColumn("dbo.Tag", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BlogPost", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Category", "Tag_Id", c => c.Int());
            AddColumn("dbo.Category", "Id", c => c.Int(nullable: false, identity: true));
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
            CreateIndex("dbo.Tag", "BlogPost_Id");
            CreateIndex("dbo.Category", "Tag_Id");
            AddForeignKey("dbo.Tag", "BlogPost_Id", "dbo.BlogPost", "Id");
            AddForeignKey("dbo.Category", "Tag_Id", "dbo.Tag", "Id");
        }
    }
}
