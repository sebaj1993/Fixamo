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
    public partial class LugaresCirugias : Form
    {
        private List<Clases.LugarCirugia> lugaresCirugia;
        public LugaresCirugias()
        {
            InitializeComponent();
        }

        private void LugaresCirugias_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerPresupuestos formVerPresupuestos = new VerPresupuestos(lugaresCirugia[dataGridView1.CurrentRow.Index].Presupuestos.ToList());
            formVerPresupuestos.ShowDialog();
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

        private void cargarDataGrid()
        {
            dataGridView1.DataSource = null;

            FixamoContext context = new FixamoContext();
            lugaresCirugia = context.LugaresCirugias.Where(l => l.Habilitado).ToList();

            dataGridView1.DataSource = lugaresCirugia;
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                Row.Visible = true;
            }
        }

        private void buscarCoincidencias()
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                int indexFila = Row.Index;
                string valor = Convert.ToString(Row.Cells["nombre"].Value);
                //
                if (!(valor.ToUpper().Contains(nombreBuscar.Text.ToUpper())))
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    cm.SuspendBinding();
                    dataGridView1.Rows[indexFila].Visible = false;
                }
                else
                    dataGridView1.Rows[indexFila].Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatos();

                Clases.LugarCirugia newLugarCirugia = new Clases.LugarCirugia();
                newLugarCirugia.Nombre = nombreAgregar.Text;

                FixamoContext context = new FixamoContext();
                context.LugaresCirugias.Add(newLugarCirugia);
                context.SaveChanges();

                limpiarDatos();

                cargarDataGrid();
                buscarCoincidencias();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AMLugarCirugia formAMLugarCirugia = new AMLugarCirugia(lugaresCirugia[dataGridView1.CurrentRow.Index]);
            formAMLugarCirugia.ShowDialog();

            this.LugaresCirugias_Load(null, null);
        }

        private void nombreBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarCoincidencias();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idLugar = (int)dataGridView1.SelectedRows[0].Cells["LugarCirugiaId"].Value;
            //
            FixamoContext context = new FixamoContext();
            Clases.LugarCirugia lugarCirugiaSeleccionado = context.LugaresCirugias.Find(idLugar);
            lugarCirugiaSeleccionado.Habilitado = false;
            context.SaveChanges();
            //
            cargarDataGrid();
            buscarCoincidencias();
        }
    }
}
