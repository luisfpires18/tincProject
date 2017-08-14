namespace tincApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Apelido = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Gestao",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        PessoaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.PessoaID })
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.PessoaID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.PessoaID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.RoleID })
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleID", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserID", "dbo.User");
            DropForeignKey("dbo.Gestao", "PessoaID", "dbo.Pessoa");
            DropForeignKey("dbo.Gestao", "UserID", "dbo.User");
            DropIndex("dbo.UserRole", new[] { "RoleID" });
            DropIndex("dbo.UserRole", new[] { "UserID" });
            DropIndex("dbo.Gestao", new[] { "PessoaID" });
            DropIndex("dbo.Gestao", new[] { "UserID" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Gestao");
            DropTable("dbo.Role");
            DropTable("dbo.User");
        }
    }
}
