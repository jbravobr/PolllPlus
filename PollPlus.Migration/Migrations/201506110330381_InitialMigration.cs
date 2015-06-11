namespace PollPlus.Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Status = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Empresa_Id = c.Int(),
                        Enquete_Id = c.Int(),
                        Usuario_Id = c.Int(),
                        Mensagem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Empresa_Id)
                .ForeignKey("dbo.Enquete", t => t.Enquete_Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .ForeignKey("dbo.Mensagem", t => t.Mensagem_Id)
                .Index(t => t.Empresa_Id)
                .Index(t => t.Enquete_Id)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Mensagem_Id);
            
            CreateTable(
                "dbo.Subcategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeSubCategoria = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.Documento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Logo = c.String(),
                        QtdePush = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Documento_Id = c.Int(),
                        Mensagem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documento", t => t.Documento_Id)
                .ForeignKey("dbo.Mensagem", t => t.Mensagem_Id)
                .Index(t => t.Documento_Id)
                .Index(t => t.Mensagem_Id);
            
            CreateTable(
                "dbo.Enquete",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Status = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        TipoImagem = c.Int(nullable: false),
                        Imagem = c.String(),
                        ClientId = c.Int(nullable: false),
                        UrlVideo = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        EmpresaProprietaria_Id = c.Int(),
                        Pergunta_Id = c.Int(),
                        UsuarioCriador_Id = c.Int(),
                        Voucher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaProprietaria_Id)
                .ForeignKey("dbo.Pergunta", t => t.Pergunta_Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCriador_Id)
                .ForeignKey("dbo.Voucher", t => t.Voucher_Id)
                .Index(t => t.EmpresaProprietaria_Id)
                .Index(t => t.Pergunta_Id)
                .Index(t => t.UsuarioCriador_Id)
                .Index(t => t.Voucher_Id);
            
            CreateTable(
                "dbo.Pergunta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextoPergunta = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resposta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextoResposta = c.String(),
                        DataResposta = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Pergunta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pergunta", t => t.Pergunta_Id)
                .Index(t => t.Pergunta_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Sexo = c.Int(nullable: false),
                        DDD = c.Int(nullable: false),
                        Telefone = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Municipio = c.String(),
                        Status = c.Int(nullable: false),
                        Perfil = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Geolocalizacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        AppID = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Plataforma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        AppID = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Usuario_Id = c.Int(),
                        Mensagem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .ForeignKey("dbo.Mensagem", t => t.Mensagem_Id)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Mensagem_Id);
            
            CreateTable(
                "dbo.Mensagem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        AlcanceEmKm = c.Int(nullable: false),
                        EhRascunho = c.Boolean(nullable: false),
                        Tipo = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voucher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identificador = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enquete", "Voucher_Id", "dbo.Voucher");
            DropForeignKey("dbo.Plataforma", "Mensagem_Id", "dbo.Mensagem");
            DropForeignKey("dbo.Empresa", "Mensagem_Id", "dbo.Mensagem");
            DropForeignKey("dbo.Categoria", "Mensagem_Id", "dbo.Mensagem");
            DropForeignKey("dbo.Enquete", "UsuarioCriador_Id", "dbo.Usuario");
            DropForeignKey("dbo.Plataforma", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Geolocalizacao", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Categoria", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Enquete", "Pergunta_Id", "dbo.Pergunta");
            DropForeignKey("dbo.Resposta", "Pergunta_Id", "dbo.Pergunta");
            DropForeignKey("dbo.Enquete", "EmpresaProprietaria_Id", "dbo.Empresa");
            DropForeignKey("dbo.Categoria", "Enquete_Id", "dbo.Enquete");
            DropForeignKey("dbo.Empresa", "Documento_Id", "dbo.Documento");
            DropForeignKey("dbo.Categoria", "Empresa_Id", "dbo.Empresa");
            DropForeignKey("dbo.Subcategoria", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.Plataforma", new[] { "Mensagem_Id" });
            DropIndex("dbo.Plataforma", new[] { "Usuario_Id" });
            DropIndex("dbo.Geolocalizacao", new[] { "Usuario_Id" });
            DropIndex("dbo.Resposta", new[] { "Pergunta_Id" });
            DropIndex("dbo.Enquete", new[] { "Voucher_Id" });
            DropIndex("dbo.Enquete", new[] { "UsuarioCriador_Id" });
            DropIndex("dbo.Enquete", new[] { "Pergunta_Id" });
            DropIndex("dbo.Enquete", new[] { "EmpresaProprietaria_Id" });
            DropIndex("dbo.Empresa", new[] { "Mensagem_Id" });
            DropIndex("dbo.Empresa", new[] { "Documento_Id" });
            DropIndex("dbo.Subcategoria", new[] { "Categoria_Id" });
            DropIndex("dbo.Categoria", new[] { "Mensagem_Id" });
            DropIndex("dbo.Categoria", new[] { "Usuario_Id" });
            DropIndex("dbo.Categoria", new[] { "Enquete_Id" });
            DropIndex("dbo.Categoria", new[] { "Empresa_Id" });
            DropTable("dbo.Voucher");
            DropTable("dbo.Mensagem");
            DropTable("dbo.Plataforma");
            DropTable("dbo.Geolocalizacao");
            DropTable("dbo.Usuario");
            DropTable("dbo.Resposta");
            DropTable("dbo.Pergunta");
            DropTable("dbo.Enquete");
            DropTable("dbo.Empresa");
            DropTable("dbo.Documento");
            DropTable("dbo.Subcategoria");
            DropTable("dbo.Categoria");
        }
    }
}
