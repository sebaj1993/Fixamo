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
    public partial class Pacientes : Form
    {
        private List<Clases.Paciente> pacientes;

        public Pacientes()
        {
            InitializeComponent();
        }

        private void cargarDataGrid()
        {
            dataGridView1.DataSource = null;

            FixamoContext context = new FixamoContext();
            pacientes = context.Pacientes.Where(p => p.Habilitado).ToList();

            dataGridView1.DataSource = pacientes;
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                Row.Visible = true;
            }
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerPresupuestos formVerPresupuestos = new VerPresupuestos(pacientes[dataGridView1.CurrentRow.Index].Presupuestos.ToList());
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
            nroAfiliado.Text = "";
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

                Clases.Paciente newPaciente = new Clases.Paciente();
                newPaciente.Nombre = nombreAgregar.Text;
                if (!(string.IsNullOrEmpty(nroAfiliado.Text)))
                    newPaciente.NroAfiliado = nroAfiliado.Text;
                

                FixamoContext context = new FixamoContext();
                context.Pacientes.Add(newPaciente);
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
            AMPaciente formAMPaciente = new AMPaciente(pacientes[dataGridView1.CurrentRow.Index]);
            formAMPaciente.ShowDialog();

            this.Pacientes_Load(null, null);
        }

        private void nombreBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarCoincidencias();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idPaciente = (int)dataGridView1.SelectedRows[0].Cells["PacienteId"].Value;
            //
            FixamoContext context = new FixamoContext();
            Clases.Paciente pacienteSeleccionado = context.Pacientes.Find(idPaciente);
            pacienteSeleccionado.Habilitado = false;
            context.SaveChanges();
            //
            cargarDataGrid();
            buscarCoincidencias();
        }
    }
}
