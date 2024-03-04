using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCatedraPOO.ultilidades;
using CapaEntidad;
using CapaNegocio;  

namespace ProyectoCatedraPOO
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtContra2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cdbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cdbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Usuario objUsuario = new Usuario()
            {

                IdUsuario = Convert.ToInt32(txtID.Text),
                documento = txtUser.Text,
                NombreCompleto = txtNombre.Text,
                Correo = txtCorreo.Text,
                Clave = txtContra.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((combo)cdbRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((combo)cdbEstado.SelectedItem).Valor) == 1 ? true : false,
            };
            //si es 0 esta creando un usuario
            if (objUsuario.IdUsuario == 0)
            {
                int idusuariogenerado = new CN_Usuario().Registrar(objUsuario, out Mensaje);
                if (idusuariogenerado != 0)
                {


                    dgvData.Rows.Add(new object[] {"",idusuariogenerado,txtUser.Text,txtNombre.Text,txtCorreo.Text,txtContra.Text,
                ((combo)cdbRol.SelectedItem).Valor.ToString(),
                ((combo)cdbRol.SelectedItem).texto.ToString(),
                ((combo)cdbEstado.SelectedItem).Valor.ToString(),
                ((combo)cdbEstado.SelectedItem).texto.ToString()
                });
                    limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
            else
            {

                bool res = new CN_Usuario().Editar(objUsuario, out Mensaje);
                if (res)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["IdUsuario"].Value= txtID.Text;
                    row.Cells["Usuario"].Value= txtUser.Text;
                    row.Cells["NombreCompleto"].Value= txtNombre.Text;
                    row.Cells["Correo"].Value= txtCorreo.Text;
                    row.Cells["Clave"].Value= txtContra.Text;
                    row.Cells["IdRol"].Value= ((combo)cdbRol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value= ((combo)cdbRol.SelectedItem).texto.ToString();
                    row.Cells["EstadoValor"].Value= ((combo)cdbEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value= ((combo)cdbEstado.SelectedItem).texto.ToString();
                    limpiar();

                }
                else { MessageBox.Show(Mensaje); }
            }



        }
        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtID.Text = "0";
            txtUser.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtContra.Text = "";
            txtContra2.Text = "";
            cdbRol.SelectedIndex = 0;
            cdbEstado.SelectedIndex = 0;
            txtUser.Select();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtID.Text) != 0)
            {
                if (MessageBox.Show("desea eliminar el usuario??", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje= string.Empty;
                    Usuario objUsuario = new Usuario()
                    {

                        IdUsuario = Convert.ToInt32(txtID.Text),
                    };
                    bool resp = new CN_Usuario().Elimnar(objUsuario,out Mensaje);
                    if (resp)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje,"Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {

            cdbEstado.Items.Add(new combo() {Valor = 1, texto="Activo" });
            cdbEstado.Items.Add(new combo() {Valor = 0, texto="No activo" });
            cdbEstado.DisplayMember = "texto";
            cdbEstado.ValueMember = "Valor";
            cdbEstado.SelectedIndex = 0;

            List < Rol > listarRol= new CN_Rol().listar();

            foreach ( Rol item in listarRol)
            {
                cdbRol.Items.Add(new combo() { Valor = item.IdRol, texto = item.descripcion }) ;
            }
            cdbRol.DisplayMember = "texto";
            cdbRol.ValueMember = "Valor";
            cdbRol.SelectedIndex = 0;


            //mostrar los datos en el data
            List<Usuario> listarUsuario = new CN_Usuario().listar();

            foreach (Usuario item in listarUsuario)
            {
                dgvData.Rows.Add(new object[] {"",item.IdUsuario,item.documento,item.NombreCompleto,item.Correo,item.Clave,
            item.oRol.IdRol,
            item.oRol.descripcion,
            item.Estado==true ?1 :0,
            item.Estado== true ? "Activo" :"No Activo"
            }) ;
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex <0)
                return;

            if(e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w= Properties.Resources._new.Width;
                var h= Properties.Resources._new.Height;
                var x= e.CellBounds.Left +(e.CellBounds.Width-w)/2;
                var y= e.CellBounds.Top +(e.CellBounds.Height-h)/2;

                e.Graphics.DrawImage(Properties.Resources._new, new Rectangle(x,y,w,h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name== "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if(indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = dgvData.Rows[indice].Cells["IdUsuario"].Value.ToString();
                    txtUser.Text = dgvData.Rows[indice].Cells["Usuario"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvData.Rows[indice].Cells["Correo"].Value.ToString();
                    txtContra.Text = dgvData.Rows[indice].Cells["Clave"].Value.ToString();
                    txtContra2.Text = dgvData.Rows[indice].Cells["Clave"].Value.ToString();
                    
                    foreach(combo oc in cdbRol.Items)
                    {
                        if(Convert.ToInt32( oc.Valor)== Convert.ToInt32(dgvData.Rows[indice].Cells["IdRol"].Value)){
                            int indice_combo = cdbRol.Items.IndexOf(oc);
                            cdbRol.SelectedIndex = indice_combo;
                            break;
                        }
                    }                    
                    foreach(combo oc in cdbEstado.Items)
                    {
                        if(Convert.ToInt32( oc.Valor)== Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value)){
                            int indice_combo = cdbEstado.Items.IndexOf(oc);
                            cdbEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar sesion???", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Form1 form = new Form1(null);
                form.Show();
                Login login = new Login();
                login.Show();
            }
        }
    }
}
