using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
	public class ProveedorLN
	{
		#region "PATRON SINGLETON"
		private static ProveedorLN objLN = null;
		private ProveedorLN() { }
		public static ProveedorLN GetInstance()
		{
			if (objLN == null)
			{
				objLN = new ProveedorLN();
			}
			return objLN;
		}
		#endregion

		public List<RepProveedor> ListarMedicamento()
		{
			try
			{
				return ProveedorDAO.GetInstance().ListarProveedores();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
