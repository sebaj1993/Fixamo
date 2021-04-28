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
    public partial class AMUsuarios : Form
    {
        private Clases.Usuario usuario = null;
        public AMUsuarios()
        {
            InitializeComponent();
        }

        public AMUsuarios(Clases.Usuario usuarioP)
        {
            InitializeComponent();
            usuario = usuarioP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AMUsuarios_Load(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                nombre.Text = usuario.Nombre;
                contraseña.Text = usuario.Contraseña;
                email.Text = usuario.Email;
                telefono.Text = usuario.Telefono;
            }
        }

        private void validarDatos()
        {
            if ((string.IsNullOrEmpty(nombre.Text))||((string.IsNullOrEmpty(contraseña.Text))))
                throw new Exception("Por favor, complete todos los datos.");
            else if((contraseña.Text.Length < 5)||(contraseña.Text.Length > 10))
                throw new Exception("Por favor, la contraseña debe ser entre 5 y 10 caracteres.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatos();
                FixamoContext context = new FixamoContext();
                if (usuario == null)
                {
                    Clases.Usuario newUsuario = new Clases.Usuario();
                    newUsuario.Nombre = nombre.Text;
                    newUsuario.Contraseña = contraseña.Text;
                    if(!(string.IsNullOrEmpty(email.Text)))
                        newUsuario.Email = email.Text;
                    if (!(string.IsNullOrEmpty(telefono.Text)))
                        newUsuario.Telefono = telefono.Text;

                    context.Usuarios.Add(newUsuario);
                }
                else
                {
                    Clases.Usuario newUsuario = context.Usuarios.Find(usuario.UsuarioId);
                    newUsuario.Nombre = nombre.Text;
                    newUsuario.Contraseña = contraseña.Text;
                    if (!(string.IsNullOrEmpty(email.Text)))
                        newUsuario.Email = email.Text;
                    if (!(string.IsNullOrEmpty(telefono.Text)))
                        newUsuario.Telefono = telefono.Text;
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
