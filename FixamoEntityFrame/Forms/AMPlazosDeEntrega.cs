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
    public partial class AMPlazosDeEntrega : Form
    {
        private Clases.PlazoEntrega plazoEntrega = null;
        public AMPlazosDeEntrega()
        {
            InitializeComponent();
        }

        public AMPlazosDeEntrega(Clases.PlazoEntrega plazoEntregaP)
        {
            InitializeComponent();
            plazoEntrega = plazoEntregaP;
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
            if (plazoEntrega == null)
            {
                Clases.PlazoEntrega newPlazoEntrega = new Clases.PlazoEntrega();
                newPlazoEntrega.Nombre = nombre.Text;

                context.PlazosDeEntrega.Add(newPlazoEntrega);
            }
            else
            {
                Clases.PlazoEntrega newPlazoEntrega = context.PlazosDeEntrega.Find(plazoEntrega.PlazoEntregaId);
                newPlazoEntrega.Nombre = nombre.Text;
            }
            context.SaveChanges();

            this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void AMPlazosDeEntrega_Load(object sender, EventArgs e)
        {
            if (plazoEntrega != null)
            {
                nombre.Text = plazoEntrega.Nombre;
            }
        }
    }
}
