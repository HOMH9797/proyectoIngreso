namespace ModelsDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class produtotienda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        SKU = c.String(),
                        Descripcion = c.String(),
                        Valor = c.Int(nullable: false),
                        Tienda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tienda", t => t.Tienda_Id)
                .Index(t => t.Tienda_Id);
            
            CreateTable(
                "dbo.Tienda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaApertura = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "Tienda_Id", "dbo.Tienda");
            DropIndex("dbo.Producto", new[] { "Tienda_Id" });
            DropTable("dbo.Tienda");
            DropTable("dbo.Producto");
        }
    }
}
