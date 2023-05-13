using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiBodeguita.Model;
namespace MiBodeguita.BL
{
    public interface ICompVenta
    {
        RespuestaModel Agregar(CompVentaModel objModel);
        List<CompVentaModel> Mostrar();
        RespuestaModel Editar(CompVentaModel objModel);
        RespuestaModel Eliminar(int ID);
        CompVentaModel getCompVenta(int ID);
        List<ProductoModel> ListaProducto(int ID);
    }
}
