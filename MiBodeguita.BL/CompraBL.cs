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
                bool resultado = Help.Funciones.GuardarArchivo(Help.Variables.PathCompras, ObjetoToLinea(objModel), true);

                if (resultado) {

                    string Mensaje = AgregarDetalle(objModel);
                    return new RespuestaModel(objModel.ID, "Compra Guardada" + Mensaje, false);
                }

                return new RespuestaModel(objModel.ID, "No Guardado", true);
            } catch {
                return new RespuestaModel();
            }
        }

        private string AgregarDetalle(CompVentaModel objModel)
        {
            int Contador = 0;
            try {
                
                var mLista = objModel.ListaDetalle;
                if (mLista != null) {
                    foreach (var item in mLista) {
                        item.ID_Ref = objModel.ID;
                        DetalleBL bl = new DetalleBL(Help.Variables.PathCompraDet);
                        var respuesta = bl.Agregar(item);
                        if (respuesta.Error)
                            Contador++;

                    }
                }

                if (Contador > 0)
                {
                    return " No guardador Det " + Contador;
                }

                return "";
            } catch {
                return " Error";
            }

        }

        public int ValidaID(int ID) {
            int IDLocal  = Help.Funciones.ValidaId(Help.Variables.PathCompras, ID);
            return IDLocal;
        }

        private string ObjetoToLinea(CompVentaModel Data) {
            string Datos = Data.ID + "," + Data.Codigo + "," +
                            Data.Fecha + "," + Data.Importe + ",";

            return Datos.PadRight(Help.Variables.TamCompVenta - 2, ' ');
        }

        public List<CompVentaModel> Mostrar()
        {
            try {
                List<CompVentaModel> mLista = new List<CompVentaModel>();
                if (File.Exists(Help.Variables.PathCompras))
                {
                    StreamReader Arch = new StreamReader(Help.Variables.PathCompras);
                    string Linea = Arch.ReadLine();
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
            // datos tienen ula longitud de 50 caracteres
            try {
                string RutaCompleta = Help.Variables.PathCompras;
                int TamLinea = Help.Variables.TamCompVenta;
                if (File.Exists(RutaCompleta)) {
                    var mCompra = getCompVenta(objModel.ID);

                    if (mCompra.Index >= 0) {
                        objModel.Fecha = mCompra.Fecha;
                        objModel.Importe = mCompra.Importe;
                        string Cambio = ObjetoToLinea(objModel);

                        FileStream fs = new FileStream(RutaCompleta, FileMode.Open, FileAccess.ReadWrite);
                        fs.Seek(TamLinea * mCompra.Index, SeekOrigin.Begin);
                        

                        StreamWriter Arch = new StreamWriter(fs);
                        Arch.WriteLine(Cambio);
                        Arch.Close();
                        fs.Close();

                        return new RespuestaModel(objModel.ID, "Editado", false);
                    }

                    return new RespuestaModel(objModel.ID, "ID NO Encontrado", true);
                }
                return new RespuestaModel(objModel.ID,"No Editado",true);
            } catch {
                return new RespuestaModel();
            }
            
        }
                
        public CompVentaModel getCompVenta(int ID)
        {
            try {
                CompVentaModel objModel = new CompVentaModel();

                if (File.Exists(Help.Variables.PathCompras)) {
                    StreamReader Arch = new StreamReader(Help.Variables.PathCompras);
                    string Linea = Arch.ReadLine();
                    int Index = 0;
                    while (Linea != null) {
                        string[] Arreglo;
                        Arreglo = Linea.Split(',');
                        int IdLocal = Convert.ToInt32(Arreglo[0]);
                        if (IdLocal == ID) {
                            Arch.Close();
                            objModel = LineaToObjeto(Linea);
                            objModel.Index = Index;
                            return objModel;
                        }
                        Index++;
                        Linea = Arch.ReadLine();
                    }

                    Arch.Close();
                }

                return objModel;
            } catch {
                return new CompVentaModel();
            }
        }

        public List<ProductoModel> ListaProducto(int ID)
        {
            throw new NotImplementedException();
        }

       
    }
}
