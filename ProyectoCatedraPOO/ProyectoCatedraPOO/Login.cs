using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using System.Data.SqlClient;

namespace ProyectoCatedraPOO
{
    public partial class Login : Form
    {
        private string connectionString = "Data Source=DESKTOP-MOAEUT3;Initial Catalog=tiendaJuegos;User ID=catedraPOO;Password=yourPassword;Integrated Security=False;";

        public Login()
        {
            InitializeComponent();
        }

        private void btniniciodesesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtPass.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM dimAdmins WHERE usuario = @usuario AND contrasena = @contrasena";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", usuario);
                        command.Parameters.AddWithValue("@contrasena", contraseña);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Inicio de sesión exitoso como administrador");
                            // Puedes abrir el siguiente formulario o realizar otras acciones aquí
                        }
                        else
                        {
                            query = "SELECT COUNT(*) FROM dimCliente WHERE usuario = @usuario AND contrasena = @contrasena";
                            command.CommandText = query;

                            count = Convert.ToInt32(command.ExecuteScalar());

                            if (count > 0)
                            {
                                MessageBox.Show("Inicio de sesión exitoso como cliente");
                                // Puedes abrir el siguiente formulario o realizar otras acciones aquí
                            }
                            else
                            {
                                MessageBox.Show("Credenciales incorrectas");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtUsuario.Text = "";
            txtPass.Text = "";
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Puedes realizar alguna configuración adicional al cargar el formulario
        }
    }
}
