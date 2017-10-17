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
	public class UsuarioDAO
	{
		#region "PATRON SINGLETON"
		private static UsuarioDAO DaoUsuario = null;

		private UsuarioDAO() { }
		public static UsuarioDAO GetInstance()
		{
			if (DaoUsuario == null)
			{
				DaoUsuario = new UsuarioDAO();
			}
			return DaoUsuario;
		}
		#endregion

		public Usuario AccesoSistema(String usuario, String clave)
		{
			SqlConnection cn = null;
			SqlCommand cmd = null;
			Usuario objUsuario = null;
			SqlDataReader dr = null;

			try
			{
				cn = Conexion.GetInstance().ConexionDB();

				cmd = new SqlCommand("SP_ACCESOSISTEMA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@username", usuario);
				cmd.Parameters.AddWithValue("@password", clave);
				cn.Open();
				dr = cmd.ExecuteReader();
				if (dr.Read())
				{
					objUsuario = new Usuario();
					objUsuario.Username = dr[0].ToString();
					objUsuario.Pass = dr[1].ToString();
				}
			}
			catch (SqlException ex)
			{
				objUsuario = null;
				throw ex;
			}
			finally
			{
				cn.Close();
			}

			return objUsuario;

		}
	}
}
