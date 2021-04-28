namespace FixamoEntityFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CondicionPagoes",
                c => new
                    {
                        CondicionPagoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CondicionPagoId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.DoctorId);
            
            CreateTable(
                "dbo.Presupuestoes",
                c => new
                    {
                        PresupuestoId = c.Int(nullable: false, identity: true),
                        NroPresupuesto = c.Int(nullable: false),
                        FechaPresupuesto = c.DateTime(nullable: false, precision: 0),
                        NroFactura = c.String(unicode: false),
                        FechaCirugia = c.DateTime(nullable: false, precision: 0),
                        Prestador = c.String(unicode: false),
                        MantenimientoDeOferta = c.String(unicode: false),
                        PacienteId = c.Int(),
                        DoctorId = c.Int(),
                        CondicionPagoId = c.Int(),
                        PlazoEntregaId = c.Int(),
                        SolicitanteId = c.Int(nullable: false),
                        LugarCirugiaId = c.Int(),
                        UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.PresupuestoId)
                .ForeignKey("dbo.CondicionPagoes", t => t.CondicionPagoId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.LugarCirugias", t => t.LugarCirugiaId)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId)
                .ForeignKey("dbo.PlazoEntregas", t => t.PlazoEntregaId)
                .ForeignKey("dbo.Solicitantes", t => t.SolicitanteId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.PacienteId)
                .Index(t => t.DoctorId)
                .Index(t => t.CondicionPagoId)
                .Index(t => t.PlazoEntregaId)
                .Index(t => t.SolicitanteId)
                .Index(t => t.LugarCirugiaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.LineaPresupuestoes",
                c => new
                    {
                        LineaPresupuestoId = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Descripcion = c.String(unicode: false),
                        Precio = c.Double(nullable: false),
                        Presupuesto_PresupuestoId = c.Int(),
                    })
                .PrimaryKey(t => t.LineaPresupuestoId)
                .ForeignKey("dbo.Presupuestoes", t => t.Presupuesto_PresupuestoId)
                .Index(t => t.Presupuesto_PresupuestoId);
            
            CreateTable(
                "dbo.LugarCirugias",
                c => new
                    {
                        LugarCirugiaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.LugarCirugiaId);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        PacienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        NroAfiliado = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PacienteId);
            
            CreateTable(
                "dbo.PlazoEntregas",
                c => new
                    {
                        PlazoEntregaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PlazoEntregaId);
            
            CreateTable(
                "dbo.Solicitantes",
                c => new
                    {
                        SolicitanteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        NombreOficina = c.String(unicode: false),
                        Telefono = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Cuit = c.String(unicode: false),
                        RazonSoc = c.String(unicode: false),
                        Exento = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SolicitanteId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Telefono = c.String(unicode: false),
                        Contraseña = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Parametros",
                c => new
                    {
                        ParametrosId = c.Int(nullable: false, identity: true),
                        NombreParametro = c.String(unicode: false),
                        valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParametrosId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Presupuestoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Presupuestoes", "SolicitanteId", "dbo.Solicitantes");
            DropForeignKey("dbo.Presupuestoes", "PlazoEntregaId", "dbo.PlazoEntregas");
            DropForeignKey("dbo.Presupuestoes", "PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Presupuestoes", "LugarCirugiaId", "dbo.LugarCirugias");
            DropForeignKey("dbo.LineaPresupuestoes", "Presupuesto_PresupuestoId", "dbo.Presupuestoes");
            DropForeignKey("dbo.Presupuestoes", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Presupuestoes", "CondicionPagoId", "dbo.CondicionPagoes");
            DropIndex("dbo.LineaPresupuestoes", new[] { "Presupuesto_PresupuestoId" });
            DropIndex("dbo.Presupuestoes", new[] { "UsuarioId" });
            DropIndex("dbo.Presupuestoes", new[] { "LugarCirugiaId" });
            DropIndex("dbo.Presupuestoes", new[] { "SolicitanteId" });
            DropIndex("dbo.Presupuestoes", new[] { "PlazoEntregaId" });
            DropIndex("dbo.Presupuestoes", new[] { "CondicionPagoId" });
            DropIndex("dbo.Presupuestoes", new[] { "DoctorId" });
            DropIndex("dbo.Presupuestoes", new[] { "PacienteId" });
            DropTable("dbo.Parametros");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Solicitantes");
            DropTable("dbo.PlazoEntregas");
            DropTable("dbo.Pacientes");
            DropTable("dbo.LugarCirugias");
            DropTable("dbo.LineaPresupuestoes");
            DropTable("dbo.Presupuestoes");
            DropTable("dbo.Doctors");
            DropTable("dbo.CondicionPagoes");
        }
    }
}
