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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Clases.Usuario validarExistenciaUsuario(FixamoContext context)
        {
            Clases.Usuario user = context.Usuarios.Where(u => u.Nombre == nombre.Text).FirstOrDefault();
            if (user == null)
                throw new Exception("El usuario no existe");
            else
                return user;
        }

        private void validarContraseña(Clases.Usuario usuarioAct,string contraseñaIngresada)
        {
            if (usuarioAct.Contraseña != contraseñaIngresada)
                throw new Exception("La contraseña ingresada es incorrecta");
        }

        private void validarUsuarioHabilitado(Clases.Usuario usuarioAct)
        {
            if (!(usuarioAct.Habilitado))
                throw new Exception("El usuario esta deshabilitado");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FixamoContext context = new FixamoContext();
                /*Clases.Usuario newUsuario = new Clases.Usuario();
                newUsuario.Nombre = "ADM";
                newUsuario.Contraseña = "1234";
                context.Usuarios.Add(newUsuario);
                context.SaveChanges();*/
                Clases.Usuario usuarioAct = validarExistenciaUsuario(context);
                validarContraseña(usuarioAct, contraseña.Text);
                validarUsuarioHabilitado(usuarioAct);
                Clases.Session.getInstance().userId = usuarioAct.UsuarioId;
                Clases.Session.getInstance().user = usuarioAct.Nombre;
                this.Visible = false;
                Form1 pantallaPrincipal = new Form1();
                pantallaPrincipal.ShowDialog();
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
    }
}
