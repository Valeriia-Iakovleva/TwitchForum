namespace TwitchForum.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDiscussionUserId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Discussions", new[] { "User_Id" });
            DropColumn("dbo.Discussions", "UserId");
            RenameColumn(table: "dbo.Discussions", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Discussions", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Discussions", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Discussions", new[] { "UserId" });
            AlterColumn("dbo.Discussions", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Discussions", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Discussions", "UserId", c => c.Int());
            CreateIndex("dbo.Discussions", "User_Id");
        }
    }
}
