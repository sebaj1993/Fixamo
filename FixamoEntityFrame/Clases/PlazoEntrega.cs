using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixamoEntityFrame.Clases
{
    public class PlazoEntrega
    {
        public int PlazoEntregaId { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; } = true;
    }
}
