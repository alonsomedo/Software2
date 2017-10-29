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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return resultado;

        }

        public bool RegistrarDetalleFacturaProveedor(DetalleFacturaProveedor objDetalleFactura)
        {
            bool resultado = false;
            SqlCommand cmd = null;
            SqlConnection cn = null;
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new SqlCommand("SP_REGDETALLEFACTURA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PREUNITARIO", objDetalleFactura.PreUnitario);
                cmd.Parameters.AddWithValue("@CANTIDAD", objDetalleFactura.Cantidad);
                cmd.Parameters.AddWithValue("@IMPORTE", objDetalleFactura.Importe);
                cmd.Parameters.AddWithValue("@NROFACTURA", objDetalleFactura.FacturaProveedor.NroFactura);
                cmd.Parameters.AddWithValue("@CODMEDICAMENTO", objDetalleFactura.Medicamento.CodMedicamento);
                cn.Open();

                resultado = cmd.ExecuteNonQuery() >= 1 ? true : false;

            }
            catch (Exception ex)
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
