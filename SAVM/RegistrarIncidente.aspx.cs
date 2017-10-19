using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Capa_Entidades;
using Capa_Negocio;

namespace SAVM
{
	public partial class RegistrarIncidente : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        [WebMethod]
        public static List<TipoIncidencia> ListarTipoIncidente()
        {
            List<TipoIncidencia> Lista = null;

            Lista = IncidenteLN.GetInstance().ListarTipoIncidente();

            return Lista;

        }

      

    }
}