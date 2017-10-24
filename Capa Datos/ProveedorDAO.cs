using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class ProveedorDAO
    {
        #region "PATRON SINGLETON"
        private static ProveedorDAO objDAO = null;
        private ProveedorDAO() { }
        public static ProveedorDAO GetInstance()
        {
            if (objDAO == null)
            {
                objDAO = new ProveedorDAO();
            }
            return objDAO;
        }
        #endregion

        public List<RepProveedor> ListarRepProveedores()
        {
            List<RepProveedor> lista = new List<RepProveedor>();

            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new SqlCommand("SP_LISTARPROVEEDORES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RepProveedor obj = new RepProveedor()
                    {
                        Nombre = Convert.ToString(dr[0]),
                        Paterno = Convert.ToString(dr[1]),
                        Materno = Convert.ToString(dr[2]),
                        Telefono = Convert.ToString(dr[3]),
                        Correo = Convert.ToString(dr[4]),
                        Proveedor = new Proveedor()
                        {
                            RUC = Convert.ToInt64(dr[5]),
                            RazonSocial = Convert.ToString(dr[6]),
                            Direccion = Convert.ToString(dr[7]),
                        }
                    };
                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public string CalcularIncidentesProveedor(Proveedor objProveedor)
        {
            SqlConnection cn = null;
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string nroincidentes = "";
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new SqlCommand("SP_INCIDENTESPROVEEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NRORUC", objProveedor.RUC);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nroincidentes = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return nroincidentes;
        }

        public Proveedor RegistrarProveedor(Proveedor objProveedor)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            SqlConnection cn = null;
            Proveedor Proveedor = new Proveedor();
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new SqlCommand("SP_REGISTRARPROVEEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RAZSOCIAL", objProveedor.RazonSocial);
                cmd.Parameters.AddWithValue("@RUC", objProveedor.RUC);
                cmd.Parameters.AddWithValue("@DIRECCION", objProveedor.Direccion);
                cmd.Parameters.AddWithValue("@ESTADO", objProveedor.Estado);
                //Representante Proveedor
                cmd.Parameters.AddWithValue("@CORREO", objProveedor.Representante.Correo);
                cmd.Parameters.AddWithValue("@NOMBRE", objProveedor.Representante.Nombre);
                cmd.Parameters.AddWithValue("@PATERNO", objProveedor.Representante.Paterno);
                cmd.Parameters.AddWithValue("@MATERNO", objProveedor.Representante.Materno);
                cmd.Parameters.AddWithValue("@TELEFONO", objProveedor.Representante.Telefono);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    {

                        Proveedor.RUC = Convert.ToInt64(dr[0]);
                        Proveedor.RazonSocial = Convert.ToString(dr[1]);
                        Proveedor.Direccion = Convert.ToString(dr[2]);
                        Proveedor.Representante = new RepProveedor()
                        {

                            Nombre = Convert.ToString(dr[3]),
                            Paterno = Convert.ToString(dr[4]),
                            Materno = Convert.ToString(dr[5]),
                            Telefono = Convert.ToString(dr[6]),
                            Correo = Convert.ToString(dr[7]),
                        };

                    };
                }
                return Proveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }

    }
}
