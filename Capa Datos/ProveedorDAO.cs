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

		public List<RepProveedor> ListarProveedores()
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
	}
}
