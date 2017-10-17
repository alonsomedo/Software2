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
			//SqlConnection cn = new
			//	SqlConnection("Server=tcp:software2.database.windows.net,1433;Initial Catalog=DB_MUNDOFARMA;Persist Security Info=False;User ID=software2;Password=Mundofarma$2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;");

			SqlConnection cn = new
				SqlConnection(@"server = .\SQLEXPRESS; Initial Catalog=MUNDOFARMA_BD; Integrated Security =SSPI");

			return cn;
		}
	}
}
