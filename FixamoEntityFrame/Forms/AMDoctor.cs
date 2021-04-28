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
    public partial class AMDoctor : Form
    {
        private Clases.Doctor doctor = null;
        public AMDoctor()
        {
            InitializeComponent();
        }

        public AMDoctor(Clases.Doctor doctorP)
        {
            InitializeComponent();
            doctor = doctorP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AMDoctor_Load(object sender, EventArgs e)
        {
            if (doctor != null)
            {
                nombre.Text = doctor.Nombre;
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
            if (doctor == null)
            {
                Clases.Doctor newDoctor = new Clases.Doctor();
                newDoctor.Nombre = nombre.Text;

                context.Doctores.Add(newDoctor);
            }
            else
            {
                Clases.Doctor newDoctor = context.Doctores.Find(doctor.DoctorId);
                newDoctor.Nombre = nombre.Text;
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
