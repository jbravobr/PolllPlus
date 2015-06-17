namespace PollPlus.Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaBD : DbMigration
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
                "dbo.SubcategoriaCategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubcategoriaId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Subcategoria", t => t.SubcategoriaId, cascadeDelete: true)
                .Index(t => t.SubcategoriaId)
                .Index(t => t.CategoriaId);
            
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
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Logo = c.String(),
                        QtdePush = c.Int(nullable: false),
                        DocumentoId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documento", t => t.DocumentoId, cascadeDelete: true)
                .Index(t => t.DocumentoId);
            
            CreateTable(
                "dbo.Mensagem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        AlcanceEmKm = c.Int(nullable: false),
                        EhRascunho = c.Boolean(nullable: false),
                        Tipo = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.MensagemCategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MensagemId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Mensagem", t => t.MensagemId, cascadeDelete: true)
                .Index(t => t.MensagemId)
                .Index(t => t.CategoriaId);
            
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
                        UsuarioId = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        PerguntaId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.Pergunta", t => t.PerguntaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.EmpresaId)
                .Index(t => t.PerguntaId);
            
            CreateTable(
                "dbo.EnqueteCategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnqueteId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Enquete", t => t.EnqueteId, cascadeDelete: true)
                .Index(t => t.EnqueteId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.EnqueteVoucher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnqueteId = c.Int(nullable: false),
                        VoucherId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enquete", t => t.EnqueteId, cascadeDelete: true)
                .ForeignKey("dbo.Voucher", t => t.VoucherId, cascadeDelete: true)
                .Index(t => t.EnqueteId)
                .Index(t => t.VoucherId);
            
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
                "dbo.Pergunta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextoPergunta = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PerguntaResposta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerguntaId = c.Int(nullable: false),
                        RespostaId = c.Int(nullable: false),
                        Respondida = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pergunta", t => t.PerguntaId, cascadeDelete: true)
                .ForeignKey("dbo.Resposta", t => t.RespostaId, cascadeDelete: true)
                .Index(t => t.PerguntaId)
                .Index(t => t.RespostaId);
            
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
                "dbo.UsuarioCategoria",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.Id, t.UsuarioId, t.CategoriaId })
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.UsuarioPlataforma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        PlataformaId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plataforma", t => t.PlataformaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.PlataformaId);
            
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
                "dbo.Geolocalizacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Geolocalizacao", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Enquete", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioPlataforma", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioPlataforma", "PlataformaId", "dbo.Plataforma");
            DropForeignKey("dbo.UsuarioCategoria", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioCategoria", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Enquete", "PerguntaId", "dbo.Pergunta");
            DropForeignKey("dbo.PerguntaResposta", "RespostaId", "dbo.Resposta");
            DropForeignKey("dbo.Resposta", "Pergunta_Id", "dbo.Pergunta");
            DropForeignKey("dbo.PerguntaResposta", "PerguntaId", "dbo.Pergunta");
            DropForeignKey("dbo.EnqueteVoucher", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.EnqueteVoucher", "EnqueteId", "dbo.Enquete");
            DropForeignKey("dbo.EnqueteCategoria", "EnqueteId", "dbo.Enquete");
            DropForeignKey("dbo.EnqueteCategoria", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Enquete", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.MensagemCategoria", "MensagemId", "dbo.Mensagem");
            DropForeignKey("dbo.MensagemCategoria", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Mensagem", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Empresa", "DocumentoId", "dbo.Documento");
            DropForeignKey("dbo.SubcategoriaCategoria", "SubcategoriaId", "dbo.Subcategoria");
            DropForeignKey("dbo.SubcategoriaCategoria", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Geolocalizacao", new[] { "UsuarioId" });
            DropIndex("dbo.UsuarioPlataforma", new[] { "PlataformaId" });
            DropIndex("dbo.UsuarioPlataforma", new[] { "UsuarioId" });
            DropIndex("dbo.UsuarioCategoria", new[] { "CategoriaId" });
            DropIndex("dbo.UsuarioCategoria", new[] { "UsuarioId" });
            DropIndex("dbo.Resposta", new[] { "Pergunta_Id" });
            DropIndex("dbo.PerguntaResposta", new[] { "RespostaId" });
            DropIndex("dbo.PerguntaResposta", new[] { "PerguntaId" });
            DropIndex("dbo.EnqueteVoucher", new[] { "VoucherId" });
            DropIndex("dbo.EnqueteVoucher", new[] { "EnqueteId" });
            DropIndex("dbo.EnqueteCategoria", new[] { "CategoriaId" });
            DropIndex("dbo.EnqueteCategoria", new[] { "EnqueteId" });
            DropIndex("dbo.Enquete", new[] { "PerguntaId" });
            DropIndex("dbo.Enquete", new[] { "EmpresaId" });
            DropIndex("dbo.Enquete", new[] { "UsuarioId" });
            DropIndex("dbo.MensagemCategoria", new[] { "CategoriaId" });
            DropIndex("dbo.MensagemCategoria", new[] { "MensagemId" });
            DropIndex("dbo.Mensagem", new[] { "EmpresaId" });
            DropIndex("dbo.Empresa", new[] { "DocumentoId" });
            DropIndex("dbo.SubcategoriaCategoria", new[] { "CategoriaId" });
            DropIndex("dbo.SubcategoriaCategoria", new[] { "SubcategoriaId" });
            DropTable("dbo.Geolocalizacao");
            DropTable("dbo.Plataforma");
            DropTable("dbo.UsuarioPlataforma");
            DropTable("dbo.UsuarioCategoria");
            DropTable("dbo.Usuario");
            DropTable("dbo.Resposta");
            DropTable("dbo.PerguntaResposta");
            DropTable("dbo.Pergunta");
            DropTable("dbo.Voucher");
            DropTable("dbo.EnqueteVoucher");
            DropTable("dbo.EnqueteCategoria");
            DropTable("dbo.Enquete");
            DropTable("dbo.MensagemCategoria");
            DropTable("dbo.Mensagem");
            DropTable("dbo.Empresa");
            DropTable("dbo.Documento");
            DropTable("dbo.Subcategoria");
            DropTable("dbo.SubcategoriaCategoria");
            DropTable("dbo.Categoria");
        }
    }
}
