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
	public class MedicamentoDAO
	{
		#region "PATRON SINGLETON"
		private static MedicamentoDAO DaoMedicamento = null;
		private MedicamentoDAO() { }
		public static MedicamentoDAO GetInstance()
		{
			if (DaoMedicamento == null)
			{
				DaoMedicamento = new MedicamentoDAO();
			}
			return DaoMedicamento;
		}
		#endregion

		public List<Medicamento> ListarMedicamento()
		{
			List<Medicamento> lista = new List<Medicamento>();
			SqlConnection cn = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			try
			{
				cn = Conexion.GetInstance().ConexionDB();
				cmd = new SqlCommand("SP_LISTAMEDICAMENTOS", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cn.Open();
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					Medicamento ObjMedicamento = new Medicamento()
					{
						CodMedicamento = Convert.ToString(dr[0]),
						Descripcion = Convert.ToString(dr[1]),
						PrecioCompra = Convert.ToDecimal(dr[2]),
						PrecioVenta = Convert.ToDecimal(dr[3]),
						Stock = Convert.ToInt32(dr[4]),
						StockMinimo = Convert.ToInt32(dr[5]),
						FechaVencimiento = Convert.ToString(dr[6]),
						TipoMedicamento = new TipoMedicamento()
						{
							Descripcion = Convert.ToString(dr[7]),
						},

						Proveedor = new Proveedor()
						{
							RazonSocial = dr[8].ToString()
						}

					};
					lista.Add(ObjMedicamento);
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
