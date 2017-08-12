namespace tincApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesportoChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Desporto", "Descricao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Desporto", "Descricao", c => c.String());
        }
    }
}
