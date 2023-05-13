using MiBodeguita.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
                int Contador = Help.Funciones.IdArchivo(Help.Variables.PathCompras) + 1;
                if (Contador == 0) return new RespuestaModel();
                objModel.ID = Contador;
                var mLista = Mostrar();
                mLista.Add(objModel);               
                bool Limpieza = Help.Funciones.GuardarArchivo(Help.Variables.PathCompras, Contador.ToString(), false);                
                if (Limpieza)
                {
                    foreach (var item in mLista) {
                        bool resultado = Help.Funciones.GuardarArchivo(Help.Variables.PathCompras, ObjetoToLinea(item), true);
                        if (resultado) {
                            Contador--;
                        }
                    }
                }
                
                if (Contador==0)
                {
                    return new RespuestaModel(objModel.ID, "Guardado Correctamente", false);
                }

                return new RespuestaModel(objModel.ID, "No Guardado -> " + Contador, true);
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
            try {
                List<CompVentaModel> mLista = new List<CompVentaModel>();
                if (File.Exists(Help.Variables.PathCompras))
                {
                    StreamReader Arch = new StreamReader(Help.Variables.PathCompras);
                    string Linea = Arch.ReadLine(); // Cantidad datos -> Cabecera
                    Linea = Arch.ReadLine();
                    while (Linea != null)
                    {
                        mLista.Add(LineaToObjeto(Linea));
                        Linea = Arch.ReadLine();
                    }

                    Arch.Close();
                }

                return mLista;
            } catch {
                return new List<CompVentaModel>();
            }
        }

        private CompVentaModel LineaToObjeto(string Linea) {
            CompVentaModel objModel = new CompVentaModel();
            string[] Arreglo;
            Arreglo = Linea.Split(',');
            objModel.ID = Convert.ToInt32(Arreglo[0]);
            objModel.Codigo = Arreglo[1];
            objModel.Fecha = Convert.ToDateTime(Arreglo[2]);
            objModel.Importe = Convert.ToDecimal(Arreglo[3]);

            return objModel;
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
