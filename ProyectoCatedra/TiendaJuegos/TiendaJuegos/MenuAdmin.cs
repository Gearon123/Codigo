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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }
        private void btncerrarcuentaA_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de diálogo de confirmación
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
        private void btnaddjuegos_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual (MenuAdmin)
            this.Hide();

            // Mostrar el formulario AdminJuegos
            AdminJuegos adminJuegos = new AdminJuegos();
            adminJuegos.ShowDialog();

            // Volver a mostrar el formulario MenuAdmin después de cerrar AdminJuegos
            this.Show();
        }
    }
}
