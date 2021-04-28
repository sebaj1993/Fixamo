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
    public partial class AMLineaPresupuesto : Form
    {
        private Clases.LineaPresupuesto linea = null;
        public AMLineaPresupuesto()
        {
            InitializeComponent();
        }

        public AMLineaPresupuesto(Clases.LineaPresupuesto lineaP)
        {
            InitializeComponent();
            linea = lineaP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AMLineaPresupuesto_Load(object sender, EventArgs e)
        {
            if(linea != null)
            {
                cantidad.Text = linea.Cantidad.ToString();
                descripcion.Text = linea.Descripcion;
                valor.Text = linea.Precio.ToString();
            }
        }

        private void validarDatos()
        {
            if ((string.IsNullOrEmpty(cantidad.Text))|| (string.IsNullOrEmpty(descripcion.Text)) || (string.IsNullOrEmpty(valor.Text)))
                throw new Exception("Por favor, complete todos los datos.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatos();
                linea = new Clases.LineaPresupuesto();
                linea.Cantidad = int.Parse(cantidad.Text);
                linea.Descripcion = descripcion.Text;
                linea.Precio = Convert.ToDouble(valor.Text);
                //
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public Clases.LineaPresupuesto obtenerLineaPresupuesto()
        {
            return this.linea;
        }

        private void cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void totCIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                e.Handled = true;
                valor.Text += ",";
                valor.Select(valor.Text.Length, 0); //Posiciono el cursor al final del textbox
            }
            if (e.KeyChar == 44)
            {
                e.Handled = false;
                return;
            }
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
