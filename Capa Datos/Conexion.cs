using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
	public class Conexion
	{
		#region "PATRON SINGLETON"
		private static Conexion conexion = null;

		private Conexion() { }
		public static Conexion GetInstance()
		{
			if (conexion == null)
			{
				conexion = new Conexion();
			}
			return conexion;
		}
		#endregion

		//public SqlConnection ConexionDB()
		//{
		//	SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
		//	return cn;
		//}

		public SqlConnection ConexionDB()
        {
         
            SqlConnection cn = new
                SqlConnection(@"server = 192.168.1.60; Initial Catalog=MUNDOFARMA_BD; user id=admin;password=admin");

            return cn;
        }
	}
}
