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
    public partial class VerPresupuestos : Form
    {
        private List<Clases.Presupuesto> presupuestos;
        public VerPresupuestos(List<Clases.Presupuesto> presupuestosP)
        {
            InitializeComponent();
            presupuestos = presupuestosP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null) //Averiguar si se seleccionó un campo en el Datagridview
            {
                int idPresupuesto = (int)dataGridView1.SelectedRows[0].Cells["PresupuestoId"].Value;
                FixamoContext context = new FixamoContext();
                Clases.Presupuesto presupuestosSeleccionado = context.Presupuestos.Find(idPresupuesto);
                presupuestosSeleccionado.imprimir();
            }
        }

        private void VerPresupuestos_Load(object sender, EventArgs e)
        {
            busqFecha.Checked = false;
            busqNro.Checked = false;
            busqTodos.Checked = false;
            busqTodos.Checked = true;
            //
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {
            /*dataGridView1.DataSource = null;
            List<Clases.Presupuesto> aux = presupuestos.ToList();
            dataGridView1.DataSource = aux;*/
            //
            dataGridView1.DataSource = presupuestos;
            agregarColumnasDataGrid(this.dataGridView1);
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                Row.Visible = true;
                int index = Row.Index;
                Clases.Presupuesto presupuestoAct = presupuestos[index];
                Row.Cells["UsuarioNombre"].Value = (string)presupuestoAct.Usuario.Nombre.ToString();
                if(presupuestoAct.Doctor != null)
                    Row.Cells["DoctorNombre"].Value = (string)presupuestoAct.Doctor.Nombre.ToString();
                if (presupuestoAct.Paciente != null)
                    Row.Cells["PacienteNombre"].Value = (string)presupuestoAct.Paciente.Nombre.ToString();
                Row.Cells["SolicitanteNombre"].Value = (string)presupuestoAct.Solicitante.Nombre.ToString();
                if (presupuestoAct.LugarCirugia != null)
                    Row.Cells["LugarCirugiaNombre"].Value = (string)presupuestoAct.LugarCirugia.Nombre.ToString();
                DateTime fechaCirugia = (DateTime)Row.Cells["FechaCirugia"].Value;
                if (fechaCirugia == default(DateTime))
                    Row.Cells["FechaCirugia"].Value = null;
                if (!(presupuestoAct.Habilitado))
                {
                    dataGridView1.CurrentCell = null;
                    Row.Visible = false;
                }
                    
            }
            ocultarColumnas();
        }
        
        private void ocultarColumnas()
        {
            this.dataGridView1.Columns["Usuario"].Visible = false;
            this.dataGridView1.Columns["Doctor"].Visible = false;
            this.dataGridView1.Columns["Paciente"].Visible = false;
            this.dataGridView1.Columns["Solicitante"].Visible = false;
            this.dataGridView1.Columns["LugarCirugia"].Visible = false;
            this.dataGridView1.Columns["UsuarioId"].Visible = false;
            this.dataGridView1.Columns["DoctorId"].Visible = false;
            this.dataGridView1.Columns["PacienteId"].Visible = false;
            this.dataGridView1.Columns["SolicitanteId"].Visible = false;
            this.dataGridView1.Columns["LugarCirugiaId"].Visible = false;
            this.dataGridView1.Columns["PlazoEntrega"].Visible = false;
            this.dataGridView1.Columns["PlazoEntregaId"].Visible = false;
            this.dataGridView1.Columns["CondicionPago"].Visible = false;
            this.dataGridView1.Columns["CondicionPagoId"].Visible = false;
            
        }

        private void buscarPorNumero()
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                int indexFila = Row.Index;
                string valor = Convert.ToString(Row.Cells["NroPresupuesto"].Value);
                //
                if (!(valor.Contains(nroPresup.Text.ToUpper())))
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    cm.SuspendBinding();
                    dataGridView1.Rows[indexFila].Visible = false;
                }
                else
                    dataGridView1.Rows[indexFila].Visible = true;
            }
        }

        private void nroPresup_TextChanged(object sender, EventArgs e)
        {
            buscarPorNumero();
        }

        private void buscarPorFecha()
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                int indexFila = Row.Index;
                DateTime valorReal = (DateTime)Row.Cells["FechaPresupuesto"].Value;
                DateTime valorABuscar = new DateTime(valorReal.Year, valorReal.Month, valorReal.Day);
                //
                if (!(valorABuscar.Date == fechaPresup.Value.Date))
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    cm.SuspendBinding();
                    dataGridView1.Rows[indexFila].Visible = false;
                }
                else
                    dataGridView1.Rows[indexFila].Visible = true;
            }
        }

        private void busqNro_CheckedChanged(object sender, EventArgs e)
        {
            //verificarCheckBox();
            if (busqNro.Checked)
            {
                nroPresup.Text = "";
                nroPresup.Enabled = true;
                busqFecha.Checked = false;
                fechaPresup.Enabled = false;
                busqTodos.Checked = false;
                //
                cargarDataGrid();
                buscarPorNumero();
            }
        }

        private void busqFecha_CheckedChanged(object sender, EventArgs e)
        {
            //verificarCheckBox();
            if (busqFecha.Checked)
            {
                nroPresup.Text = "";
                nroPresup.Enabled = false;
                busqNro.Checked = false;
                fechaPresup.Enabled = true;
                busqTodos.Checked = false;
                //
                cargarDataGrid();
                buscarPorFecha();
            }
        }

        private void busqTodos_CheckedChanged(object sender, EventArgs e)
        {
            //verificarCheckBox();
            if (busqTodos.Checked)
            {
                nroPresup.Text = "";
                nroPresup.Enabled = false;
                busqFecha.Checked = false;
                fechaPresup.Enabled = false;
                busqNro.Checked = false;
                //
                cargarDataGrid();
            }
        }

        private void fechaPresup_ValueChanged(object sender, EventArgs e)
        {
            buscarPorFecha();
        }

        private void agregarColumnasDataGrid(DataGridView datagridview)
        {
            DataGridViewTextBoxColumn columnaUsuario = new DataGridViewTextBoxColumn();
            columnaUsuario.HeaderText = "Usuario";
            columnaUsuario.Name = "UsuarioNombre";
            DataGridViewTextBoxColumn columnaDoctor = new DataGridViewTextBoxColumn();
            columnaDoctor.HeaderText = "Doctor";
            columnaDoctor.Name = "DoctorNombre";
            DataGridViewTextBoxColumn columnaPaciente = new DataGridViewTextBoxColumn();
            columnaPaciente.HeaderText = "Paciente";
            columnaPaciente.Name = "PacienteNombre";
            DataGridViewTextBoxColumn columnaOrganizacion = new DataGridViewTextBoxColumn();
            columnaOrganizacion.HeaderText = "Solicitante";
            columnaOrganizacion.Name = "SolicitanteNombre";
            DataGridViewTextBoxColumn columnaLugarCirugia = new DataGridViewTextBoxColumn();
            columnaLugarCirugia.HeaderText = "LugarCirugia";
            columnaLugarCirugia.Name = "LugarCirugiaNombre";
            //
            if (!(dataGridView1.Columns.Contains("UsuarioNombre")))
                dataGridView1.Columns.Add(columnaUsuario);
            if (!(dataGridView1.Columns.Contains("DoctorNombre")))
                dataGridView1.Columns.Add(columnaDoctor);
            if (!(dataGridView1.Columns.Contains("PacienteNombre")))
                dataGridView1.Columns.Add(columnaPaciente);
            if (!(dataGridView1.Columns.Contains("SolicitanteNombre")))
                dataGridView1.Columns.Add(columnaOrganizacion);
            if (!(dataGridView1.Columns.Contains("LugarCirugiaNombre")))
                dataGridView1.Columns.Add(columnaLugarCirugia);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idPresupuesto = (int)dataGridView1.SelectedRows[0].Cells["PresupuestoId"].Value;
            FixamoContext context = new FixamoContext();
            Clases.Presupuesto presupuestosSeleccionado = context.Presupuestos.Find(idPresupuesto);
            //presupuestosSeleccionado.imprimir(false);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null) //Averiguar si se seleccionó un campo en el Datagridview
            {
                presupuestos[dataGridView1.SelectedRows[0].Index].Habilitado = false;
                //
                int idPresupuesto = (int)dataGridView1.SelectedRows[0].Cells["PresupuestoId"].Value;
                //
                FixamoContext context = new FixamoContext();
                Clases.Presupuesto presupuestosSeleccionado = context.Presupuestos.Find(idPresupuesto);
                presupuestosSeleccionado.Habilitado = false;
                context.SaveChanges();
                //
                /*dataGridView1.CurrentCell = null;
                dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Visible = false;*/
                cargarDataGrid();
            }
        }
    }
}
