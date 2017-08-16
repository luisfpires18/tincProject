namespace tincApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetBack : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Error");
        }
        
        public override void Down()
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
            
        }
    }
}
