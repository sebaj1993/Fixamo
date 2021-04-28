using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixamoEntityFrame
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void button4_Click(object sender, EventArgs e)
        {
            Forms.AdministracionPlazosDeEntrega formPlazosDeEntrega = new Forms.AdministracionPlazosDeEntrega();
            formPlazosDeEntrega.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Forms.Doctores formDoctores = new Forms.Doctores();
            validarUser(formDoctores);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Forms.Pacientes formPacientes = new Forms.Pacientes();
            validarUser(formPacientes);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Forms.LugaresCirugias formLugaresCirugias = new Forms.LugaresCirugias();
            validarUser(formLugaresCirugias);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Forms.Solicitantes formOrganizaciones = new Forms.Solicitantes();
            validarUser(formOrganizaciones);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Forms.AdministracionUsuarios formADMUsuarios = new Forms.AdministracionUsuarios();
            formADMUsuarios.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.CrearPresupuesto formCrearPresup = new Forms.CrearPresupuesto();
            validarUser(formCrearPresup);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Forms.Configuracion formConfig = new Forms.Configuracion();
            formConfig.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FixamoContext context = new FixamoContext();
            List<Clases.Presupuesto> presupuestos = context.Presupuestos.ToList();
            Forms.VerPresupuestos formPresupuestos = new Forms.VerPresupuestos(presupuestos);
            validarUser(formPresupuestos);
        }



        /*private void button1_Click(object sender, EventArgs e)
        {
            List<Clases.Presupuesto> presupuestos;

            Clases.Paciente paciente = new Clases.Paciente();
            paciente.Nombre = "Maxi";
            paciente.NroAfiliado = "65458";

            Clases.Doctor doc = new Clases.Doctor();
            doc.Nombre = "abel";

            Clases.Presupuesto presupuesto = new Clases.Presupuesto();
            presupuesto.FechaCirugia = new DateTime(2009, 6, 9);
            presupuesto.FechaPresupuesto = new DateTime(2009, 6, 10);
            presupuesto.NroFactura = "1234";
            presupuesto.NroPresupuesto = "abc";
            presupuesto.Usuario = "aleRoberto";
            presupuesto.Paciente = paciente;
            presupuesto.Doctor = doc;


            FixamoContext context = new FixamoContext();
            context.Presupuestos.Add(presupuesto);
            context.SaveChanges();

            presupuestos = context.Presupuestos.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clases.Paciente paciente2 = new Clases.Paciente();
            paciente2.Nombre = "totito";
            paciente2.NroAfiliado = "9576";

            FixamoContext context = new FixamoContext();

            Clases.Presupuesto presupuesto;
            presupuesto = context.Presupuestos.Where(p => p.NroFactura == "1234").First();
            presupuesto.Paciente = paciente2;

            context.SaveChanges();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clases.Doctor doc = new Clases.Doctor();
            doc.Nombre = "abel";

            FixamoContext context = new FixamoContext();

            List<Clases.Presupuesto> presupuestos = context.Presupuestos.ToList();

            /*Clases.Presupuesto presupuesto;
            presupuesto = context.Presupuestos.Where(p => p.NroFactura == "1234").First();
            presupuesto.Doctor = doc;

            context.SaveChanges();
        }*/
    }
}
