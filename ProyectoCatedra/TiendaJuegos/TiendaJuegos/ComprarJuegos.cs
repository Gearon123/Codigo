using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaJuegos
{
    public partial class ComprarJuegos : Form
    {
        private SqlConnection conexion;
        public ComprarJuegos()
        {
            InitializeComponent();
            conexion = new SqlConnection("Data Source=localhost;Initial Catalog=tiendaJuegos;Integrated Security=True");
            // Carga los juegos disponibles
            CargarJuegosDisponibles();
        }
        private void btnvolver_Click(object sender, EventArgs e)
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

        private void ComprarJuegos_Load(object sender, EventArgs e)
        {
            CargarJuegosDisponibles();
        }

        private void CargarJuegosDisponibles()
        {
            // Obtiene la conexión a la base de datos
            using (SqlConnection conexion = ObtenerConexionAbierta())
            {
                // Listar los juegos
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT id, nombre, categoria, descripcion, precio FROM dimJuegos", conexion);
                DataSet datos = new DataSet();
                adaptador.Fill(datos);

                // Establecer los datos del datagridview
                dgvjuegosdisponibles.DataSource = datos.Tables[0];
            }
        }

        private SqlConnection ObtenerConexionAbierta()
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=tiendaJuegos;Integrated Security=True");
            connection.Open();
            return connection;
        }
    }
}
