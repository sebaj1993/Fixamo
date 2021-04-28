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
    public partial class AMPaciente : Form
    {
        private Clases.Paciente paciente = null;
        public AMPaciente()
        {
            InitializeComponent();
        }

        public AMPaciente(Clases.Paciente pacienteP)
        {
            InitializeComponent();
            paciente = pacienteP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AMPaciente_Load(object sender, EventArgs e)
        {
            if (paciente != null)
            {
                nombre.Text = paciente.Nombre;
                nroAfiliado.Text = paciente.NroAfiliado;
            }
        }

        private void validarDatos()
        {
            if (string.IsNullOrEmpty(nombre.Text))
                throw new Exception("Por favor, complete todos los datos.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatos();
                FixamoContext context = new FixamoContext();
                if (paciente == null)
                {
                    Clases.Paciente newPaciente = new Clases.Paciente();
                    newPaciente.Nombre = nombre.Text;
                    if (string.IsNullOrEmpty(nroAfiliado.Text))
                        newPaciente.NroAfiliado = null;
                    else
                        newPaciente.NroAfiliado = nroAfiliado.Text;

                    context.Pacientes.Add(newPaciente);
                }
                else
                {
                    Clases.Paciente newPaciente = context.Pacientes.Find(paciente.PacienteId);
                    newPaciente.Nombre = nombre.Text;
                    if (string.IsNullOrEmpty(nroAfiliado.Text))
                        newPaciente.NroAfiliado = null;
                    else
                        newPaciente.NroAfiliado = nroAfiliado.Text;
                }
                context.SaveChanges();

                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
