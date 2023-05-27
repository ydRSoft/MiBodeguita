using MiBodeguita.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBodeguita.BL
{
    public class ProductoSQL : IProductoBL
    {
        string Cadena = "Data Source = localhost; DataBase = dbMiBodeguita;" +
                        "User Id = ydrsoft; Pwd = Palomita16";

        public RespuestaModel Guardar2(ProductoModel objModel)
        {
            try {
                SqlConnection conexion = new SqlConnection(Cadena);
                conexion.Open();

                string query = "INSERT INTO Producto VALUES(" + ObjetoToLinea(objModel);
                SqlCommand cmd = new SqlCommand(query,conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return new RespuestaModel(objModel.ID,"Guardado",false);
            } catch {
                return new RespuestaModel();
            }
        }

        public RespuestaModel Guardar(ProductoModel objModel)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Cadena);
                conexion.Open();

                string query = "INSERT INTO Producto VALUES(" + 
                            "@ID,@Nombre,@PCompra,@PVenta,@Stock,@ID_Unidad)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", objModel.ID);
                cmd.Parameters.AddWithValue("@Nombre", objModel.Nombre);
                cmd.Parameters.AddWithValue("@PCompra", objModel.PCompra);
                cmd.Parameters.AddWithValue("@PVenta", objModel.PVenta);
                cmd.Parameters.AddWithValue("@Stock", objModel.Stock);
                cmd.Parameters.AddWithValue("@ID_Unidad", objModel.ID_Unidad);

                cmd.ExecuteNonQuery();
                conexion.Close();
                return new RespuestaModel(objModel.ID, "Guardado por parametros", false);
            }
            catch
            {
                return new RespuestaModel();
            }
        }

        public List<ProductoModel> Mostrar()
        {
            try {
                List<ProductoModel> mLista = new List<ProductoModel>();

                SqlConnection conexion = new SqlConnection(Cadena);
                conexion.Open();
                string query = "select * from Producto";
                SqlDataAdapter da = new SqlDataAdapter(query,conexion);
                da.SelectCommand.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                da.Fill(ds, "Productos");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
                    ProductoModel objModel = new ProductoModel();
                    objModel.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    objModel.Nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();
                    objModel.PCompra = Convert.ToDecimal(ds.Tables[0].Rows[i]["PCompra"].ToString());
                    objModel.PVenta = Convert.ToDecimal(ds.Tables[0].Rows[i]["PVenta"].ToString());
                    objModel.Stock = Convert.ToDecimal(ds.Tables[0].Rows[i]["Stock"].ToString());
                    objModel.ID_Unidad = Convert.ToInt32(ds.Tables[0].Rows[i]["ID_Unidad"].ToString());
                    objModel.Unidad = Help.Variables.getUnidad(objModel.ID_Unidad);
                    mLista.Add(objModel);
                }

                ds.Dispose();
                da.Dispose();
                conexion.Close();

                return mLista;
            } catch {
                return new List<ProductoModel>();
            }
        }

        public RespuestaModel Editar2(ProductoModel objModel)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Cadena);
                conexion.Open();

                string query = "Update Producto set Nombre = '" + objModel.Nombre +
                    "', PCompra = " + objModel.PCompra + ",PVenta =" + objModel.PVenta + "," +
                    "Stock=" + objModel.Stock + ",ID_Unidad=" + objModel.ID_Unidad +
                    " where ID = " + objModel.ID;

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return new RespuestaModel(objModel.ID, "Editado SQL", false);
            }
            catch
            {
                return new RespuestaModel();
            }
        }
        public RespuestaModel Editar(ProductoModel objModel)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Cadena);
                conexion.Open();

                string query = "Update Producto set Nombre = @Nombre," +
                            "PCompra = @PCompra, PVenta = @PVenta, Stock = @Stock," +
                            "ID_Unidad = @ID_Unidad WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", objModel.ID);
                cmd.Parameters.AddWithValue("@Nombre", objModel.Nombre);
                cmd.Parameters.AddWithValue("@PCompra", objModel.PCompra);
                cmd.Parameters.AddWithValue("@PVenta", objModel.PVenta);
                cmd.Parameters.AddWithValue("@Stock", objModel.Stock);
                cmd.Parameters.AddWithValue("@ID_Unidad", objModel.ID_Unidad);

                cmd.ExecuteNonQuery();
                conexion.Close();
                return new RespuestaModel(objModel.ID, "Editado por parametros", false);
            }
            catch
            {
                return new RespuestaModel();
            }
        }
        public RespuestaModel Eliminar(int ID)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Cadena);
                conexion.Open();

                string query = "DELETE Producto WHERE ID = " + ID;
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return new RespuestaModel(ID, "Eliminado", false);
            }
            catch
            {
                return new RespuestaModel();
            }
        }

        public ProductoModel getProducto(int ID)
        {
            try
            {
                ProductoModel objModel = new ProductoModel();
                SqlConnection conexion = new SqlConnection(Cadena);
                conexion.Open();
                string query = "SELECT top (1) * FROM Producto WHERE ID = " + ID;
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                da.Fill(ds, "Productos");

                objModel.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                objModel.Nombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
                objModel.PCompra = Convert.ToDecimal(ds.Tables[0].Rows[0]["PCompra"].ToString());
                objModel.PVenta = Convert.ToDecimal(ds.Tables[0].Rows[0]["PVenta"].ToString());
                objModel.Stock = Convert.ToDecimal(ds.Tables[0].Rows[0]["Stock"].ToString());
                objModel.ID_Unidad = Convert.ToInt32(ds.Tables[0].Rows[0]["ID_Unidad"].ToString());
                objModel.Unidad = Help.Variables.getUnidad(objModel.ID_Unidad);

                ds.Dispose();
                da.Dispose();
                conexion.Close();

                return objModel;
            }
            catch
            {
                return new ProductoModel();
            }
        }

        public ProductoModel getProducto(string Nombre)
        {
            throw new NotImplementedException();
        }

        private string ObjetoToLinea(ProductoModel objModel)
        {
            string Datos = objModel.ID + ",'" + objModel.Nombre + "'," +
                    objModel.PVenta + "," + objModel.PCompra + "," + objModel.Stock +
                    "," + objModel.ID_Unidad + ")";

            return Datos;
        }

    }
}
