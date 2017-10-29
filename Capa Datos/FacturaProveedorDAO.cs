using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capa_Entidades;

namespace Capa_Datos
{
	public class FacturaProveedorDAO
	{
        #region "PATRON SINGLETON"
        private static FacturaProveedorDAO objFacturaDAO = null;
        private FacturaProveedorDAO() { }
        public static FacturaProveedorDAO GetInstance()
        {
            if (objFacturaDAO == null)
            {
                objFacturaDAO = new FacturaProveedorDAO();
            }
            return objFacturaDAO;
        }

        #endregion
        public bool RegistrarFacturaProveedor(FacturaProveedor objFactura)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            bool resultado = false;

            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new SqlCommand("SP_REGISTRARFACTURA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NROFACTURA", objFactura.NroFactura);
                cmd.Parameters.AddWithValue("@FECHA", objFactura.FecFactura);
                cmd.Parameters.AddWithValue("@TOTAL", objFactura.Total);
                cmd.Parameters.AddWithValue("@RUCPRO", objFactura.Proveedor.RUC);
                cn.Open();
                resultado = cmd.ExecuteNonQuery() >= 1 ? true : false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return resultado;

        }


    }
}
