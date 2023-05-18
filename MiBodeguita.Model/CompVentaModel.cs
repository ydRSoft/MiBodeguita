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
        // Tamaño total de 48 Datos + fin de linea {\0} y saldo linea '\n'
        // -> Almacenamos 50 espacios (incluidos 3 comas)        
        public int ID { set; get; }                 //08 9
        public string Codigo { set; get; }          //07
        public DateTime Fecha { set; get; }         //20
        public decimal Importe { set; get; }        //10
        public int Index { set; get; }
        public List<DetalleModel> ListaDetalle { set; get; }

        public CompVentaModel() {
            Index = -1;
            ID = 0;
            Codigo = "Sin Codigo";
            Fecha = DateTime.Now;
            Importe = 0;
            ListaDetalle = new List<DetalleModel>();
        }
    }
}
