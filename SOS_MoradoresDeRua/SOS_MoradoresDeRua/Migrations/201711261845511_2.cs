namespace SOS_MoradoresDeRua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Denuncias", "FotoId", "dbo.Fotoes");
            DropForeignKey("dbo.Comentarios", "DicionarioId", "dbo.Dicionarios");
            DropIndex("dbo.Comentarios", new[] { "DicionarioId" });
            DropIndex("dbo.Denuncias", new[] { "FotoId" });
            RenameColumn(table: "dbo.Denuncias", name: "ComentarioId", newName: "Comentario_Id");
            RenameIndex(table: "dbo.Denuncias", name: "IX_ComentarioId", newName: "IX_Comentario_Id");
            DropColumn("dbo.Comentarios", "DicionarioId");
            DropColumn("dbo.Denuncias", "FotoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Denuncias", "FotoId", c => c.Int());
            AddColumn("dbo.Comentarios", "DicionarioId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Denuncias", name: "IX_Comentario_Id", newName: "IX_ComentarioId");
            RenameColumn(table: "dbo.Denuncias", name: "Comentario_Id", newName: "ComentarioId");
            CreateIndex("dbo.Denuncias", "FotoId");
            CreateIndex("dbo.Comentarios", "DicionarioId");
            AddForeignKey("dbo.Comentarios", "DicionarioId", "dbo.Dicionarios", "Id");
            AddForeignKey("dbo.Denuncias", "FotoId", "dbo.Fotoes", "Id");
        }
    }
}
