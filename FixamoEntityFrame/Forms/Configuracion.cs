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
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void validarUser(Form formAMostrar)
        {
            if (Clases.Session.getInstance().user != "ADM")
                formAMostrar.ShowDialog();
            else
                MessageBox.Show("Siendo ADM no puede acceder a esta opción");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forms.AdministracionCondicionesDePago formCondicionesDePago = new Forms.AdministracionCondicionesDePago();
            validarUser(formCondicionesDePago);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Forms.AdministracionPlazosDeEntrega formPlazosDeEntrega = new Forms.AdministracionPlazosDeEntrega();
            validarUser(formPlazosDeEntrega);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Forms.AdministracionUsuarios formADMUsuarios = new Forms.AdministracionUsuarios();
            formADMUsuarios.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Forms.AdministrarProximoNroPresupuesto formProxNroPresup = new Forms.AdministrarProximoNroPresupuesto();
            validarUser(formProxNroPresup);
        }
    }
}
