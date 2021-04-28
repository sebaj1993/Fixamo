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
    public partial class CrearPresupuesto : Form
    {
        private List<Clases.Solicitante> solicitantes;
        private List<Clases.CondicionPago> condicionesDePago;
        private List<Clases.PlazoEntrega> plazosDeEntrega;
        private List<Clases.Doctor> doctores;
        private List<Clases.Paciente> pacientes;
        private List<Clases.LugarCirugia> lugaresCirugias;
        private List<Clases.LineaPresupuesto> lineasPresupuesto = new List<Clases.LineaPresupuesto>();
        public CrearPresupuesto()
        {
            InitializeComponent();
        }

        private void CrearPresupuesto_Load(object sender, EventArgs e)
        {
            cargarNroPresupuesto();
            cargarFechaPresupuesto();
            cargarSolicitantes();
            cargarFechaCirugia();
            cargarCondicionesDePago();
            cargarPlazosDeEntrega();
            cargarLineasPresupuesto();
            //
            cargarDoctores();
            cargarPacientes();
            cargarLugaresCirugias();
            //
            cargarMantenimientoDeOferta();
        }

        private void cargarMantenimientoDeOferta()
        {
            List<string> listaMantenimiento = new List<string>();
            listaMantenimiento.Add("24 hs.");
            listaMantenimiento.Add("48 hs.");
            listaMantenimiento.Add("72 hs.");
            listaMantenimiento.Add("96 hs.");
            //
            mantenimientoDeOferta.DataSource = null;
            //
            mantenimientoDeOferta.DataSource = listaMantenimiento;
            //
            mantenimientoDeOferta.AutoCompleteCustomSource = Clases.DataHelper.LoadAutoComplete(listaMantenimiento);
            mantenimientoDeOferta.AutoCompleteMode = AutoCompleteMode.Suggest;
            mantenimientoDeOferta.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //
            mantenimientoDeOferta.SelectedIndex = -1;
        }

        private void cargarNroPresupuesto()
        {
            FixamoContext context = new FixamoContext();
            Clases.Parametros parametro = context.Parametros.Where(p => p.NombreParametro == "ULTNROPRESUP").First();
            //
            nroPresupuesto.Text = (parametro.valor + 1).ToString();
        }

        private void cargarFechaPresupuesto()
        {
            fechaPresupuesto.Value = DateTime.Now;
        }

        private void cargarLugaresCirugias()
        {
            lugarCirugia.DataSource = null;
            //
            FixamoContext context = new FixamoContext();
            lugaresCirugias = context.LugaresCirugias.Where(s => s.Habilitado).ToList();
            //
            List<string> listaDeNombres = new List<string>();
            foreach (Clases.LugarCirugia lug in lugaresCirugias)
                listaDeNombres.Add(lug.Nombre);
            lugarCirugia.DataSource = listaDeNombres;
            //
            lugarCirugia.AutoCompleteCustomSource = Clases.DataHelper.LoadAutoComplete(listaDeNombres);
            lugarCirugia.AutoCompleteMode = AutoCompleteMode.Suggest;
            lugarCirugia.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //
            lugarCirugia.SelectedIndex = -1;
        }

        private void cargarPacientes()
        {
            paciente.DataSource = null;
            //
            FixamoContext context = new FixamoContext();
            pacientes = context.Pacientes.Where(s => s.Habilitado).ToList();
            //
            List<string> listaDeNombres = new List<string>();
            foreach (Clases.Paciente pac in pacientes)
                listaDeNombres.Add(pac.Nombre);
            paciente.DataSource = listaDeNombres;
            //
            paciente.AutoCompleteCustomSource = Clases.DataHelper.LoadAutoComplete(listaDeNombres);
            paciente.AutoCompleteMode = AutoCompleteMode.Suggest;
            paciente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //
            paciente.SelectedIndex = -1;
        }

        private void cargarDoctores()
        {
            doctor.DataSource = null;
            //
            FixamoContext context = new FixamoContext();
            doctores = context.Doctores.Where(s => s.Habilitado).ToList();
            //
            List<string> listaDeNombres = new List<string>();
            foreach (Clases.Doctor doc in doctores)
                listaDeNombres.Add(doc.Nombre);
            doctor.DataSource = listaDeNombres;
            //
            doctor.AutoCompleteCustomSource = Clases.DataHelper.LoadAutoComplete(listaDeNombres);
            doctor.AutoCompleteMode = AutoCompleteMode.Suggest;
            doctor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //
            doctor.SelectedIndex = -1;
        }

        private void cargarSolicitantes()
        {
            solicitante.DataSource = null;
            //
            FixamoContext context = new FixamoContext();
            solicitantes = context.Solicitantes.Where(s => s.Habilitado).ToList();
            //
            List<string> listaDeNombres = new List<string>();
            foreach (Clases.Solicitante solic in solicitantes)
                listaDeNombres.Add(solic.Nombre + " - " + solic.NombreOficina);
            solicitante.DataSource = listaDeNombres;
            //
            solicitante.AutoCompleteCustomSource = Clases.DataHelper.LoadAutoComplete(listaDeNombres);
            solicitante.AutoCompleteMode = AutoCompleteMode.Suggest;
            solicitante.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //
            solicitante.SelectedIndex = -1;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            Solicitantes formOrganizaciones = new Solicitantes();
            formOrganizaciones.ShowDialog();
            //
            this.cargarSolicitantes();
        }

        private void cargarFechaCirugia()
        {
            fechaCirugia.Value = DateTime.Now;
            //
            checkBoxFechaCirugia.Checked = true;
            checkBoxFechaCirugia.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctores formSeleccionarDoc = new Doctores();
            formSeleccionarDoc.ShowDialog();
            //
            cargarDoctores();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pacientes formSeleccionarPaciente = new Pacientes();
            formSeleccionarPaciente.ShowDialog();
            //
            cargarPacientes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LugaresCirugias formSeleccionarLugarDeCirugia = new LugaresCirugias();
            formSeleccionarLugarDeCirugia.ShowDialog();
            //
            cargarLugaresCirugias();
        }

        private void cargarCondicionesDePago()
        {
            condicionDePago.DataSource = null;
            //
            FixamoContext context = new FixamoContext();
            condicionesDePago = context.CondicionesDePago.Where(s => s.Habilitado).ToList();
            //
            List<string> listaDeNombres = new List<string>();
            foreach (Clases.CondicionPago condic in condicionesDePago)
                listaDeNombres.Add(condic.Nombre );
            condicionDePago.DataSource = listaDeNombres;
            //
            condicionDePago.AutoCompleteCustomSource = Clases.DataHelper.LoadAutoComplete(listaDeNombres);
            condicionDePago.AutoCompleteMode = AutoCompleteMode.Suggest;
            condicionDePago.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //
            condicionDePago.SelectedIndex = -1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdministracionCondicionesDePago formAgregarCondicionDePago = new AdministracionCondicionesDePago();
            formAgregarCondicionDePago.ShowDialog();
            //
            this.cargarCondicionesDePago();
        }

        private void cargarPlazosDeEntrega()
        {
            plazoDeEntrega.DataSource = null;
            //
            FixamoContext context = new FixamoContext();
            plazosDeEntrega = context.PlazosDeEntrega.Where(s => s.Habilitado).ToList();
            //
            List<string> listaDeNombres = new List<string>();
            foreach (Clases.PlazoEntrega plazo in plazosDeEntrega)
                listaDeNombres.Add(plazo.Nombre);
            plazoDeEntrega.DataSource = listaDeNombres;
            //
            plazoDeEntrega.AutoCompleteCustomSource = Clases.DataHelper.LoadAutoComplete(listaDeNombres);
            plazoDeEntrega.AutoCompleteMode = AutoCompleteMode.Suggest;
            plazoDeEntrega.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //
            plazoDeEntrega.SelectedIndex = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdministracionPlazosDeEntrega formAgregarPlazoDeEntrega = new AdministracionPlazosDeEntrega();
            formAgregarPlazoDeEntrega.ShowDialog();
            //
            this.cargarPlazosDeEntrega();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AMLineaPresupuesto formAgregarLineaPresup = new AMLineaPresupuesto();
            if(formAgregarLineaPresup.ShowDialog() == DialogResult.OK)
            {
                lineasPresupuesto.Add(formAgregarLineaPresup.obtenerLineaPresupuesto());
                cargarLineasPresupuesto();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                AMLineaPresupuesto formAgregarLineaPresup = new AMLineaPresupuesto(lineasPresupuesto[dataGridView1.CurrentRow.Index]);
                if (formAgregarLineaPresup.ShowDialog() == DialogResult.OK)
                {
                    lineasPresupuesto.Remove(lineasPresupuesto[dataGridView1.CurrentRow.Index]);
                    lineasPresupuesto.Add(formAgregarLineaPresup.obtenerLineaPresupuesto());
                    cargarLineasPresupuesto();
                }
            }
        }

        private void cargarLineasPresupuesto()
        {
            dataGridView1.DataSource = null;
            List<Clases.LineaPresupuesto> aux = lineasPresupuesto.ToList();
            dataGridView1.DataSource = aux;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatos();
                //
                Clases.Presupuesto newPresupuesto = new Clases.Presupuesto();
                //
                newPresupuesto.NroPresupuesto = int.Parse(nroPresupuesto.Text);
                newPresupuesto.FechaPresupuesto = fechaPresupuesto.Value;
                if (!(string.IsNullOrEmpty(nroFactura.Text)))
                    newPresupuesto.NroFactura = nroFactura.Text;
                if(checkBoxFechaCirugia.Checked)
                    newPresupuesto.FechaCirugia = fechaCirugia.Value;
                if (!(string.IsNullOrEmpty(nroPrestador.Text)))
                    newPresupuesto.Prestador = nroPrestador.Text;
                //
                if(!(string.IsNullOrEmpty(mantenimientoDeOferta.Text)))
                    newPresupuesto.MantenimientoDeOferta = mantenimientoDeOferta.Text;
                //
                if (solicitante.SelectedIndex >= 0)
                    newPresupuesto.SolicitanteId = solicitantes[solicitante.SelectedIndex].SolicitanteId;
                //
                if (paciente.SelectedIndex >= 0)
                    newPresupuesto.PacienteId = pacientes[paciente.SelectedIndex].PacienteId;
                if (doctor.SelectedIndex >= 0)
                    newPresupuesto.DoctorId = doctores[doctor.SelectedIndex].DoctorId;
                if (condicionDePago.SelectedIndex >= 0)
                    newPresupuesto.CondicionPagoId = condicionesDePago[condicionDePago.SelectedIndex].CondicionPagoId;
                if (plazoDeEntrega.SelectedIndex >= 0)
                    newPresupuesto.PlazoEntregaId = plazosDeEntrega[plazoDeEntrega.SelectedIndex].PlazoEntregaId;
                if (lugarCirugia.SelectedIndex >= 0)
                    newPresupuesto.LugarCirugiaId = lugaresCirugias[lugarCirugia.SelectedIndex].LugarCirugiaId;
                newPresupuesto.UsuarioId = Clases.Session.getInstance().userId;
                //
                foreach (Clases.LineaPresupuesto item in lineasPresupuesto)
                    newPresupuesto.LineasPresupuesto.Add(item);
                //
                FixamoContext context = new FixamoContext();
                context.Presupuestos.Add(newPresupuesto);
                Clases.Parametros parametro = context.Parametros.Where(p => p.NombreParametro == "ULTNROPRESUP").First();
                parametro.valor = newPresupuesto.NroPresupuesto;
                context.SaveChanges();
                //
                MessageBox.Show("El presupuesto ha sido guardado correctamente");
                context = new FixamoContext();
                context.Presupuestos.Find(newPresupuesto.PresupuestoId).imprimir();
                //
                this.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }   
        }

        private void validarDatos()
        {
            if ((solicitante.SelectedIndex == -1) || (string.IsNullOrEmpty(nroPresupuesto.Text)) || (lineasPresupuesto.Count == 0))
                throw new Exception("Por favor, complete como minimo un solicitante, nro de presupuesto y un item.");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Solicitantes formSolicitantes = new Solicitantes();
            formSolicitantes.ShowDialog();
            //
            this.cargarSolicitantes();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LugaresCirugias formLugaresCirugias = new LugaresCirugias();
            formLugaresCirugias.ShowDialog();
            //
            this.cargarLugaresCirugias();
        }

        private void checkBoxFechaCirugia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFechaCirugia.Checked)
                fechaCirugia.Enabled = true;
            else
                fechaCirugia.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                lineasPresupuesto.Remove(lineasPresupuesto[dataGridView1.CurrentRow.Index]);
                cargarLineasPresupuesto();
            }
        }
    }
}
