using CapaEntidad;
using CapaNegocio;
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
    public partial class MiniJuegos : Form
    {
        public Juegos _Juegos { get; set; }
        public MiniJuegos()
        {
            InitializeComponent();
        }
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iCol = e.ColumnIndex;
            if (iRow >= 0 && iCol >= 0)
            {
                _Juegos = new Juegos()
                {
                    idJuegos = Convert.ToInt32(dgvData.Rows[iRow].Cells["Id"].Value.ToString()),
                    Codigo = dgvData.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvData.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Stock = Convert.ToInt32(dgvData.Rows[iRow].Cells["Stock"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(dgvData.Rows[iRow].Cells["Precio"].Value.ToString()),
                    
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void MiniJuegos_Load(object sender, EventArgs e)
        {
            List<Juegos> JUEGOS = new CN_Juegos().listar();
            foreach(Juegos items in JUEGOS)
            {
                dgvData.Rows.Add(new object[] {items.idJuegos,items.Codigo,items.Nombre, items.Stock,items.PrecioVenta});
            }
        }
    }
}
