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
    public partial class AMSolicitantes : Form
    {
        private Clases.Solicitante solicitante = null;
        public AMSolicitantes()
        {
            InitializeComponent();
        }

        public AMSolicitantes(Clases.Solicitante solicitanteP)
        {
            InitializeComponent();
            solicitante = solicitanteP;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validarDatos()
        {
            if ((string.IsNullOrEmpty(nombreAgregar.Text)) || (string.IsNullOrEmpty(nombreOficina.Text)))
                throw new Exception("Por Favor, completar datos obligatorios");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                validarDatos();
                FixamoContext context = new FixamoContext();
                if (solicitante == null)
                {
                    Clases.Solicitante newSolicitante = new Clases.Solicitante();
                    newSolicitante.Nombre = nombreAgregar.Text;
                    newSolicitante.NombreOficina = nombreOficina.Text;
                    if (!(string.IsNullOrEmpty(telefono.Text)))
                        newSolicitante.Telefono = telefono.Text;
                    if (!(string.IsNullOrEmpty(email.Text)))
                        newSolicitante.Email = email.Text;
                    if (!(string.IsNullOrEmpty(cuit.Text)))
                        newSolicitante.Cuit = cuit.Text;
                    if (!(string.IsNullOrEmpty(razonSoc.Text)))
                        newSolicitante.RazonSoc = razonSoc.Text;
                    newSolicitante.Exento = exento.Checked;

                    context.Solicitantes.Add(newSolicitante);
                }
                else
                {
                    Clases.Solicitante newSolicitante = context.Solicitantes.Find(solicitante.SolicitanteId);
                    newSolicitante.Nombre = nombreAgregar.Text;
                    newSolicitante.NombreOficina = nombreOficina.Text;
                    if (!(string.IsNullOrEmpty(telefono.Text)))
                        newSolicitante.Telefono = telefono.Text;
                    if (!(string.IsNullOrEmpty(email.Text)))
                        newSolicitante.Email = email.Text;
                    if (!(string.IsNullOrEmpty(cuit.Text)))
                        newSolicitante.Cuit = cuit.Text;
                    if (!(string.IsNullOrEmpty(razonSoc.Text)))
                        newSolicitante.RazonSoc = razonSoc.Text;
                    newSolicitante.Exento = exento.Checked;
                }
                context.SaveChanges();

                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void AMOrganizaciones_Load(object sender, EventArgs e)
        {
            if (solicitante != null)
            {
                nombreAgregar.Text = solicitante.Nombre;
                nombreOficina.Text = solicitante.NombreOficina;
                telefono.Text = solicitante.Telefono;
                email.Text = solicitante.Email;
                cuit.Text = solicitante.Cuit;
                razonSoc.Text = solicitante.RazonSoc;
                exento.Checked = solicitante.Exento;
            }
        }
    }
}
