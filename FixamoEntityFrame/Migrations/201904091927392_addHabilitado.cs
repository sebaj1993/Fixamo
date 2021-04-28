namespace FixamoEntityFrame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHabilitado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CondicionPagoes", "Habilitado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Doctors", "Habilitado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Presupuestoes", "Habilitado", c => c.Boolean(nullable: false));
            AddColumn("dbo.LineaPresupuestoes", "Habilitado", c => c.Boolean(nullable: false));
            AddColumn("dbo.LugarCirugias", "Habilitado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pacientes", "Habilitado", c => c.Boolean(nullable: false));
            AddColumn("dbo.PlazoEntregas", "Habilitado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Solicitantes", "Habilitado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "Habilitado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Habilitado");
            DropColumn("dbo.Solicitantes", "Habilitado");
            DropColumn("dbo.PlazoEntregas", "Habilitado");
            DropColumn("dbo.Pacientes", "Habilitado");
            DropColumn("dbo.LugarCirugias", "Habilitado");
            DropColumn("dbo.LineaPresupuestoes", "Habilitado");
            DropColumn("dbo.Presupuestoes", "Habilitado");
            DropColumn("dbo.Doctors", "Habilitado");
            DropColumn("dbo.CondicionPagoes", "Habilitado");
        }
    }
}
