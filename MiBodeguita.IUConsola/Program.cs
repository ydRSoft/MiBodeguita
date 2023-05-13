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
                //Guardar();
                //Mostrar();
                //Eliminar();
                //Editar();
                //Mostrar();

                //getProducto();

                MostrarLista();


                Console.WriteLine("\nPresione una tecla para salir...");
                Console.ReadKey();

                Console.Clear();
            }
        }

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

        static void Mostrar() {
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
    
    }
}
