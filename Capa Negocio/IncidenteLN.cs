using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidades;

namespace Capa_Negocio
{
    public class IncidenteLN
    {
        #region "PATRON SINGLETON"
        private static IncidenteLN ObjIncidente = null;
        private IncidenteLN() { }
        public static IncidenteLN GetInstance()
        {
            if (ObjIncidente == null)
            {
                ObjIncidente = new IncidenteLN();
            }
            return ObjIncidente;
        }

        #endregion


        public List<TipoIncidencia> ListarTipoIncidente()
        {
            try
            {
                return IncidenteProveedorDAO.GetInstance().ListarTipoIncidente();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
