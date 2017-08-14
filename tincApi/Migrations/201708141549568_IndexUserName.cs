namespace tincApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexUserName : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.User", new[] { "Username" });
            CreateIndex("dbo.User", "Username");
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "Username" });
            CreateIndex("dbo.User", "Username", unique: true);
        }
    }
}
