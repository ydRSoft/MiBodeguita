using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MiBodeguita.BL;
using MiBodeguita.Model;

namespace MiBodeguita.IUForm
{
    public partial class FormMosProducto : Form
    {
        bool BuscaID = true;
        public FormMosProducto()
        {
            InitializeComponent();
            
        }
        private void FormMosProducto_Load(object sender, EventArgs e)
        {
            //ProductoBL bl = new ProductoBL();
            //LLenarDataGridView(bl.Mostrar()); // desde archivos

            ProductoSQL pSql = new ProductoSQL();
            var ListaProd = pSql.Mostrar();
            LLenarDataGridView(ListaProd);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            MostrarProducto();
        }

        private void MostrarProducto() {
            try
            {
                ProductoBL bl = new ProductoBL();
                List<ProductoModel> mLista = new List<ProductoModel>();
                if (BuscaID)
                {
                    int ID = Convert.ToInt32(textBoxID.Text);
                    var prod = bl.getProducto(ID);

                    mLista.Add(prod);
                }
                else
                {
                    mLista = bl.getLista(textBoxNombre.Text);
                }

                LLenarDataGridView(mLista);
            }
            catch
            {

            }
        }

        private void LLenarDataGridView(List<ProductoModel> mLista) {

            if (mLista != null) {
                dataGridViewMostrar.DataSource = null;
                dataGridViewMostrar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewMostrar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewMostrar.ClearSelection();
                dataGridViewMostrar.DataSource = mLista;

                dataGridViewMostrar.Columns[5].Visible = false;
            }

        }

        private void textBoxID_KeyUp(object sender, KeyEventArgs e)
        {
            BuscaID = true;
            textBoxNombre.Clear();
            MostrarProducto();
        }

        private void textBoxNombre_KeyUp(object sender, KeyEventArgs e)
        {
            BuscaID = false;
            textBoxID.Clear();
            MostrarProducto();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try {
                int IdProd = Convert.ToInt32(dataGridViewMostrar.SelectedRows[0].Cells[0].Value);

                //ProductoBL bl = new ProductoBL();
                //var prod = bl.getProducto(IdProd);

                ProductoSQL pSql = new ProductoSQL();
                var prod = pSql.getProducto(IdProd);

                if (prod.ID > 0)
                {
                    FormRegProducto frm = new FormRegProducto(prod);
                    frm.Text = "Editar Producto";
                    AbrirFormulario(frm);
                }
                else {
                    MessageBox.Show("producto no disponible");
                }
            } catch {
                MessageBox.Show("Error de conexion");
            }
        }

        private void dataGridViewMostrar_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int IdProd = Convert.ToInt32(dataGridViewMostrar.SelectedRows[0].Cells[0].Value);

            // Desde Archivos
            //ProductoBL bl = new ProductoBL();
            //var resultado = bl.Eliminar(IdProd);

            ProductoSQL pSql = new ProductoSQL();
            var resultado = pSql.Eliminar(IdProd);
            MessageBox.Show(resultado.Mensaje);

            LLenarDataGridView(pSql.Mostrar());
        }

        private void AbrirFormulario(Form frm)
        {
            var Formulario = FormInicio.ActiveForm.MdiChildren.Where(x => x.Name == frm.Name 
                                                        && x.Text == frm.Text).FirstOrDefault();
            if (Formulario == null)
            {
                frm.MdiParent = FormInicio.ActiveForm;
                frm.Show();
            }
            else
            {
                Formulario.BringToFront();
            }
        }

        
    }
}
