using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixamoEntityFrame.Clases
{
    public class Doctor
    {
        private readonly FixamoEntityFrame.ObservableListSource<Presupuesto> _presupuestos =
                    new ObservableListSource<Presupuesto>();

        public int DoctorId { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; } = true;

        public virtual ObservableListSource<Presupuesto> Presupuestos { get { return _presupuestos; } }
    }
}
