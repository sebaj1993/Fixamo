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
    public partial class AdministracionCondicionesDePago : Form
    {
        private List<Clases.CondicionPago> condicionesDePago;

        public AdministracionCondicionesDePago()
        {
            InitializeComponent();
        }

        private void AdministracionCondicionesDePago_Load(object sender, EventArgs e)
        {
            FixamoContext context = new FixamoContext();
            condicionesDePago = context.CondicionesDePago.Where(c => c.Habilitado).ToList();

            dataGridView1.DataSource = condicionesDePago;
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

                Clases.CondicionPago newCondicionDePago = new Clases.CondicionPago();
                newCondicionDePago.Nombre = nombreAgregar.Text;

                FixamoContext context = new FixamoContext();
                context.CondicionesDePago.Add(newCondicionDePago);
                context.SaveChanges();

                limpiarDatos();

                this.AdministracionCondicionesDePago_Load(null, null);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AMCondicionesDePago formAmCondicionesDePago = new AMCondicionesDePago(condicionesDePago[dataGridView1.CurrentRow.Index]);
            formAmCondicionesDePago.ShowDialog();
            //
            this.AdministracionCondicionesDePago_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idCondicion = (int)dataGridView1.SelectedRows[0].Cells["CondicionPagoId"].Value;
            //
            FixamoContext context = new FixamoContext();
            Clases.CondicionPago condicionSeleccionado = context.CondicionesDePago.Find(idCondicion);
            condicionSeleccionado.Habilitado = false;
            context.SaveChanges();
            //
            this.AdministracionCondicionesDePago_Load(null, null);
        }
    }
}
