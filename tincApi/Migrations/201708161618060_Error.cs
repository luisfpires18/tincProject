namespace tincApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Error : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.User", "HashedPassword", c => c.String());
            AddColumn("dbo.User", "Salt", c => c.String());
            AddColumn("dbo.User", "IsLocked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "IsLocked");
            DropColumn("dbo.User", "Salt");
            DropColumn("dbo.User", "HashedPassword");
            DropTable("dbo.Error");
        }
    }
}
