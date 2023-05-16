using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBodeguita.Model
{
    public class DetalleModel
    {
        public int ID_Ref { set; get; }         //referencia venta o compra
        public int  ID_Producto { set; get; }
        public string NProducto { set; get; }
        public decimal Precio { set; get; }
        public decimal Cantidad { set; get; }
        public decimal Total { set; get; }

        public DetalleModel()
        {
        }
        public DetalleModel(int ID_Ref, string NProducto, decimal Precio, decimal Cantidad) {
            this.ID_Ref = ID_Ref;
            this.NProducto = NProducto;
            this.Precio = Precio;
            this.Cantidad = Cantidad;
            Total = Precio * Cantidad;
        }
    }
}
