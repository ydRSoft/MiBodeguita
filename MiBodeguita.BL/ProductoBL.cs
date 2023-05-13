using System;
using System.Collections.Generic;
using System.IO; // leer o escribir un archivo
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiBodeguita.Model;

namespace MiBodeguita.BL
{
    // MiBodeguita.IUConsola -> bin -> Debug -> Producto.txt
    public class ProductoBL : IProductoBL
    {
        public RespuestaModel Guardar(ProductoModel objModel)
        {
            try
            {
                // validacion
                var prod = getProducto(objModel.ID);

                if (prod.ID > 0) {
                    return new RespuestaModel(objModel.ID, "ID Duplicado", true);
                }

                if (prod.ID < 0)
                {
                    return new RespuestaModel(objModel.ID, "Advertencia Error!!!", true);
                }

                string Datos = ObjetoToLinea(objModel);

                StreamWriter Arch = new StreamWriter(Help.Variables.PathProd, true);
                Arch.WriteLine(Datos);
                Arch.Close();

                return new RespuestaModel(objModel.ID, "Producto Archivado", false);
            }
            catch
            {
                return new RespuestaModel();
            }
        }
        public List<ProductoModel> Mostrar()
        {
            List<ProductoModel> mListaLocal = new List<ProductoModel>();
            string Linea = "";

            if (File.Exists(Help.Variables.PathProd))
            {
                StreamReader Arch = new StreamReader(Help.Variables.PathProd);
                Linea = Arch.ReadLine();
                while (Linea != null)
                { //string Letra = Linea;
                    mListaLocal.Add(LineaToObjeto(Linea));

                    Linea = Arch.ReadLine();
                }

                Arch.Close();
            }
            return mListaLocal;
        }
        public RespuestaModel Editar(ProductoModel objModel)
        {
            try
            {
                if (File.Exists(Help.Variables.PathTemp))
                {
                    File.Delete(Help.Variables.PathTemp);
                }

                bool Editado = false;
                if (File.Exists(Help.Variables.PathProd))
                {
                    StreamReader Arch = new StreamReader(Help.Variables.PathProd);
                    string Linea = Arch.ReadLine();
                    
                    while (Linea != null)
                    {
                        string[] Arreglo;
                        Arreglo = Linea.Split(',');
                        int IdLocal = Convert.ToInt32(Arreglo[0]);
                        StreamWriter ArchSave = new StreamWriter(Help.Variables.PathTemp, true);
                        if (objModel.ID != IdLocal)
                        {
                            ArchSave.WriteLine(Linea);
                        }
                        else
                        {
                            ArchSave.WriteLine(ObjetoToLinea(objModel));
                            Editado = true;
                        }
                        ArchSave.Close();
                        Linea = Arch.ReadLine();
                    }
                    Arch.Close();
                }

                if (Editado)
                {
                    EliminarTemporal();

                    return new RespuestaModel(objModel.ID, "Producto Editado", false);
                }

                return new RespuestaModel(objModel.ID, "Producto No Editado", true);
            }
            catch
            {
                return new RespuestaModel();
            }
        }
        public RespuestaModel Eliminar(int ID)
        {
            try {               
                
                if (File.Exists(Help.Variables.PathTemp)) {
                    File.Delete(Help.Variables.PathTemp);
                }

                bool Eliminado = false;
                if (File.Exists(Help.Variables.PathProd))
                {
                    StreamReader Arch = new StreamReader(Help.Variables.PathProd);
                    string Linea = Arch.ReadLine();
                    while (Linea != null)
                    {
                        string[] Arreglo;
                        Arreglo = Linea.Split(',');
                        int IdLocal = Convert.ToInt32(Arreglo[0]);
                        if (ID != IdLocal)
                        {
                            string Datos = Linea;                            
                            StreamWriter ArchSave = new StreamWriter(Help.Variables.PathTemp, true);
                            ArchSave.WriteLine(Datos);
                            ArchSave.Close();
                        }
                        else {
                            Eliminado = true;
                        }
                        Linea = Arch.ReadLine();
                    }
                    Arch.Close();
                }

                if (Eliminado)
                {
                    EliminarTemporal();

                    return new RespuestaModel(ID, "Producto Eliminado", false);
                }

                return new RespuestaModel(ID, "Producto No Eliminado", true);
            } catch { 
                return new RespuestaModel(); 
            }
        }
        public ProductoModel getProducto(int ID)
        {
            try {
                ProductoModel objModel = new ProductoModel();
                if (File.Exists(Help.Variables.PathProd))
                {
                    StreamReader Arch = new StreamReader(Help.Variables.PathProd);
                    string Linea = Arch.ReadLine();
                    while (Linea != null)
                    {
                        string[] Arreglo;
                        Arreglo = Linea.Split(',');
                        int IdLocal = Convert.ToInt32(Arreglo[0]);

                        if (ID == IdLocal) {
                            Arch.Close();
                            return LineaToObjeto(Linea);
                        }

                        Linea = Arch.ReadLine();
                    }
                    Arch.Close();
                }

                return objModel;
            } catch {
                return new ProductoModel(-1); // ID = -1;
            }
        }
        public ProductoModel getProducto(string Nombre)
        {
            try
            {
                ProductoModel objModel = new ProductoModel();
                if (File.Exists(Help.Variables.PathProd))
                {
                    StreamReader Arch = new StreamReader(Help.Variables.PathProd);
                    string Linea = Arch.ReadLine();
                    while (Linea != null)
                    {
                        string[] Arreglo;
                        Arreglo = Linea.Split(',');
                        string NombreLocal = Arreglo[1];

                        if (NombreLocal.Contains(Nombre))
                        {// leche gloria -> leche
                            Arch.Close();
                            return LineaToObjeto(Linea);
                        }

                        Linea = Arch.ReadLine();
                    }
                    Arch.Close();
                }

                return objModel;
            }
            catch
            {
                return new ProductoModel(-1); // ID = -1;
            }
        }

