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
    public partial class Solicitantes : Form
    {
        private List<Clases.Solicitante> solicitantes;

        public Solicitantes()
        {
            InitializeComponent();
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

        private void cargarDataGrid()
        {
            dataGridView1.DataSource = null;

            FixamoContext context = new FixamoContext();
            solicitantes = context.Solicitantes.Where(s => s.Habilitado).ToList();

            dataGridView1.DataSource = solicitantes;
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                Row.Visible = true;
            }
        }

        private void Organizaciones_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerPresupuestos formVerPresupuestos = new VerPresupuestos(solicitantes[dataGridView1.CurrentRow.Index].Presupuestos.ToList());
            formVerPresupuestos.ShowDialog();
        }

        private void validarDatos()
        {
            if ((string.IsNullOrEmpty(nombreAgregar.Text)) || (string.IsNullOrEmpty(nombreOficina.Text)))
                throw new Exception("Por Favor, completar datos obligatorios");
        }

        private void limpiarDatos()
        {
            nombreAgregar.Text = "";
            nombreOficina.Text = "";
            telefono.Text = "";
            email.Text = "";
            cuit.Text = "";
            razonSoc.Text = "";
            exento.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatos();

                Clases.Solicitante newSolicitante = new Clases.Solicitante();
                newSolicitante.Nombre = nombreAgregar.Text;
                newSolicitante.NombreOficina = nombreOficina.Text;
                if(!(string.IsNullOrEmpty(telefono.Text)))
                    newSolicitante.Telefono = telefono.Text;
                if (!(string.IsNullOrEmpty(email.Text)))
                    newSolicitante.Email = email.Text;
                if (!(string.IsNullOrEmpty(cuit.Text)))
                    newSolicitante.Cuit = cuit.Text;
                if (!(string.IsNullOrEmpty(razonSoc.Text)))
                    newSolicitante.RazonSoc = razonSoc.Text;
                newSolicitante.Exento = exento.Checked;

                FixamoContext context = new FixamoContext();
                context.Solicitantes.Add(newSolicitante);
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
            AMSolicitantes formAMOrganizacion = new AMSolicitantes(solicitantes[dataGridView1.CurrentRow.Index]);
            formAMOrganizacion.ShowDialog();

            this.Organizaciones_Load(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idSolic = (int)dataGridView1.SelectedRows[0].Cells["SolicitanteId"].Value;
            //
            FixamoContext context = new FixamoContext();
            Clases.Solicitante solicitantesSeleccionado = context.Solicitantes.Find(idSolic);
            solicitantesSeleccionado.Habilitado = false;
            context.SaveChanges();
            //
            cargarDataGrid();
            buscarCoincidencias();
        }

        private void nombreBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarCoincidencias();
        }
    }
}
