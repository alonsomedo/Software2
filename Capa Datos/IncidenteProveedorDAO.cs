﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class IncidenteProveedorDAO
    {
        #region "PATRON SINGLETON"
        private static IncidenteProveedorDAO DaoIncidente = null;
        private IncidenteProveedorDAO() { }
        public static IncidenteProveedorDAO GetInstance()
        {
            if (DaoIncidente == null)
            {
                DaoIncidente = new IncidenteProveedorDAO();
            }
            return DaoIncidente;
        }
        #endregion

        public List<TipoIncidencia> ListarTipoIncidente()
        {
            SqlConnection cn = null;
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            List<TipoIncidencia> lista = new List<TipoIncidencia>();
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new SqlCommand("SP_LISTATIPOINCIDENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoIncidencia ObjTipoIncidencia = new TipoIncidencia()
                    {
                        Descripcion = Convert.ToString(dr[0])

                    };
                    lista.Add(ObjTipoIncidencia);
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
            return lista;
        }


        public bool RegistrarIncidenteProveedor(IncidenteProveedor objIncidente )
        {
            bool resultado = false;
            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {
                cn = Conexion.GetInstance().ConexionDB();

                cmd = new SqlCommand("SP_REGISTRARINCIDENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RUC", objIncidente.RucPro);
                cmd.Parameters.AddWithValue("@DESCRIPCION", objIncidente.Descripcion);
                cmd.Parameters.AddWithValue("@TIPOINCIDENTE", objIncidente.TipoIncidencia.Descripcion);
                cmd.Parameters.AddWithValue("@FECHA", objIncidente.FecIncidente);
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

        public List<IncidenteProveedor> ListarIncidentes()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<IncidenteProveedor> Lista = new List<IncidenteProveedor>();

            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new SqlCommand("SP_LISTARINCIDENTES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IncidenteProveedor objIncidentes = new IncidenteProveedor()
                    {
                        Proveedor = new Proveedor()
                        {
                            RUC = long.Parse(dr[0].ToString()),
                            RazonSocial = dr[1].ToString(),
                        },
                        Descripcion = dr[2].ToString(),
                        TipoIncidencia = new TipoIncidencia()
                        {
                            Descripcion = dr[3].ToString()
                        },
                        FecIncidente = Convert.ToDateTime(dr[4].ToString()).ToShortDateString()

                    };
                    Lista.Add(objIncidentes);
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
