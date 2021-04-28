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
    public partial class Doctores : Form
    {
        private List<Clases.Doctor> doctores;

        public Doctores()
        {
            InitializeComponent();
        }

        private void cargarDataGrid()
        {
            dataGridView1.DataSource = null;

            FixamoContext context = new FixamoContext();
            doctores = context.Doctores.Where(d => d.Habilitado).ToList();

            dataGridView1.DataSource = doctores;
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                Row.Visible = true;
            }
        }

        private void Doctores_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
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

                Clases.Doctor newDoctor = new Clases.Doctor();
                newDoctor.Nombre = nombreAgregar.Text;

                FixamoContext context = new FixamoContext();
                context.Doctores.Add(newDoctor);
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
            AMDoctor formAMDoctor = new AMDoctor(doctores[dataGridView1.CurrentRow.Index]);
            formAMDoctor.ShowDialog();
            //
            this.Doctores_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerPresupuestos formVerPresupuestos = new VerPresupuestos(doctores[dataGridView1.CurrentRow.Index].Presupuestos.ToList());
            formVerPresupuestos.ShowDialog();
        }

        private void nombreBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarCoincidencias();
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

        private void button4_Click(object sender, EventArgs e)
        {
            int idDoc = (int)dataGridView1.SelectedRows[0].Cells["DoctorId"].Value;
            //
            FixamoContext context = new FixamoContext();
            Clases.Doctor doctorSeleccionado = context.Doctores.Find(idDoc);
            doctorSeleccionado.Habilitado = false;
            context.SaveChanges();
            //
            cargarDataGrid();
            buscarCoincidencias();
        }
    }
}
