namespace tincApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TipoPedido = c.String(),
                        Assunto = c.String(),
                        DataPedido = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pedido");
        }
    }
}
