using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp3.presentacion;
using WinFormsApp2;

namespace WindowsFormsApp3
{
    public partial class FrmLogin : Form
    {
        EntidadLogin objEntidad;
        NegocioLogin objNegocio;


        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            //"Data Source=localhost,64930;Initial Catalog=Senati;User ID=sa;Password=***********"
            //"Data Source=DESKTOP-VLV57I9\\SQLEXPRESS;Initial Catalog=Senati;Integrated Security=True";
            objEntidad = new EntidadLogin();
            objNegocio = new NegocioLogin();

        }
        void Login()//Creando un procedimiento.
        {
            Connection.Singleton.ConnetionString = txtConeccion.Text;
            objEntidad.Usuario = txtUsuario.Text;
            objEntidad.Contrasenia = txtContrasenia.Text;

            DataTable tbl = objNegocio.LogonN(objEntidad);
            if (tbl == null) return;

            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("No coinciden Usuario y Contraseña \n Intentelo nuevamente",

                "Acceso al Sistema", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtContrasenia.Text = "";
                txtUsuario.Focus();
            }
            else
            {
                //MessageBox.Show("Bienvenido al Sistema", "Acceso al Sistema",
                //MessageBoxButtons.OK);
                //Ocultamos el formulario Login
                this.Hide();
                //Mostramos el MenuPrincipal
                FrmMenuPrincipal Frm = new FrmMenuPrincipal();
                Frm.Show();
              
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Close();
        }
    }
}
