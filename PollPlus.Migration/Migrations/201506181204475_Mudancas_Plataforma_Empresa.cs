namespace PollPlus.Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mudancas_Plataforma_Empresa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empresa", "SubDominio", c => c.String());
            AddColumn("dbo.Empresa", "Css", c => c.String());
            AddColumn("dbo.Empresa", "PlataformaId", c => c.Int(nullable: false));
            AddColumn("dbo.Plataforma", "App", c => c.Guid(nullable: false));
            CreateIndex("dbo.Empresa", "PlataformaId");
            AddForeignKey("dbo.Empresa", "PlataformaId", "dbo.Plataforma", "Id", cascadeDelete: true);
            DropColumn("dbo.Plataforma", "AppID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plataforma", "AppID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Empresa", "PlataformaId", "dbo.Plataforma");
            DropIndex("dbo.Empresa", new[] { "PlataformaId" });
            DropColumn("dbo.Plataforma", "App");
            DropColumn("dbo.Empresa", "PlataformaId");
            DropColumn("dbo.Empresa", "Css");
            DropColumn("dbo.Empresa", "SubDominio");
        }
    }
}
