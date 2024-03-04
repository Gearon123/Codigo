using CapaEntidad;
using CapaNegocio;
using ProyectoCatedraPOO.ultilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCatedraPOO
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtContra2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cdbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cdbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtID.Text = "0";
            txtDescripcion.Text = "";
            txtDescripcion.Select();
        }
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            cdbEstado.Items.Add(new combo() { Valor = 1, texto = "Activo" });
            cdbEstado.Items.Add(new combo() { Valor = 0, texto = "No activo" });
            cdbEstado.DisplayMember = "texto";
            cdbEstado.ValueMember = "Valor";
            cdbEstado.SelectedIndex = 0;

            //mostrar los datos en el data
            List<Categoria> listar = new CN_Categoria().listar();

            foreach (Categoria item in listar)
            {
                dgvData.Rows.Add(new object[] {"",item.IdCategoria,
            item.Descripcion,
            item.Estado==true ?1 :0,

            item.Estado== true ? "Activo" :"No Activo"
            });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Categoria objCat = new Categoria()
            {

                IdCategoria = Convert.ToInt32(txtID.Text),
                Descripcion = txtDescripcion.Text,
                Estado = Convert.ToInt32(((combo)cdbEstado.SelectedItem).Valor) == 1 ? true : false,
            };
            //si es 0 esta creando un usuario
            if (objCat.IdCategoria == 0)
            {
                int idCategoriaGenerada = new CN_Categoria().Registrar(objCat, out Mensaje);
                if (idCategoriaGenerada != 0)
                {


                    dgvData.Rows.Add(new object[] {"",idCategoriaGenerada,txtDescripcion.Text,

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

                bool res = new CN_Categoria().Editar(objCat, out Mensaje);
                if (res)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtID.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["EstadoValor"].Value = ((combo)cdbEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((combo)cdbEstado.SelectedItem).texto.ToString();
                    limpiar();

                }
                else { MessageBox.Show(Mensaje); }
            }


        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtDescripcion.Text = dgvData.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (combo oc in cdbEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cdbEstado.Items.IndexOf(oc);
                            cdbEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtID.Text) != 0)
            {
                if (MessageBox.Show("desea eliminar la categoria??", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Categoria objCat = new Categoria()
                    {

                        IdCategoria = Convert.ToInt32(txtID.Text),
                    };
                    bool resp = new CN_Categoria().Elimnar(objCat, out Mensaje);
                    if (resp)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources._new.Width;
                var h = Properties.Resources._new.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources._new, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar sesion???", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                FrmMantenimiento manto = new FrmMantenimiento();
                manto.Close();
                Form1 form = new Form1(null);
                form.Show();
                Login login = new Login();
                login.Show();
            }
        }
    }
    }
