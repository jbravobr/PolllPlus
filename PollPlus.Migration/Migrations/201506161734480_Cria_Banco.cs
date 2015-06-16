namespace PollPlus.Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cria_Banco : DbMigration
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
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        DataAtualizacao = c.DateTime(),
                        EmpresaProprietaria_Id = c.Int(),
                        UsuarioCriador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaProprietaria_Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCriador_Id)
                .Index(t => t.EmpresaProprietaria_Id)
                .Index(t => t.UsuarioCriador_Id);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Logo = c.String(),
                        QtdePush = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        Documento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documento", t => t.Documento_Id)
                .Index(t => t.Documento_Id);
            
            CreateTable(
                "dbo.Documento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        DataAtualizacao = c.DateTime(),
                        Empresa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Empresa_Id)
                .Index(t => t.Empresa_Id);
            
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
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Geolocalizacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plataforma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        AppID = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioCategoria",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.UsuarioId, t.CategoriaId })
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Voucher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identificador = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subcategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeSubCategoria = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pergunta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextoPergunta = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        Enquete_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enquete", t => t.Enquete_Id)
                .Index(t => t.Enquete_Id);
            
            CreateTable(
                "dbo.Resposta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextoResposta = c.String(),
                        DataResposta = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        Pergunta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pergunta", t => t.Pergunta_Id)
                .Index(t => t.Pergunta_Id);
            
            CreateTable(
                "dbo.EnqueteCategoria",
                c => new
                    {
                        Enquete_Id = c.Int(nullable: false),
                        Categoria_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Enquete_Id, t.Categoria_Id })
                .ForeignKey("dbo.Enquete", t => t.Enquete_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id, cascadeDelete: true)
                .Index(t => t.Enquete_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.MensagemCategoria",
                c => new
                    {
                        Mensagem_Id = c.Int(nullable: false),
                        Categoria_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Mensagem_Id, t.Categoria_Id })
                .ForeignKey("dbo.Mensagem", t => t.Mensagem_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id, cascadeDelete: true)
                .Index(t => t.Mensagem_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.GeolocalizacaoUsuario",
                c => new
                    {
                        Geolocalizacao_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Geolocalizacao_Id, t.Usuario_Id })
                .ForeignKey("dbo.Geolocalizacao", t => t.Geolocalizacao_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Geolocalizacao_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.PlataformaUsuario",
                c => new
                    {
                        Plataforma_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Plataforma_Id, t.Usuario_Id })
                .ForeignKey("dbo.Plataforma", t => t.Plataforma_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Plataforma_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.VoucherEnquete",
                c => new
                    {
                        Voucher_Id = c.Int(nullable: false),
                        Enquete_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Voucher_Id, t.Enquete_Id })
                .ForeignKey("dbo.Voucher", t => t.Voucher_Id, cascadeDelete: true)
                .ForeignKey("dbo.Enquete", t => t.Enquete_Id, cascadeDelete: true)
                .Index(t => t.Voucher_Id)
                .Index(t => t.Enquete_Id);
            
            CreateTable(
                "dbo.SubcategoriaCategoria",
                c => new
                    {
                        Subcategoria_Id = c.Int(nullable: false),
                        Categoria_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subcategoria_Id, t.Categoria_Id })
                .ForeignKey("dbo.Subcategoria", t => t.Subcategoria_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id, cascadeDelete: true)
                .Index(t => t.Subcategoria_Id)
                .Index(t => t.Categoria_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resposta", "Pergunta_Id", "dbo.Pergunta");
            DropForeignKey("dbo.Pergunta", "Enquete_Id", "dbo.Enquete");
            DropForeignKey("dbo.SubcategoriaCategoria", "Categoria_Id", "dbo.Categoria");
            DropForeignKey("dbo.SubcategoriaCategoria", "Subcategoria_Id", "dbo.Subcategoria");
            DropForeignKey("dbo.VoucherEnquete", "Enquete_Id", "dbo.Enquete");
            DropForeignKey("dbo.VoucherEnquete", "Voucher_Id", "dbo.Voucher");
            DropForeignKey("dbo.Enquete", "UsuarioCriador_Id", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioCategoria", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioCategoria", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.PlataformaUsuario", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.PlataformaUsuario", "Plataforma_Id", "dbo.Plataforma");
            DropForeignKey("dbo.GeolocalizacaoUsuario", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.GeolocalizacaoUsuario", "Geolocalizacao_Id", "dbo.Geolocalizacao");
            DropForeignKey("dbo.Mensagem", "Empresa_Id", "dbo.Empresa");
            DropForeignKey("dbo.MensagemCategoria", "Categoria_Id", "dbo.Categoria");
            DropForeignKey("dbo.MensagemCategoria", "Mensagem_Id", "dbo.Mensagem");
            DropForeignKey("dbo.Enquete", "EmpresaProprietaria_Id", "dbo.Empresa");
            DropForeignKey("dbo.Empresa", "Documento_Id", "dbo.Documento");
            DropForeignKey("dbo.EnqueteCategoria", "Categoria_Id", "dbo.Categoria");
            DropForeignKey("dbo.EnqueteCategoria", "Enquete_Id", "dbo.Enquete");
            DropIndex("dbo.SubcategoriaCategoria", new[] { "Categoria_Id" });
            DropIndex("dbo.SubcategoriaCategoria", new[] { "Subcategoria_Id" });
            DropIndex("dbo.VoucherEnquete", new[] { "Enquete_Id" });
            DropIndex("dbo.VoucherEnquete", new[] { "Voucher_Id" });
            DropIndex("dbo.PlataformaUsuario", new[] { "Usuario_Id" });
            DropIndex("dbo.PlataformaUsuario", new[] { "Plataforma_Id" });
            DropIndex("dbo.GeolocalizacaoUsuario", new[] { "Usuario_Id" });
            DropIndex("dbo.GeolocalizacaoUsuario", new[] { "Geolocalizacao_Id" });
            DropIndex("dbo.MensagemCategoria", new[] { "Categoria_Id" });
            DropIndex("dbo.MensagemCategoria", new[] { "Mensagem_Id" });
            DropIndex("dbo.EnqueteCategoria", new[] { "Categoria_Id" });
            DropIndex("dbo.EnqueteCategoria", new[] { "Enquete_Id" });
            DropIndex("dbo.Resposta", new[] { "Pergunta_Id" });
            DropIndex("dbo.Pergunta", new[] { "Enquete_Id" });
            DropIndex("dbo.UsuarioCategoria", new[] { "CategoriaId" });
            DropIndex("dbo.UsuarioCategoria", new[] { "UsuarioId" });
            DropIndex("dbo.Mensagem", new[] { "Empresa_Id" });
            DropIndex("dbo.Empresa", new[] { "Documento_Id" });
            DropIndex("dbo.Enquete", new[] { "UsuarioCriador_Id" });
            DropIndex("dbo.Enquete", new[] { "EmpresaProprietaria_Id" });
            DropTable("dbo.SubcategoriaCategoria");
            DropTable("dbo.VoucherEnquete");
            DropTable("dbo.PlataformaUsuario");
            DropTable("dbo.GeolocalizacaoUsuario");
            DropTable("dbo.MensagemCategoria");
            DropTable("dbo.EnqueteCategoria");
            DropTable("dbo.Resposta");
            DropTable("dbo.Pergunta");
            DropTable("dbo.Subcategoria");
            DropTable("dbo.Voucher");
            DropTable("dbo.UsuarioCategoria");
            DropTable("dbo.Plataforma");
            DropTable("dbo.Geolocalizacao");
            DropTable("dbo.Usuario");
            DropTable("dbo.Mensagem");
            DropTable("dbo.Documento");
            DropTable("dbo.Empresa");
            DropTable("dbo.Enquete");
            DropTable("dbo.Categoria");
        }
    }
}
