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
    public partial class AMCondicionesDePago : Form
    {
        private Clases.CondicionPago condicionPago = null;
        public AMCondicionesDePago()
        {
            InitializeComponent();
        }

        public AMCondicionesDePago(Clases.CondicionPago condicionPagoP)
        {
            InitializeComponent();
            condicionPago = condicionPagoP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (condicionPago == null)
                {
                    Clases.CondicionPago newCondicionDePago = new Clases.CondicionPago();
                    newCondicionDePago.Nombre = nombre.Text;

                    context.CondicionesDePago.Add(newCondicionDePago);
                }
                else
                {
                    Clases.CondicionPago newCondicionDePago = context.CondicionesDePago.Find(condicionPago.CondicionPagoId);
                    newCondicionDePago.Nombre = nombre.Text;
                }
                context.SaveChanges();

                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void AMCondicionesDePago_Load(object sender, EventArgs e)
        {
            if (condicionPago != null)
            {
                nombre.Text = condicionPago.Nombre;
            }
        }
    }
}
