using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiBodeguita.Model;
using MiBodeguita.BL;

namespace MiBodeguita.IUForm
{
    public partial class FormCompra : Form
    {
        List<DetalleModel> mLista = new List<DetalleModel>();
        public FormCompra()
        {
            InitializeComponent();
        }

        private void FormCompra_Load(object sender, EventArgs e)
        {
            LLenarDataGridView();
        }

        private void textBoxNomProd_TextChanged(object sender, EventArgs e)
        {//var objModel = new ProductoBL().getProducto(textBoxNomProd.Text);
            string Nombre = textBoxNomProd.Text;
            ProductoBL bl = new ProductoBL();
            ProductoModel objModel = bl.getProducto(Nombre.ToUpper());

            if (objModel.ID > 0)
            {
                textBoxIDProd.Text = objModel.ID.ToString();
                labelProducto.Text = objModel.Nombre;
                textBoxPrecio.Text = objModel.PCompra.ToString();
                buttonEnviar.Enabled = true;
            }
            else {
                textBoxIDProd.Text = "";
                labelProducto.Text = "";
                textBoxPrecio.Text = "";
                buttonEnviar.Enabled = false;
            }

            textBoxCantidad.Text = "";
        }

        private void textBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            decimal Cantidad = ValidaDecimal(textBoxCantidad.Text);
            decimal Precio = ValidaDecimal(textBoxPrecio.Text);
            decimal Total = Cantidad * Precio;

            textBoxTotal.Text = Total.ToString();
        }

        private decimal ValidaDecimal(string Letra)
        {
            try {
                decimal cantidad = Convert.ToDecimal(Letra);
                return cantidad;
            } catch {
                return 0;
            }
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            DetalleModel mDet = new DetalleModel();
            mDet.ID_Producto = Convert.ToInt32(textBoxIDProd.Text);
            mDet.NProducto = labelProducto.Text;
            mDet.Precio = ValidaDecimal(textBoxPrecio.Text);
            mDet.Cantidad = ValidaDecimal(textBoxCantidad.Text);
            mDet.Total = ValidaDecimal(textBoxTotal.Text);

            //var detalle = mLista.Where(x => x.ID_Producto == mDet.ID_Producto).FirstOrDefault();

            if (!DuplicadoDetalle(mDet))
                mLista.Add(mDet);

            LLenarDataGridView();
        }

        private bool DuplicadoDetalle(DetalleModel mDet) {
            for (int i = 0; i < mLista.Count; i++) {
                if (mLista[i].ID_Producto == mDet.ID_Producto) {
                    mLista[i] = mDet;
                    return true;
                }
            }

            return false;
        }

        private void LLenarDataGridView()
        {
            if (mLista != null)
            {
                dataGridViewMostrar.DataSource = null;
                dataGridViewMostrar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewMostrar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewMostrar.ClearSelection();
                dataGridViewMostrar.DataSource = mLista;
            }

            decimal Importe = mLista.Sum(x => x.Total);
            labelImporte.Text = Importe.ToString();
        }


        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            int IdComp = Convert.ToInt32(textBoxID.Text);

            CompraBL bl = new CompraBL();
            var comp = bl.getCompVenta(IdComp);
            if (comp.ID > 0)
            {
                labelMensaje.Text = "ID Duplicado";
                buttonGuardar.Enabled = false;
                
            }
            else {
                labelMensaje.Text = "-";
                buttonGuardar.Enabled = true;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            CompVentaModel objModel = new CompVentaModel();
            objModel.ID = Convert.ToInt32(textBoxID.Text);
            objModel.Codigo = textBoxCodigo.Text;
            objModel.Fecha = Convert.ToDateTime(dateTimePickerFecha.Text);
            objModel.Importe = Convert.ToDecimal(labelImporte.Text);
            objModel.ListaDetalle = mLista;

            if (mLista.Count == 0)
            {
                MessageBox.Show("Agrege Productos...!!");
            }
            else {
                CompraBL bl = new CompraBL();
                var comp = bl.Agregar(objModel);

                if (comp.Error)
                {
                    MessageBox.Show(comp.Mensaje, "COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    MessageBox.Show(comp.Mensaje, "COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewMostrar_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("hOLAS");
        }
    }
}
