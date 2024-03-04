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
    public partial class MiCuenta : Form
    {
        public MiCuenta()
        {
            InitializeComponent();
        }

        private void btnvolverM_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas volver al menú anterior?", "Confirmar Volver", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar la respuesta del usuario
            if (resultado == DialogResult.Yes)
            {
                // Cerrar el formulario actual (ComprarJuegos)
                this.Hide(); // Ocultar el formulario actual

                // Mostrar el formulario de MenuClientes
                MenuClientes menuClientesForm = new MenuClientes();
                menuClientesForm.Show();
            }
        }
    }
}
