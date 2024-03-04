using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaJuegos
{
    public partial class Login : Form
    {
        private SqlConnection conexion;
        public Login()
        {
            InitializeComponent();
            conexion = new SqlConnection("Data Source=localhost;Initial Catalog=tiendaJuegos;Integrated Security=True");
        }
        private void btniniciodesesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuarioL.Text;
            string contrasena = txtContrasenaL.Text;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.");
                return;
            }

            // Intentar iniciar sesión como Cliente
            if (IniciarSesionCliente(usuario, contrasena))
            {
                // Credenciales válidas como Cliente, abrir el formulario de MenuClientes
                MenuClientes menuClientes = new MenuClientes();
                menuClientes.Show();
                this.Hide(); // Ocultar el formulario de login
            }
            // Intentar iniciar sesión como Administrador
            else if (IniciarSesionAdmin(usuario, contrasena))
            {
                // Credenciales válidas como Administrador, abrir el formulario de MenuAdmin
                MenuAdmin menuAdmin = new MenuAdmin();
                menuAdmin.Show();
                this.Hide(); // Ocultar el formulario de login
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.");
            }
        }
        private bool IniciarSesionAdmin(string usuario, string contrasena)
        {
            using (SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=tiendaJuegos;Integrated Security=True"))
            {
                string consulta = "SELECT contrasena FROM dimAdmins WHERE usuario=@usuario";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        // Obtener la contraseña almacenada
                        string contrasenaAlmacenada = reader["contrasena"].ToString();

                        // Comparar directamente, sin usar hash
                        return contrasena == contrasenaAlmacenada;
                    }

                    return false;
                }
            }
        }
        private bool IniciarSesionCliente(string usuario, string contrasena)
        {
            using (SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=tiendaJuegos;Integrated Security=True"))
            {
                string consulta = "SELECT contrasena FROM dimCliente WHERE usuario=@usuario";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        string contrasenaAlmacenada = reader["contrasena"].ToString();

                        // Verificar la contraseña ingresada comparándola con la almacenada
                        return VerificarContrasena(contrasena, contrasenaAlmacenada);
                    }

                    return false;
                }
            }
        }
        private bool VerificarContrasena(string contrasenaIngresada, string contrasenaAlmacenada)
        {
            // Puedes utilizar un método de hash aquí (por ejemplo, SHA-256)
            // Este es solo un ejemplo básico, la implementación real dependerá del algoritmo que utilices para almacenar contraseñas
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasenaIngresada));

                // Convertir el hash a una representación en cadena para comparar con la contraseña almacenada
                string hashIngresado = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                // Comparar el hash de la contraseña ingresada con el hash almacenado
                return string.Equals(hashIngresado, contrasenaAlmacenada, StringComparison.OrdinalIgnoreCase);
            }
        }
            private void btnregistrarcuenta_Click(object sender, EventArgs e)
        {
            
            // Abrir el formulario de registro
            RegistroClientes registro = new RegistroClientes();
            registro.Show();     
        }
    }
}
