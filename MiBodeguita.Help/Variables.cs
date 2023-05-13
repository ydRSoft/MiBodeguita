using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBodeguita.Help
{
    public class Variables
    {
        //otros
        public static string PathTemp = "Temporal.txt";

        // compra
        public static string PathCompras = "Compras.txt";
        public static string PathCompraDet = "CompraDetalle.txt";

        // Ventas
        public static string PathVentas = "Ventas.txt";
        public static string PathVentaDet = "VentaDetalle.txt";

        //productos
        public static string PathProd = "Producto.txt";

        // Unidades
        public static int UUnidad = 1;
        public static int UKilo = 2;
        public static int ULitro = 3;

        public static string getUnidad(int IdUnidad)
        {
            switch (IdUnidad) {
                case 1: return "UNIDAD";
                case 2: return "KILOGRAMO";
                case 3: return "LITRO";
                default: return "-";
            }
        }
    }
}
