﻿using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
	public class OrdenCompraDAO
	{
		#region "PATRON SINGLETON"
		private static OrdenCompraDAO ocompra = null;

		private OrdenCompraDAO() { }
		public static OrdenCompraDAO GetInstance()
		{
			if (ocompra == null)
			{
				ocompra = new OrdenCompraDAO();
			}
			return ocompra;
		}
		#endregion

		public string GenerarNroOC()
		{
			string codigo_oc = string.Empty;
			int valor = 0;
			int year = DateTime.Today.Year;
			string substring = string.Empty;

			SqlConnection cn = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			try
			{
				cn = Conexion.GetInstance().ConexionDB();

				cmd = new SqlCommand("select top 1 CODORDCOMPRA FROM ORDENDECOMPRA ORDER BY CODORDCOMPRA DESC", cn);
				cn.Open();
				dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					if (Convert.ToString(dr[0]).ToString().Length >= 1)
					{
						substring = Convert.ToString(dr[0]).Substring(7);
					}
					else
					{
						substring = "0";
					}

					valor = Convert.ToInt32(substring) + 1;

					if (valor < 10)
					{
						codigo_oc = string.Format("OC" + "{0}" + "0000" + "{1}", year.ToString(), valor.ToString());
					}
					if (valor >= 10)
					{
						codigo_oc = string.Format("OC" + "{0}" + "000" + "{1}", year.ToString(), valor.ToString());
					}
					if (valor >= 100)
					{
						codigo_oc = string.Format("OC" + "{0}" + "00" + "{1}", year.ToString(), valor.ToString());
					}
					if (valor >= 1000)
					{
						codigo_oc = string.Format("OC" + "{0}" + "0" + "{1}", year.ToString(), valor.ToString());
					}
				}
				else
				{
					codigo_oc = string.Format("OC" + "{0}" + "00001", year.ToString());
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				cn.Close();
			}
			return codigo_oc;
		}

		public bool RegistrarOC(OrdenCompra obj)
		{
			bool resultado = false;
			SqlConnection cn = null;
			SqlCommand cmd = null;

			try
			{
				cn = Conexion.GetInstance().ConexionDB();
				
				cmd = new SqlCommand("SP_REGORDENCOMPRA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@CODORDCOMPRA", obj.CodOrdCompra);
				cmd.Parameters.AddWithValue("@FECORDCOMPRA", obj.FecOrdCompra);
				cmd.Parameters.AddWithValue("@IGV", obj.Igv);
				cmd.Parameters.AddWithValue("@TOTAL", obj.Total);
				cmd.Parameters.AddWithValue("@RUCPRO", obj.Proveedor.RUC);
				cn.Open();
				resultado = cmd.ExecuteNonQuery() >= 1 ? true : false;

			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				cn.Close();
			}

			return resultado;
		}

		public bool RegistrarDetalleOC(DetalleOrdenCompra obj)
		{
			bool resultado = false;
			SqlConnection cn = null;
			SqlCommand cmd = null;

			try
			{
				cn = Conexion.GetInstance().ConexionDB();

				cmd = new SqlCommand("SP_REGDETALLEORDENCOMPRA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@PREUNITARIO", obj.Precio);
				cmd.Parameters.AddWithValue("@CANTIDAD", obj.Cantidad);
				cmd.Parameters.AddWithValue("@SUBTOTAL", obj.Subtotal);
				cmd.Parameters.AddWithValue("@CODMEDICAMENTO", obj.Medicamento.CodMedicamento);
				cmd.Parameters.AddWithValue("@CODORDCOMPRA", obj.OrdenCompra.CodOrdCompra);
				cn.Open();
				resultado = cmd.ExecuteNonQuery() >= 1 ? true : false;

			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				cn.Close();
			}

			return resultado;
		}

        public List<OrdenCompra> ListarOrdenCompra()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<OrdenCompra> Lista = new List<OrdenCompra>();

            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new SqlCommand("SP_LISTARORDENCOMPRA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    OrdenCompra objOrdenCompra = new OrdenCompra()
                    {
                        CodOrdCompra = dr[0].ToString(),
                        FecOrdCompra = DateTime.Parse(dr[1].ToString()).ToShortDateString(),
                        Igv = Convert.ToDecimal(dr[2]),
                        Total = Convert.ToDecimal(dr[3]),
                        Proveedor = new Proveedor()
                        {
                            RUC = long.Parse(dr[4].ToString()),
                            RazonSocial = dr[5].ToString()
                        }

                    };
                    Lista.Add(objOrdenCompra);
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return Lista;
        }

        public List<DetalleOrdenCompra> ListarDetalleOC(string codOrdenCompra)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<DetalleOrdenCompra> Lista = new List<DetalleOrdenCompra>();

            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new SqlCommand("SP_DETALLEOC", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODOC", codOrdenCompra);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DetalleOrdenCompra objDetalleOC = new DetalleOrdenCompra()
                    {
                        IdDetalle = Convert.ToInt32(dr[0].ToString()),
                        Medicamento = new Medicamento()
                        {
                            CodMedicamento = dr[1].ToString(),
                            Descripcion = dr[2].ToString()
                        },
                        Precio = Convert.ToDecimal(dr[3].ToString()),
                        Cantidad = Convert.ToInt32(dr[4].ToString()),
                        Subtotal = Convert.ToDecimal(dr[5].ToString())
                    };
                    Lista.Add(objDetalleOC);
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
            return Lista;
        }


    }
}