using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace FixamoEntityFrame
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class FixamoContext : DbContext
    {
        public DbSet<FixamoEntityFrame.Clases.Paciente> Pacientes { get; set; }
        public DbSet<FixamoEntityFrame.Clases.Presupuesto> Presupuestos { get; set; }
        public DbSet<FixamoEntityFrame.Clases.Doctor> Doctores { get; set; }
        public DbSet<FixamoEntityFrame.Clases.CondicionPago> CondicionesDePago { get; set; }
        public DbSet<FixamoEntityFrame.Clases.LineaPresupuesto> LineasPresupuestos { get; set; }
        public DbSet<FixamoEntityFrame.Clases.LugarCirugia> LugaresCirugias { get; set; }
        public DbSet<FixamoEntityFrame.Clases.Solicitante> Solicitantes { get; set; }
        public DbSet<FixamoEntityFrame.Clases.PlazoEntrega> PlazosDeEntrega { get; set; }
        public DbSet<FixamoEntityFrame.Clases.Usuario> Usuarios { get; set; }
        public DbSet<FixamoEntityFrame.Clases.Parametros> Parametros { get; set; }
    }
}
