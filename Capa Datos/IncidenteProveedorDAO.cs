using System;
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
    }
}
