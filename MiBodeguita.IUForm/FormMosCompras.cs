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
    public partial class FormMosCompras : Form
    {
        public FormMosCompras()
        {
            InitializeComponent();
        }
        private void FormMosCompras_Load(object sender, EventArgs e)
        {
            LLenarDataGridView();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            LLenarDataGridView();
        }

        private void LLenarDataGridView()
        {
            var mLista = new CompraBL().Mostrar();

            if (mLista != null)
            {
                dataGridViewMostrar.DataSource = null;
                dataGridViewMostrar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewMostrar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewMostrar.ClearSelection();
                dataGridViewMostrar.DataSource = mLista;

                dataGridViewMostrar.Columns[4].Visible = false;
            }

        }

        
    }
}
