using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
	public class OrdenCompraLN
	{
		#region "PATRON SINGLETON"
		private static OrdenCompraLN obj = null;
		private OrdenCompraLN() { }
		public static OrdenCompraLN GetInstance()
		{
			if (obj == null)
			{
				obj = new OrdenCompraLN();
			}
			return obj;
		}
		#endregion

		public string GenerarNroOC()
		{
			try
			{
				return OrdenCompraDAO.GetInstance().GenerarNroOC();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool RegistrarOC(OrdenCompra obj)
		{
			try
			{
				return OrdenCompraDAO.GetInstance().RegistrarOC(obj);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool RegistrarDetalleOC(DetalleOrdenCompra obj)
		{
			try
			{
				return OrdenCompraDAO.GetInstance().RegistrarDetalleOC(obj);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
