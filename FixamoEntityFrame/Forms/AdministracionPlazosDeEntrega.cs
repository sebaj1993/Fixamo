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
    public partial class AdministracionPlazosDeEntrega : Form
    {
        private List<Clases.PlazoEntrega> plazosDeEntrega;
        public AdministracionPlazosDeEntrega()
        {
            InitializeComponent();
        }

        private void AdministracionPlazosDeEntrega_Load(object sender, EventArgs e)
        {
            FixamoContext context = new FixamoContext();
            plazosDeEntrega = context.PlazosDeEntrega.Where(p => p.Habilitado).ToList();

            dataGridView1.DataSource = plazosDeEntrega;
        }

        private void validarDatos()
        {
            if (string.IsNullOrEmpty(nombreAgregar.Text))
                throw new Exception("Por Favor, completar datos obligatorios");
        }

        private void limpiarDatos()
        {
            nombreAgregar.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatos();

                Clases.PlazoEntrega newPlazoEntrega = new Clases.PlazoEntrega();
                newPlazoEntrega.Nombre = nombreAgregar.Text;

                FixamoContext context = new FixamoContext();
                context.PlazosDeEntrega.Add(newPlazoEntrega);
                context.SaveChanges();

                limpiarDatos();

                this.AdministracionPlazosDeEntrega_Load(null, null);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AMPlazosDeEntrega formaMPlazosDeEntrega = new AMPlazosDeEntrega(plazosDeEntrega[dataGridView1.CurrentRow.Index]);
            formaMPlazosDeEntrega.ShowDialog();
            //
            this.AdministracionPlazosDeEntrega_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idPlazoEntrega = (int)dataGridView1.SelectedRows[0].Cells["PlazoEntregaId"].Value;
            //
            FixamoContext context = new FixamoContext();
            Clases.PlazoEntrega plazoEntregaSeleccionado = context.PlazosDeEntrega.Find(idPlazoEntrega);
            plazoEntregaSeleccionado.Habilitado = false;
            context.SaveChanges();
            //
            this.AdministracionPlazosDeEntrega_Load(null, null);
        }
    }
}
