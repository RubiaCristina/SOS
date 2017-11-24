namespace SOS_MoradoresDeRua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Texto = c.String(),
                        DicionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .ForeignKey("dbo.Dicionarios", t => t.DicionarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.PessoaId)
                .Index(t => t.DicionarioId);
            
            CreateTable(
                "dbo.Denuncias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        UsuarioDenunciadoId = c.Int(),
                        ComentarioId = c.Int(),
                        FotoId = c.Int(),
                        PessoaId = c.Int(),
                        Descricao = c.String(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comentarios", t => t.ComentarioId)
                .ForeignKey("dbo.Fotoes", t => t.FotoId)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioDenunciadoId)
                .Index(t => t.UsuarioId)
                .Index(t => t.UsuarioDenunciadoId)
                .Index(t => t.ComentarioId)
                .Index(t => t.FotoId)
                .Index(t => t.PessoaId)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Fotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        PessoaId = c.Int(),
                        Fotografia = c.Binary(),
                        Data = c.DateTime(nullable: false),
                        TipoFotografia = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        LocalDeOrigem = c.String(),
                        Idade = c.Int(nullable: false),
                        DataDePublicacao = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        SexoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sexoes", t => t.SexoId)
                .Index(t => t.SexoId);
            
            CreateTable(
                "dbo.PessoaDesaparecidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PessoaId = c.Int(nullable: false),
                        DataDeDesaparecimento = c.DateTime(nullable: false),
                        Familiares = c.String(),
                        Local = c.String(),
                        Como = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.MoradorDeRuas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PessoaId = c.Int(nullable: false),
                        OndeVive = c.String(),
                        Historia = c.String(),
                        Necessidades = c.String(),
                        Profissao = c.String(),
                        Escolaridade = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Sexoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Opcao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Senha = c.String(),
                        EMail = c.String(),
                        Nome = c.String(),
                        Telefone = c.String(),
                        LinkRedesSociais = c.String(),
                        TipoUsuarioId = c.Int(nullable: false),
                        SexoId = c.Int(nullable: false),
                        Sobre = c.String(),
                        CriacaoDeConta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sexoes", t => t.SexoId)
                .ForeignKey("dbo.TipoUsuarios", t => t.TipoUsuarioId)
                .Index(t => t.TipoUsuarioId)
                .Index(t => t.SexoId);
            
            CreateTable(
                "dbo.TipoUsuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dicionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Palavra = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "DicionarioId", "dbo.Dicionarios");
            DropForeignKey("dbo.Denuncias", "UsuarioDenunciadoId", "dbo.Usuarios");
            DropForeignKey("dbo.Denuncias", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "TipoUsuarioId", "dbo.TipoUsuarios");
            DropForeignKey("dbo.Usuarios", "SexoId", "dbo.Sexoes");
            DropForeignKey("dbo.Fotoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Denuncias", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Comentarios", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Pessoas", "SexoId", "dbo.Sexoes");
            DropForeignKey("dbo.MoradorDeRuas", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.Fotoes", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.PessoaDesaparecidas", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.Denuncias", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.Comentarios", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.Denuncias", "FotoId", "dbo.Fotoes");
            DropForeignKey("dbo.Denuncias", "ComentarioId", "dbo.Comentarios");
            DropIndex("dbo.Usuarios", new[] { "SexoId" });
            DropIndex("dbo.Usuarios", new[] { "TipoUsuarioId" });
            DropIndex("dbo.MoradorDeRuas", new[] { "PessoaId" });
            DropIndex("dbo.PessoaDesaparecidas", new[] { "PessoaId" });
            DropIndex("dbo.Pessoas", new[] { "SexoId" });
            DropIndex("dbo.Fotoes", new[] { "PessoaId" });
            DropIndex("dbo.Fotoes", new[] { "UsuarioId" });
            DropIndex("dbo.Denuncias", new[] { "Usuario_Id" });
            DropIndex("dbo.Denuncias", new[] { "PessoaId" });
            DropIndex("dbo.Denuncias", new[] { "FotoId" });
            DropIndex("dbo.Denuncias", new[] { "ComentarioId" });
            DropIndex("dbo.Denuncias", new[] { "UsuarioDenunciadoId" });
            DropIndex("dbo.Denuncias", new[] { "UsuarioId" });
            DropIndex("dbo.Comentarios", new[] { "DicionarioId" });
            DropIndex("dbo.Comentarios", new[] { "PessoaId" });
            DropIndex("dbo.Comentarios", new[] { "UsuarioId" });
            DropTable("dbo.Dicionarios");
            DropTable("dbo.TipoUsuarios");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Sexoes");
            DropTable("dbo.MoradorDeRuas");
            DropTable("dbo.PessoaDesaparecidas");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Fotoes");
            DropTable("dbo.Denuncias");
            DropTable("dbo.Comentarios");
        }
    }
}
