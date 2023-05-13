using MiBodeguita.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBodeguita.BL
{
    public class CompraBL : ICompVenta
    {
        public RespuestaModel Agregar(CompVentaModel objModel)
        {
            try {
                int ID = Help.Funciones.IdArchivo(Help.Variables.PathCompras) + 1;
                if (ID == 0) return new RespuestaModel();
                objModel.ID = ID;
                string Datos = ObjetoToLinea(objModel);
                bool Resultado = Help.Funciones.GuardarArchivo(Help.Variables.PathCompras, ID.ToString());
                if (Resultado) {
                    bool Resultado1 = Help.Funciones.GuardarArchivo(Help.Variables.PathCompras, Datos);
                    if (Resultado1)
                    {
                        return new RespuestaModel(objModel.ID, "Guardado", false);
                    }
                }
                return new RespuestaModel(objModel.ID,"No Guardado",true);
            } catch {
                return new RespuestaModel();
            }
        }

        private string ObjetoToLinea(CompVentaModel Data) {

            string Datos = Data.ID + "," + Data.Codigo + "," + 
                            Data.Fecha + "," + Data.Importe;
            return Datos;
        }

        public List<CompVentaModel> Mostrar()
        {
            throw new NotImplementedException();
        }
        public RespuestaModel Eliminar(int ID)
        {
            throw new NotImplementedException();
        }

        public RespuestaModel Editar(CompVentaModel objModel)
        {
            throw new NotImplementedException();
        }
                
        public CompVentaModel getCompVenta(int ID)
        {
            throw new NotImplementedException();
        }

        public List<ProductoModel> ListaProducto(int ID)
        {
            throw new NotImplementedException();
        }

       
    }
}
