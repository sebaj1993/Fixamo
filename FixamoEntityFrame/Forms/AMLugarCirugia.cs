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
    public partial class AMLugarCirugia : Form
    {
        private Clases.LugarCirugia lugarCirugia = null;
        public AMLugarCirugia()
        {
            InitializeComponent();
        }

        public AMLugarCirugia(Clases.LugarCirugia lugarCirugiaP)
        {
            InitializeComponent();
            lugarCirugia = lugarCirugiaP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AMLugarCirugia_Load(object sender, EventArgs e)
        {
            if (lugarCirugia != null)
            {
                nombre.Text = lugarCirugia.Nombre;
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
            if (lugarCirugia == null)
            {
                Clases.LugarCirugia newLugarCirugia = new Clases.LugarCirugia();
                newLugarCirugia.Nombre = nombre.Text;

                context.LugaresCirugias.Add(newLugarCirugia);
            }
            else
            {
                Clases.LugarCirugia newLugarCirugia = context.LugaresCirugias.Find(lugarCirugia.LugarCirugiaId);
                newLugarCirugia.Nombre = nombre.Text;
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
