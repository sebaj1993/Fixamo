using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixamoEntityFrame.Clases
{
    public class LineaPresupuesto
    {
        public int LineaPresupuestoId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public Double Precio { get; set; }
        public bool Habilitado { get; set; } = true;
    }
}
