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
    public partial class RegistroClientes : Form
    {
        private SqlConnection conexion;
        public RegistroClientes()
        {
            InitializeComponent();
            conexion = new SqlConnection("Data Source=localhost;Initial Catalog=tiendaJuegos;Integrated Security=True");
        }
        private bool ValidarEntrada()
        {
            // Validar nombre, apellidos, usuario, correo, contrasena, etc.
            if (string.IsNullOrEmpty(txtUsuarioC.Text) || txtUsuarioC.Text.Contains(" "))
            {
                MessageBox.Show("Ingrese un nombre de usuario válido (sin espacios).");
                return false;
            }

            if (string.IsNullOrEmpty(txtNombreC.Text) || !Regex.IsMatch(txtNombreC.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("Ingrese un nombre válido (sin números ni caracteres especiales, excepto tildes y ñ).");
                return false;
            }

            if (string.IsNullOrEmpty(txtApellidoC.Text) || !Regex.IsMatch(txtApellidoC.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("Ingrese un apellido válido (sin números ni caracteres especiales, excepto tildes y ñ).");
                return false;
            }
            // Validar campos de entrada
            if (string.IsNullOrEmpty(txtUsuarioC.Text) || string.IsNullOrEmpty(txtNombreC.Text) || string.IsNullOrEmpty(txtApellidoC.Text) || string.IsNullOrEmpty(txtCorreoC.Text) || string.IsNullOrEmpty(txtContraC.Text))
            {
                MessageBox.Show("Los campos no pueden estar vacíos.");
                return false;
            }

            // Validar formato del correo electrónico
            if (!EsFormatoCorreoValido(txtCorreoC.Text))
            {
                MessageBox.Show("Por favor, ingresa una dirección de correo electrónico válida. El formato debe ser 'nombre@dominio.com'. Asegúrate de incluir un nombre de usuario seguido de '@' y el nombre de dominio, como 'ejemplo@dominio.com'.");
                return false;
            }

            return true;
        }
        private bool EsFormatoCorreoValido(string correo)
        {
            // Utilizar una expresión regular para validar el formato del correo electrónico
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patronCorreo);
        }
        private bool EsContraseñaFuerte(string contraseña)
        {
            // Validar que la contraseña tenga al menos 8 caracteres
            if (contraseña.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.");
                return false;
            }

            // Validar que la contraseña contenga al menos un número
            if (!contraseña.Any(char.IsDigit))
            {
                MessageBox.Show("La contraseña debe contener al menos un número.");
                return false;
            }

            // Validar que la contraseña contenga al menos un carácter especial
            if (!contraseña.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("La contraseña debe contener al menos un carácter especial.");
                return false;
            }

            // La contraseña cumple con los requisitos
            return true;
        }
        private bool ExisteUsuario(string usuario)
        {
            using (SqlConnection conexion = ObtenerConexionAbierta())
            {
                string consulta = "SELECT COUNT(*) FROM dimCliente WHERE usuario=@usuario";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    int count = (int)comando.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool ExisteCorreo(string correo)
        {
            using (SqlConnection conexion = ObtenerConexionAbierta())
            {
                string consulta = "SELECT COUNT(*) FROM dimCliente WHERE correo=@correo";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@correo", correo);
                    int count = (int)comando.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void RegistrarUsuario(string usuario, string nombre, string apellido, string correo, string contrasena)
        {
            // Registra un usuario en la base de datos
            using (SqlConnection conexion = ObtenerConexionAbierta())
            {
                string consulta = "INSERT INTO dimCliente (usuario, nombres, apellidos, correo, contrasena) VALUES (@usuario, @nombre, @apellido, @correo, @contrasena)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@apellido", apellido);
                    comando.Parameters.AddWithValue("@correo", correo);
                    comando.Parameters.AddWithValue("@contrasena", contrasena);

                    comando.ExecuteNonQuery();
                }
            }
        }
        private SqlConnection ObtenerConexionAbierta()
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=tiendaJuegos;Integrated Security=True");
            connection.Open();
            return connection;
        }
        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntrada())
            {
                return;
            }

            // Validar la fortaleza de la contraseña
            if (!EsContraseñaFuerte(txtContraC.Text))
            {
                return;
            }

            // Verificar si el usuario ya existe
            if (ExisteUsuario(txtUsuarioC.Text))
            {
                MessageBox.Show("El usuario que ingresaste ya está en uso. Por favor, elige otro nombre de usuario.");
                return;
            }

            // Verificar si el correo ya está en uso
            if (ExisteCorreo(txtCorreoC.Text))
            {
                MessageBox.Show("El correo que ingresaste ya está en uso. Por favor, utiliza otro correo electrónico.");
                return;
            }

            // Hash de la contraseña (ejemplo: SHA-256)
            string contrasenaHash = ObtenerHash(txtContraC.Text);

            // Registrar el usuario en la base de datos
            try
            {
                conexion.Open();
                RegistrarUsuario(txtUsuarioC.Text, txtNombreC.Text, txtApellidoC.Text, txtCorreoC.Text, contrasenaHash);
                MessageBox.Show("El usuario se ha registrado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            this.Close();
        }
        private string ObtenerHash(string input)
        {
            // Este método debería ser reemplazado por un algoritmo de hash seguro en un entorno de producción
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

    }
}
