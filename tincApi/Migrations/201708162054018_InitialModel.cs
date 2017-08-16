namespace tincApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Genero = c.Int(nullable: false),
                        TipoAtleta = c.Int(nullable: false),
                        Vencedores = c.Int(nullable: false),
                        IdadeMin = c.Int(nullable: false),
                        IdadeMax = c.Int(nullable: false),
                        ProvaID = c.Int(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prova", t => t.ProvaID, cascadeDelete: true)
                .Index(t => t.ProvaID);
            
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
                        CategoriaID = c.Int(nullable: false),
                        PessoaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.PessoaID, cascadeDelete: true)
                .Index(t => t.CategoriaID)
                .Index(t => t.PessoaID);
            
            CreateTable(
                "dbo.Extra",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Preco = c.Single(nullable: false),
                        EventoID = c.Int(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Evento", t => t.EventoID, cascadeDelete: true)
                .Index(t => t.EventoID);
            
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
                        DesportoID = c.Int(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Desporto", t => t.DesportoID, cascadeDelete: true)
                .Index(t => t.DesportoID);
            
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
                "dbo.Prova",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Distancia = c.Single(nullable: false),
                        EventoID = c.Int(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Responsavel = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Evento", t => t.EventoID, cascadeDelete: true)
                .Index(t => t.EventoID);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Contacto = c.String(),
                        Genero = c.Int(nullable: false),
                        Cidade = c.String(),
                        Nacionalidade = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Foto = c.String(),
                        EquipaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Equipa", t => t.EquipaID, cascadeDelete: true)
                .Index(t => t.EquipaID);
            
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
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Apelido = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        HashedPassword = c.String(),
                        Salt = c.String(),
                        IsLocked = c.Boolean(nullable: false),
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
                "dbo.Resultado",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PessoaID = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.PessoaID, cascadeDelete: true)
                .Index(t => t.PessoaID)
                .Index(t => t.CategoriaID);
            
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
            
            CreateTable(
                "dbo.InscricaoExtra",
                c => new
                    {
                        ExtraID = c.Int(nullable: false),
                        InscricaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExtraID, t.InscricaoID })
                .ForeignKey("dbo.Extra", t => t.ExtraID, cascadeDelete: false)
                .ForeignKey("dbo.Inscricao", t => t.InscricaoID, cascadeDelete: false)
                .Index(t => t.ExtraID)
                .Index(t => t.InscricaoID);
            
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
            DropForeignKey("dbo.Resultado", "PessoaID", "dbo.Pessoa");
            DropForeignKey("dbo.Resultado", "CategoriaID", "dbo.Categoria");
            DropForeignKey("dbo.UserRole", "RoleID", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserID", "dbo.User");
            DropForeignKey("dbo.Gestao", "PessoaID", "dbo.Pessoa");
            DropForeignKey("dbo.Gestao", "UserID", "dbo.User");
            DropForeignKey("dbo.Inscricao", "PessoaID", "dbo.Pessoa");
            DropForeignKey("dbo.Pessoa", "EquipaID", "dbo.Equipa");
            DropForeignKey("dbo.InscricaoExtra", "InscricaoID", "dbo.Inscricao");
            DropForeignKey("dbo.InscricaoExtra", "ExtraID", "dbo.Extra");
            DropForeignKey("dbo.Prova", "EventoID", "dbo.Evento");
            DropForeignKey("dbo.Categoria", "ProvaID", "dbo.Prova");
            DropForeignKey("dbo.Extra", "EventoID", "dbo.Evento");
            DropForeignKey("dbo.Evento", "DesportoID", "dbo.Desporto");
            DropForeignKey("dbo.Inscricao", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.UserRole", new[] { "RoleID" });
            DropIndex("dbo.UserRole", new[] { "UserID" });
            DropIndex("dbo.Gestao", new[] { "PessoaID" });
            DropIndex("dbo.Gestao", new[] { "UserID" });
            DropIndex("dbo.InscricaoExtra", new[] { "InscricaoID" });
            DropIndex("dbo.InscricaoExtra", new[] { "ExtraID" });
            DropIndex("dbo.Resultado", new[] { "CategoriaID" });
            DropIndex("dbo.Resultado", new[] { "PessoaID" });
            DropIndex("dbo.Pessoa", new[] { "EquipaID" });
            DropIndex("dbo.Prova", new[] { "EventoID" });
            DropIndex("dbo.Evento", new[] { "DesportoID" });
            DropIndex("dbo.Extra", new[] { "EventoID" });
            DropIndex("dbo.Inscricao", new[] { "PessoaID" });
            DropIndex("dbo.Inscricao", new[] { "CategoriaID" });
            DropIndex("dbo.Categoria", new[] { "ProvaID" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Gestao");
            DropTable("dbo.InscricaoExtra");
            DropTable("dbo.Pedido");
            DropTable("dbo.Resultado");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Equipa");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Prova");
            DropTable("dbo.Desporto");
            DropTable("dbo.Evento");
            DropTable("dbo.Extra");
            DropTable("dbo.Inscricao");
            DropTable("dbo.Categoria");
        }
    }
}
