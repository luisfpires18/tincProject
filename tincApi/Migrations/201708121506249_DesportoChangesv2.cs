namespace tincApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesportoChangesv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Desporto", "Descricao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Desporto", "Descricao");
        }
    }
}
