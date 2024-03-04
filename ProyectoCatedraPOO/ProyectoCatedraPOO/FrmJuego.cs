using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using ProyectoCatedraPOO.ultilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ProyectoCatedraPOO
{
    public partial class FrmJuego : Form
    {
        public FrmJuego()
        {
            InitializeComponent();
        }

        private void FrmJuego_Load(object sender, EventArgs e)
        {
            cdbEstado.Items.Add(new combo() { Valor = 1, texto = "Activo" });
            cdbEstado.Items.Add(new combo() { Valor = 0, texto = "No activo" });
            cdbEstado.DisplayMember = "texto";
            cdbEstado.ValueMember = "Valor";
            cdbEstado.SelectedIndex = 0;

            //llena el combo de categoria
            List<Categoria> listarJuegos = new CN_Categoria().listar();

            foreach (Categoria item in listarJuegos)
            {
                cdbcat.Items.Add(new combo() { Valor = item.IdCategoria, texto = item.Descripcion });
            }

            cdbcat.DisplayMember = "texto";
            cdbcat.ValueMember = "Valor";
            cdbcat.SelectedIndex = 0;


            //mostrar los datos en el data
            List<Juegos> listarJuego = new CN_Juegos().listar();

            foreach (Juegos item in listarJuego)
            {
                dgvData.Rows.Add(new object[] {"",item.idJuegos,item.Codigo,item.Nombre,item.descripcion,
                    item.oCategoria.IdCategoria,
                    item.oCategoria.Descripcion,

            item.Estado==true ?1 :0,
            item.Estado== true ? "Activo" :"No Activo",
            item.Stock,
            item.PrecioVenta
            });
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
                    txtCod.Text = dgvData.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dgvData.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach(combo oc in cdbcat.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            int indice_combo = cdbcat.Items.IndexOf(oc);
                            cdbcat.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    txtCantidad.Text = dgvData.Rows[indice].Cells["Stock"].Value.ToString();
                    txtPrecio.Text = dgvData.Rows[indice].Cells["Precio"].Value.ToString();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Juegos objJuegoss = new Juegos()
            {
                idJuegos = Convert.ToInt32(txtID.Text),
                Codigo = txtCod.Text,
                Nombre = txtNombre.Text,
                descripcion = txtDescripcion.Text,
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((combo)cdbcat.SelectedItem).Valor) },
                Stock = Convert.ToInt32(txtCantidad.Text),
                PrecioVenta =Convert.ToDecimal(txtPrecio.Text),
                Estado = Convert.ToInt32(((combo)cdbEstado.SelectedItem).Valor) == 1 ? true : false,
            };
            //si es 0 esta creando un usuario
            if (objJuegoss.idJuegos == 0)
            {
                int idusuariogenerado = new CN_Juegos().Registrar(objJuegoss, out Mensaje);
                if (idusuariogenerado != 0)
                {


                    dgvData.Rows.Add(new object[] {"",idusuariogenerado,txtCod.Text,txtNombre.Text,txtDescripcion.Text,
                ((combo)cdbcat.SelectedItem).Valor.ToString(),
                ((combo)cdbcat.SelectedItem).texto.ToString(),
                ((combo)cdbEstado.SelectedItem).Valor.ToString(),
                ((combo)cdbEstado.SelectedItem).texto.ToString(),
                txtCantidad.Text, txtPrecio.Text,
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

                bool res = new CN_Juegos().Editar(objJuegoss, out Mensaje);
                if (res)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtCod.Text;
                    row.Cells["Codigo"].Value = txtCod.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["idCategoria"].Value = ((combo)cdbcat.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((combo)cdbcat.SelectedItem).texto.ToString();
                    row.Cells["Stock"].Value=txtCantidad.Text;
                    row.Cells["Precio"].Value=txtPrecio.Text;
                    row.Cells["EstadoValor"].Value = ((combo)cdbEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((combo)cdbEstado.SelectedItem).texto.ToString();
                    limpiar();

                }
                else { MessageBox.Show(Mensaje); }
            }

        }
        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtID.Text = "0";
            txtCod.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            cdbcat.SelectedIndex = 0;
            cdbEstado.SelectedIndex = 0;
            txtCod.Select();
            txtPrecio.Clear();
            txtCantidad.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtID.Text) != 0)
            {
                if (MessageBox.Show("desea eliminar el Juego??", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Juegos objJuegoss = new Juegos()
                    {

                        idJuegos = Convert.ToInt32(txtID.Text),
                    };
                    bool resp = new CN_Juegos().Elimnar(objJuegoss, out Mensaje);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(dgvData.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para guardar en EXCEL","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                    DataTable dt = new DataTable();

                foreach(DataGridViewColumn colum in dgvData.Columns)
                {
                    if(colum.HeaderText != "" && colum.Visible)
                    {
                        dt.Columns.Add(colum.HeaderText,typeof(string));
                    }
                }
                foreach (DataGridViewRow fil in dgvData.Rows)
                {
                    if (fil.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            fil.Cells[2].Value.ToString(),
                            fil.Cells[3].Value.ToString(),
                            fil.Cells[4].Value.ToString(),
                            fil.Cells[6].Value.ToString(),
                            fil.Cells[8].Value.ToString(),
                            fil.Cells[9].Value.ToString(),
                            fil.Cells[10].Value.ToString(),

                        });
                    }
                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteProducto{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if(savefile.ShowDialog() == DialogResult.OK) 
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte generado","Mesaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
