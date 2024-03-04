using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;

namespace ProyectoCatedraPOO
{
    public partial class Form1 : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem menuActivo =null;
        public Form1(Usuario objusuario)
        {
            usuarioActual = objusuario;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button5.Visible = false;
            List<Permiso> ListaPermisos = new CN_Permiso().listar(usuarioActual.IdUsuario);


            if (Convert.ToInt32(usuarioActual.rol) == 1)
            {
                button1.Visible = true;
                button2.Visible = true;
                button5.Visible = true;
            }
            else if (Convert.ToInt32(usuarioActual.rol) == 2)
            {

                button5.Visible = true;
                button5.Location = new Point(114, 88);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMantenimiento frm = new FrmMantenimiento();
            frm.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            FrmCliente frm = new FrmCliente();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas(usuarioActual);
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.Show();
        }

        private void mante_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar sesion???", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }
    }
}
