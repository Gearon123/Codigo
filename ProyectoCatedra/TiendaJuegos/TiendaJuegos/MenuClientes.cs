using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaJuegos
{
    public partial class MenuClientes : Form
    {
        public MenuClientes()
        {
            InitializeComponent();
        }
        private void btncerrarcuentaC_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Cerrar el formulario actual
                this.Close();

                // Mostrar el formulario de inicio de sesión
                Login login = new Login();
                login.Show();
            }
        }

        private void btnrealizarcompra_Click(object sender, EventArgs e)
        {
            ComprarJuegos comprarJuegosForm = new ComprarJuegos();

            // Mostrar el formulario ComprarJuegos
            comprarJuegosForm.Show();

            // Cerrar el formulario actual
            this.Close();
        }

        private void btnverC_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario actual (MenuClientes)
            this.Hide();

            // Mostrar el formulario de MiCuenta
            MiCuenta miCuentaForm = new MiCuenta();
            miCuentaForm.Show();
        }
    }
}
