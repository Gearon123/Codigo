using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
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
    public partial class FrmVentas : Form
    {
        private static Usuario usuarioActual;

        public FrmVentas(Usuario objusuario)
        {
            InitializeComponent();
            usuarioActual = objusuario;

        }
        //public FrmVentas(Usuario objusuario)
        //{
        //    InitializeComponent();
        //    txtUser.Text = "HOLA";
        //    txtUser.Text = "SAD"+objusuario;
        //}


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            txtUser.Text = usuarioActual.NombreCompleto;
            txtIDUser.Text = Convert.ToString(usuarioActual.IdUsuario);
            txtFecha.Text = DateTime.Now.ToString("dd/mm/yyyy");
            txtTotal.Text = "";
            txtIdProducto.Text = "0";
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            using(var modal = new MiniJuegos())
            {
                var result = modal.ShowDialog();

                if(result == DialogResult.OK)
                {
                    txtIdProducto.Text= modal._Juegos.idJuegos.ToString();
                    txtCodProducto.Text= modal._Juegos.Codigo;
                    txtJuego.Text = modal._Juegos.Nombre;
                    txtPrecio.Text=modal._Juegos.PrecioVenta.ToString("0.00");
                    txtStock.Text = modal._Juegos.Stock.ToString();
                    txtCantidad.Select();
                }
                else
                {
                    txtCodProducto.Select();
                }
            }
        }
        private void limpiar()
        {
            txtCodProducto.Clear();
            txtIdProducto.Clear();
            txtJuego.Clear();
            txtStock.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
        }
        private void Calcular()
        {
            decimal total = 0;
            if(dgvData.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dgvData.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
                }
                txtTotal.Text = total.ToString("0.00");
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool producto_existente = false;
            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(!decimal.TryParse(txtPrecio.Text, out precioCompra))
            {
                MessageBox.Show("Formato de compra incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Select();
                return;
            }
            foreach(DataGridViewRow fila in dgvData.Rows)
            {
                if (fila.Cells["idProducto"].Value.ToString()== txtIdProducto.Text)
                {
                    producto_existente=true;
                    break;
                }
            }
            if(!producto_existente)
            {
                dgvData.Rows.Add(new object[]
                {
                    txtIdProducto.Text,
                    txtJuego.Text,
                    txtPrecio.Text.ToString(),
                    txtCantidad.Text.ToString(),
                    (Convert.ToDecimal(txtCantidad.Text) * precioCompra).ToString()
                });
            }
            Calcular();
            limpiar();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.borrar.Width;
                var h = Properties.Resources.borrar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.borrar, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    dgvData.Rows.RemoveAt(indice);
                    Calcular();

                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtCantidad.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "validación de números", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para guardar en EXCEL", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn colum in dgvData.Columns)
                {
                    if (colum.HeaderText != "" && colum.Visible)
                    {
                        dt.Columns.Add(colum.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow fil in dgvData.Rows)
                {
                    txtUser.Text.ToString();
                        dt.Rows.Add(new object[]
                        {

                            fil.Cells[0].Value.ToString(),
                            fil.Cells[1].Value.ToString(),
                            fil.Cells[2].Value.ToString(),
                            fil.Cells[3].Value.ToString(),


                        });
                    
                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteVenta{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte generado", "Mesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar", "Mesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
