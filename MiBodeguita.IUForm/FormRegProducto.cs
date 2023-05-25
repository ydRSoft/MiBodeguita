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
    public partial class FormRegProducto : Form
    {
        ProductoModel mProducto;  // mproducto = null -> Registrar 
        public FormRegProducto(ProductoModel mProducto)
        {
            this.mProducto = mProducto;
            InitializeComponent();
        }

        private void FormRegProducto_Load(object sender, EventArgs e)
        {
            if (mProducto!=null)
            {
                textBoxID.Text = mProducto.ID.ToString();
                textBoxNombre.Text = mProducto.Nombre;
                textBoxPVenta.Text = mProducto.PVenta.ToString();
                textBoxPCompra.Text = mProducto.PCompra.ToString();
                textBoxStock.Text = mProducto.Stock.ToString();
                comboBoxUnidad.Text = mProducto.Unidad;
                textBoxID.Enabled = false;
                buttonGuardar.Text = "Editar";
            }
            CargaInicial();
        }

        private void CargaInicial() {
            List<TipoModel> ListaUnidad = 
                new List<TipoModel>() { new TipoModel(1,"UNIDAD"),
                new TipoModel(2,"KILOGRAMO"),new TipoModel(3,"LITRO")};

            if (ListaUnidad != null)
            {
                comboBoxUnidad.ValueMember = "ID";
                comboBoxUnidad.DisplayMember = "Nombre";
                comboBoxUnidad.DataSource = ListaUnidad;
            }
            else {
                comboBoxUnidad.Text = "Sin Data";
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try {
                ProductoModel p = new ProductoModel();
                p.ID = Convert.ToInt32(textBoxID.Text);
                p.Nombre = textBoxNombre.Text;
                p.PVenta = Convert.ToDecimal(textBoxPVenta.Text);
                p.PCompra = Convert.ToDecimal(textBoxPCompra.Text);
                p.Stock = Convert.ToDecimal(textBoxStock.Text);
                p.ID_Unidad = Convert.ToInt32(comboBoxUnidad.SelectedValue);

                ProductoBL bl = new ProductoBL();
                RespuestaModel resultado = new RespuestaModel();

                if (mProducto == null)
                {
                    resultado = bl.Guardar(p);
                }
                else {
                    resultado = bl.Editar(p);
                }

                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje, "Resultado", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else {
                    MessageBox.Show(resultado.Mensaje, "Resultado", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

            } catch {
                MessageBox.Show("Intente en otro Momento", "Resultado", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

       
    }
}
