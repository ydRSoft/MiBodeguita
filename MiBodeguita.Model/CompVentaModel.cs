using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBodeguita.Model
{
    // nos sirve tanto para Compras como para Ventas
    public class CompVentaModel
    {
        public int ID { set; get; }
        public string Codigo { set; get; }
        public DateTime Fecha { set; get; }
        public decimal Importe { set; get; }
        public List<DetalleModel> ListaDetalle { set; get; }

        public CompVentaModel() {
            ID = 0;
            Codigo = "Sin Codigo";
            Fecha = DateTime.Now;
            Importe = 0;
            ListaDetalle = new List<DetalleModel>();
        }
    }
}
