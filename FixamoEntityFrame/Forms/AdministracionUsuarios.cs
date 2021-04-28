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
    public partial class AdministracionUsuarios : Form
    {
        private List<Clases.Usuario> usuarios;
        public AdministracionUsuarios()
        {
            InitializeComponent();
        }

        private void validarUser()
        {
            if (Clases.Session.getInstance().user != "ADM")
                throw new Exception("El unico autorizado a administrar usuarios es ADM");

        }

        private void AdministracionUsuarios_Load(object sender, EventArgs e)
        {
            FixamoContext context = new FixamoContext();
            usuarios = context.Usuarios.Where(u => u.Habilitado).ToList();

            dataGridView1.DataSource = usuarios;

            dataGridView1.Columns["Contraseña"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validarUser();
                AMUsuarios formAmUsuarios = new AMUsuarios();
                formAmUsuarios.ShowDialog();
                //
                this.AdministracionUsuarios_Load(null, null);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                validarUser();
                AMUsuarios formAmUsuarios = new AMUsuarios(usuarios[dataGridView1.CurrentRow.Index]);
                formAmUsuarios.ShowDialog();
                //
                this.AdministracionUsuarios_Load(null, null);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                validarUser();
                if ((string)dataGridView1.SelectedRows[0].Cells["Nombre"].Value != "ADM")
                {
                    int idUser = (int)dataGridView1.SelectedRows[0].Cells["UsuarioId"].Value;
                    //
                    FixamoContext context = new FixamoContext();
                    Clases.Usuario usuarioSelec = context.Usuarios.Find(idUser);
                    usuarioSelec.Habilitado = false;
                    context.SaveChanges();
                    //
                    this.AdministracionUsuarios_Load(null, null);
                }
                else
                {
                    MessageBox.Show("No se puede dar de baja el usuario ADM");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
