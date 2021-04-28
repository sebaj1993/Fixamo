using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixamoEntityFrame.Forms
{
    public partial class AdministrarProximoNroPresupuesto : Form
    {
        public AdministrarProximoNroPresupuesto()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdministrarProximoNroPresupuesto_Load(object sender, EventArgs e)
        {
            FixamoContext context = new FixamoContext();
            Clases.Parametros parametro = context.Parametros.Where(p => p.NombreParametro == "ULTNROPRESUP").First();
            //
            proxValor.Text = (parametro.valor + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FixamoContext context = new FixamoContext();
            Clases.Parametros parametro = context.Parametros.Where(p => p.NombreParametro == "ULTNROPRESUP").First();
            //
            parametro.valor = int.Parse(proxValor.Text) - 1;
            context.SaveChanges();
            //
            this.Close();
        }
    }
}
