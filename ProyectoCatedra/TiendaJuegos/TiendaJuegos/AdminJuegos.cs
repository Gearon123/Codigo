using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaJuegos
{
    public partial class AdminJuegos : Form
    {
        private SqlConnection conexion;
      
        public AdminJuegos()
        {
            InitializeComponent();
            // Inicializa la conexión a la base de datos
            conexion = new SqlConnection("Data Source=localhost;Initial Catalog=tiendaJuegos;Integrated Security=True");
            
        }
        private bool ValidarEntrada()
        {
            // Validar nombre, categoría, descripción, precio, etc.
            if (string.IsNullOrEmpty(txtNombre.Text) || !Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z0-9\s]{1,50}$"))
            {
                MessageBox.Show("Ingrese un nombre válido (hasta 50 caracteres alfanuméricos y espacios).");
                return false;
            }

            if (string.IsNullOrEmpty(txtCategoria.Text) || !Regex.IsMatch(txtCategoria.Text, @"^[a-zA-Z0-9\s]{1,50}$"))
            {
                MessageBox.Show("Ingrese una categoría válida (hasta 50 caracteres alfanuméricos y espacios).");
                return false;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text) || !Regex.IsMatch(txtDescripcion.Text, @"^[a-zA-Z0-9\s]{1,1000}$"))
            {
                MessageBox.Show("Ingrese una descripción válida (hasta 1000 caracteres alfanuméricos y espacios).");
                return false;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio válido.");
                return false;
            }

            return true;
        }
        private bool ExisteID(int id)
        {
            using (SqlConnection conexion = ObtenerConexionAbierta())
            {
                string consulta = "SELECT COUNT(*) FROM dimJuegos WHERE id=@id";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    int count = (int)comando.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private SqlConnection ObtenerConexionAbierta()
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=tiendaJuegos;Integrated Security=True");
            connection.Open();
            return connection;
        }

        private void AgregarJuego(int id, string nombre, string categoria, string descripcion, decimal precio)
        {
            if (ExisteID(id))
            {
                MessageBox.Show("El ID ya está registrado. Debe ser diferente.");
                return;
            }

            using (SqlConnection conexion = ObtenerConexionAbierta())
            {
                string consulta = "INSERT INTO dimJuegos (id, nombre, categoria, descripcion, precio) VALUES (@id, @nombre, @categoria, @descripcion, @precio)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@categoria", categoria);
                    comando.Parameters.AddWithValue("@descripcion", descripcion);
                    comando.Parameters.AddWithValue("@precio", precio);

                    comando.ExecuteNonQuery();
                }
            }
        }
        private void ModificarJuego(int id, string nombre, string categoria, string descripcion, decimal precio)
        {
            if (!ExisteID(id))
            {
                MessageBox.Show("El ID no está registrado. No se puede modificar.");
                return;
            }

            using (SqlConnection conexion = ObtenerConexionAbierta())
            {
                string consulta = "UPDATE dimJuegos SET nombre=@nombre, categoria=@categoria, descripcion=@descripcion, precio=@precio WHERE id=@id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@categoria", categoria);
                    comando.Parameters.AddWithValue("@descripcion", descripcion);
                    comando.Parameters.AddWithValue("@precio", precio);

                    comando.ExecuteNonQuery();
                }
            }
        }
        private void EliminarJuego(int id)
        {
            if (!ExisteID(id))
            {
                MessageBox.Show("El ID no está registrado. No se puede eliminar.");
                return;
            }

            using (SqlConnection conexion = ObtenerConexionAbierta())
            {
                string consulta = "DELETE FROM dimJuegos WHERE id=@id";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);

                    comando.ExecuteNonQuery();
                }
            }
        }
        private void ListarJuegos(SqlConnection conexion)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT id, nombre, categoria, descripcion, precio FROM dimJuegos", conexion);
            DataSet datos = new DataSet();
            adaptador.Fill(datos);
            dgvlistadojuegos.DataSource = datos.Tables[0];
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntrada())
            {
                return;
            }

            int id;
            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("El ID debe ser un número.");
                return;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            AgregarJuego(id, txtNombre.Text, txtCategoria.Text, txtDescripcion.Text, precio);

            conexion.Close();
            ListarJuegos(conexion);

           

            // Limpiar cuadros de texto
            txtID.Text = "";
            txtNombre.Text = "";
            txtCategoria.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntrada())
            {
                return;
            }

            int id;
            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("El ID debe ser un número.");
                return;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            ModificarJuego(id, txtNombre.Text, txtCategoria.Text, txtDescripcion.Text, precio);

            conexion.Close();
            ListarJuegos(conexion);

           

            // Limpiar cuadros de texto
            txtID.Text = "";
            txtNombre.Text = "";
            txtCategoria.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("Por favor, ingrese el ID que desea eliminar");
                return;
            }

            EliminarJuego(id);

            conexion.Close();
            ListarJuegos(conexion);

            

            // Limpiar cuadros de texto
            txtID.Text = "";
            txtNombre.Text = "";
            txtCategoria.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
        private void AdminJuegos_Load(object sender, EventArgs e)
        {
            conexion = new SqlConnection("Data Source=localhost;Initial Catalog=tiendaJuegos;Integrated Security=True");
            ListarJuegos(conexion);
        }
        private void btnvolvermenu_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de confirmación
            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas volver al menú anterior?", "Confirmar Volver", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar la respuesta del usuario
            if (resultado == DialogResult.Yes)
            {
                // Cerrar el formulario actual (AdminJuegos)
                this.Close();
            }
            // Si el usuario elige No, no hacemos nada y permanecemos en el formulario actual
        }
    }
}
