namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _101 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Post", newName: "BlogPost");
            RenameColumn(table: "dbo.Tag", name: "Post_Id", newName: "BlogPost_Id");
            RenameIndex(table: "dbo.Tag", name: "IX_Post_Id", newName: "IX_BlogPost_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tag", name: "IX_BlogPost_Id", newName: "IX_Post_Id");
            RenameColumn(table: "dbo.Tag", name: "BlogPost_Id", newName: "Post_Id");
            RenameTable(name: "dbo.BlogPost", newName: "Post");
        }
    }
}