        public List<ProductoModel> getLista(string Nombre)
        {
            try
            {
                List<ProductoModel> mLista = new List<ProductoModel>();
                
                if (File.Exists(Help.Variables.PathProd))
                {
                    StreamReader Arch = new StreamReader(Help.Variables.PathProd);
                    string Linea = Arch.ReadLine();
                    while (Linea != null)
                    {
                        ProductoModel objModel = new ProductoModel();
                        string[] Arreglo;
                        Arreglo = Linea.Split(',');
                        string NombreLocal = Arreglo[1];

                        if (NombreLocal.Contains(Nombre))
                        {// leche gloria -> leche
                            mLista.Add(LineaToObjeto(Linea));
                        }

                        Linea = Arch.ReadLine();
                    }
                    Arch.Close();
                }

                return mLista;
            }
            catch
            {
                return new List<ProductoModel>();
            }
        }

        private string ObjetoToLinea(ProductoModel objModel) {
            string Datos = objModel.ID + "," + objModel.Nombre + "," +
                    objModel.PVenta + "," + objModel.PCompra + "," + objModel.Stock +
                    "," + objModel.ID_Unidad;

            return Datos;
        }
        private ProductoModel LineaToObjeto(string Linea) {
            ProductoModel objModel = new ProductoModel();
            string[] Arreglo;
            Arreglo = Linea.Split(',');
           
            objModel.ID = Convert.ToInt32(Arreglo[0]);
            objModel.Nombre = Arreglo[1];
            objModel.PVenta = Convert.ToDecimal(Arreglo[2]);
            objModel.PCompra = Convert.ToDecimal(Arreglo[3]);
            objModel.Stock = Convert.ToDecimal(Arreglo[4]);
            objModel.ID_Unidad = Convert.ToInt32(Arreglo[5]);

            return objModel;
        }
        private void EliminarTemporal() {
            if (!File.Exists(Help.Variables.PathTemp))
            {
                StreamWriter ArchTemp = new StreamWriter(Help.Variables.PathTemp);
                ArchTemp.Close();
            }

            if (File.Exists(Help.Variables.PathProd))
            {
                File.Delete(Help.Variables.PathProd);
            }

            File.Move(Help.Variables.PathTemp, Help.Variables.PathProd);
        }
    }
}
