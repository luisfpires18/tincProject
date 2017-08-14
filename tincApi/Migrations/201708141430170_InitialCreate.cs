namespace tincApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Genero = c.String(),
                        TipoAtleta = c.String(),
                        Vencedores = c.Int(nullable: false),
                        IdadeMin = c.Int(nullable: false),
                        IdadeMax = c.Int(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                        Prova_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prova", t => t.Prova_ID)
                .Index(t => t.Prova_ID);
            
            CreateTable(
                "dbo.Inscricao",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tamanho = c.Int(nullable: false),
                        DataInscricao = c.DateTime(nullable: false),
                        RegistadoPor = c.String(),
                        Estado = c.Boolean(nullable: false),
                        Notas = c.String(),
                        Categoria_ID = c.Int(),
                        Pessoa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categoria", t => t.Categoria_ID)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_ID)
                .Index(t => t.Categoria_ID)
                .Index(t => t.Pessoa_ID);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Contacto = c.String(),
                        Genero = c.String(),
                        Cidade = c.String(),
                        Nacionalidade = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Foto = c.String(),
                        Equipa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Equipa", t => t.Equipa_ID)
                .Index(t => t.Equipa_ID);
            
            CreateTable(
                "dbo.Equipa",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Prova",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Distancia = c.Single(nullable: false),
                        Preco = c.Single(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                        Evento_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Evento", t => t.Evento_ID)
                .Index(t => t.Evento_ID);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Local = c.String(),
                        Website = c.String(),
                        DataEvento = c.DateTime(nullable: false),
                        Foto = c.String(),
                        Ficheiro = c.String(),
                        Inscricoes = c.Boolean(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                        Desporto_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Desporto", t => t.Desporto_ID)
                .Index(t => t.Desporto_ID);
            
            CreateTable(
                "dbo.Desporto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Extra",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Preco = c.Single(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                        Evento_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Evento", t => t.Evento_ID)
                .Index(t => t.Evento_ID);
            
            CreateTable(
                "dbo.Resultado",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                        Categoria_ID = c.Int(),
                        Prova_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categoria", t => t.Categoria_ID)
                .ForeignKey("dbo.Prova", t => t.Prova_ID)
                .Index(t => t.Categoria_ID)
                .Index(t => t.Prova_ID);
            
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
            DropForeignKey("dbo.Resultado", "Prova_ID", "dbo.Prova");
            DropForeignKey("dbo.Resultado", "Categoria_ID", "dbo.Categoria");
            DropForeignKey("dbo.Prova", "Evento_ID", "dbo.Evento");
            DropForeignKey("dbo.Extra", "Evento_ID", "dbo.Evento");
            DropForeignKey("dbo.Evento", "Desporto_ID", "dbo.Desporto");
            DropForeignKey("dbo.Categoria", "Prova_ID", "dbo.Prova");
            DropForeignKey("dbo.Inscricao", "Pessoa_ID", "dbo.Pessoa");
            DropForeignKey("dbo.Pessoa", "Equipa_ID", "dbo.Equipa");
            DropForeignKey("dbo.Inscricao", "Categoria_ID", "dbo.Categoria");
            DropIndex("dbo.Resultado", new[] { "Prova_ID" });
            DropIndex("dbo.Resultado", new[] { "Categoria_ID" });
            DropIndex("dbo.Extra", new[] { "Evento_ID" });
            DropIndex("dbo.Evento", new[] { "Desporto_ID" });
            DropIndex("dbo.Prova", new[] { "Evento_ID" });
            DropIndex("dbo.Pessoa", new[] { "Equipa_ID" });
            DropIndex("dbo.Inscricao", new[] { "Pessoa_ID" });
            DropIndex("dbo.Inscricao", new[] { "Categoria_ID" });
            DropIndex("dbo.Categoria", new[] { "Prova_ID" });
            DropTable("dbo.Pedido");
            DropTable("dbo.Resultado");
            DropTable("dbo.Extra");
            DropTable("dbo.Desporto");
            DropTable("dbo.Evento");
            DropTable("dbo.Prova");
            DropTable("dbo.Equipa");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Inscricao");
            DropTable("dbo.Categoria");
        }
    }
}
