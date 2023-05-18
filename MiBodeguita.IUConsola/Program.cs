using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiBodeguita.Model;
using MiBodeguita.BL;

namespace MiBodeguita.IUConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {

                //AgregarCompra();
                //MostrarCompra();
                EditarCompra();
                Console.WriteLine("\nPresione una tecla para salir...");
                Console.ReadKey();

                Console.Clear();
            }
        }

        static void AgregarCompra() {
            CompraBL bl = new CompraBL();
            CompVentaModel objModel = new CompVentaModel();
            Console.WriteLine("Nueva Compra ");
            int IdModel = 0;
            do {
                Console.WriteLine("ID : ");
                IdModel = Convert.ToInt32(Console.ReadLine());
                IdModel = bl.ValidaID(IdModel);
            } while (IdModel<=0);

            objModel.ID = IdModel;
            Console.WriteLine("Ingrese Codigo :");
            objModel.Codigo = Console.ReadLine();
            objModel.Fecha = DateTime.Now;            

            objModel.ListaDetalle = LeerDetalle(IdModel);
            if (objModel.ListaDetalle.Count > 0)
            {
                objModel.Importe = objModel.ListaDetalle.Sum(x => x.Total);
                var resultado = bl.Agregar(objModel);
                Console.WriteLine(resultado.Mensaje + " -> " + resultado.ID);
            }
            else {
                Console.WriteLine("registre un producto");
            }
        }

        static List<DetalleModel> LeerDetalle(int ID_Ref) {
            List<DetalleModel> mLista = new List<DetalleModel>();
            int op = 1;
            do
            {
                Console.WriteLine("Codigo Producto");
                int ID_Prod = Convert.ToInt32(Console.ReadLine());
                if (ID_Prod > 0)
                {
                    var aux = mLista.Where(x => x.ID_Producto == ID_Prod).FirstOrDefault();
                    if (aux == null)
                    {
                        ProductoBL bl = new ProductoBL();
                        var producto = bl.getProducto(ID_Prod);
                        if (producto.ID > 0)
                        {
                            Console.WriteLine("\nProducto : " + producto.Nombre);
                            DetalleModel temp = new DetalleModel();
                            Console.WriteLine("Ingrese Precio :");
                            temp.Precio = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("Ingrese Cantidad : ");
                            temp.Cantidad = Convert.ToDecimal(Console.ReadLine());
                            temp.Total = temp.Precio * temp.Cantidad;
                            temp.ID_Producto = ID_Prod;
                            temp.NProducto = producto.Nombre;
                            mLista.Add(temp);
                        }
                    }
                   
                }

                op = ID_Prod;
            } while (op > 0);

            return mLista;
        }

        static void MostrarCompra() {
            CompraBL bl = new CompraBL();
            var mLista = bl.Mostrar().OrderBy(x=>x.ID).ToList();
            Console.WriteLine("Lista de Compras\n");
            foreach (var item in mLista) {                
                Console.WriteLine("\nCompra ID : "+item.ID);
                Console.WriteLine("Codigo : "+item.Codigo +"  Fecha : " + item.Fecha.ToShortDateString());
                Console.WriteLine("Importe : "+item.Importe);
                Console.WriteLine("\nDetalle de la Compra");
                DetalleBL detalle = new DetalleBL(Help.Variables.PathCompraDet);
                var ListaDet = detalle.Mostrar(item.ID);

                foreach (var det in ListaDet) {
                    Console.WriteLine("Producto " + det.NProducto + " P " + det.Precio +
                        " - C " + det.Cantidad + " - T " + det.Total);
                }
            }
        }

        static void EditarCompra()
        {
            CompraBL bl = new CompraBL();
            CompVentaModel objModel = new CompVentaModel();
            Console.WriteLine("Ingrese ID : ");
            objModel.ID = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Codigo : ");
            objModel.Codigo = Console.ReadLine();

            var resultado = bl.Editar(objModel);
            Console.WriteLine(resultado.Mensaje + " -> " + resultado.ID);
        }


        #region Producto 

        static void Guardar() {
            ProductoModel objModel = new ProductoModel();
            Console.WriteLine("Nuevo Producto");
            Console.WriteLine("Ingrese ID");
            objModel.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese Nombre");
            objModel.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese PVenta");
            objModel.PVenta = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ingrese PCompra");
            objModel.PCompra = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ingrese Stock");
            objModel.Stock = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ingrese ID Unidad");
            objModel.ID_Unidad = Convert.ToInt32(Console.ReadLine());

            ProductoBL bl = new ProductoBL();
            RespuestaModel Rsta = bl.Guardar(objModel);
            Console.WriteLine(Rsta.Mensaje + " -> " + Rsta.ID);
        }

        static void MostrarProducto() {
            ProductoBL bl = new ProductoBL();
            var mLista = bl.Mostrar();
            Console.WriteLine("\nLista de Productos");
            foreach (var item in mLista) {
                Console.WriteLine("ID : " + item.ID);
                Console.WriteLine("Nombre : " + item.Nombre);
                //Console.WriteLine("PVenta : " + item.PVenta);
                //Console.WriteLine("PCompra : " + item.PCompra);
                //Console.WriteLine("Stock : " + item.Stock);
                //Console.WriteLine("Unidad : " + Help.Variables.getUnidad(item.ID_Unidad));
                Console.WriteLine("------------------\n");
            }
        }

        static void MostrarLista()
        {
            ProductoBL bl = new ProductoBL();
            Console.WriteLine("Ingrese Nombre");
            string Nombre = Console.ReadLine();
            var mLista = bl.getLista(Nombre);
            Console.WriteLine("\nLista de Productos");
            foreach (var item in mLista)
            {
                Console.WriteLine("ID : " + item.ID);
                Console.WriteLine("Nombre : " + item.Nombre);
                //Console.WriteLine("PVenta : " + item.PVenta);
                //Console.WriteLine("PCompra : " + item.PCompra);
                //Console.WriteLine("Stock : " + item.Stock);
                //Console.WriteLine("Unidad : " + Help.Variables.getUnidad(item.ID_Unidad));
                Console.WriteLine("------------------\n");
            }
        }
        static void Eliminar()
        {
            Console.WriteLine("Eliminar Producto");
            Console.WriteLine("Ingrese ID");
            int Id = Convert.ToInt32(Console.ReadLine());

            ProductoBL bl = new ProductoBL();
            var Rsta = bl.Eliminar(Id);
            Console.WriteLine(Rsta.Mensaje + " -> " + Rsta.ID);
        }

        static void Editar() {
            ProductoModel objModel = new ProductoModel();
            Console.WriteLine("Producto Editar");
            Console.WriteLine("Ingrese ID");
            objModel.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese Nombre");
            objModel.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese PVenta");
            objModel.PVenta = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ingrese PCompra");
            objModel.PCompra = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ingrese Stock");
            objModel.Stock = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ingrese ID Unidad");
            objModel.ID_Unidad = Convert.ToInt32(Console.ReadLine());

            ProductoBL bl = new ProductoBL();
            RespuestaModel Rsta = bl.Editar(objModel);
            Console.WriteLine(Rsta.Mensaje + " -> " + Rsta.ID);
        }

        static void getProducto() {
            ProductoBL bl = new ProductoBL();
            Console.WriteLine("Ingrese ID");
            int ID = Convert.ToInt32(Console.ReadLine());

            var item = bl.getProducto(ID);

            Console.WriteLine("ID : " + item.ID);
            Console.WriteLine("Nombre : " + item.Nombre);
            Console.WriteLine("PVenta : " + item.PVenta);
            Console.WriteLine("PCompra : " + item.PCompra);
            Console.WriteLine("Stock : " + item.Stock);
            Console.WriteLine("Unidad : " + Help.Variables.getUnidad(item.ID_Unidad));
            Console.WriteLine("------------------\n");

            Console.WriteLine("Ingrese Nombre");            
            item = bl.getProducto(Console.ReadLine());

            Console.WriteLine("ID : " + item.ID);
            Console.WriteLine("Nombre : " + item.Nombre);
            Console.WriteLine("PVenta : " + item.PVenta);
            Console.WriteLine("PCompra : " + item.PCompra);
            Console.WriteLine("Stock : " + item.Stock);
            Console.WriteLine("Unidad : " + Help.Variables.getUnidad(item.ID_Unidad));
            Console.WriteLine("------------------\n");
        }
        #endregion
    }
}
