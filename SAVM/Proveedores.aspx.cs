using Capa_Entidades;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAVM
{
	public partial class Proveedores : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["usuario"] == null)
			{
				Response.Redirect("Login.aspx");
			}
		}

		[WebMethod]
		public static List<RepProveedor> ListarRepProveedores()
		{
			List<RepProveedor> Lista = null;
			Lista = ProveedorLN.GetInstance().ListarRepProveedores();
			return Lista;
		}

        [WebMethod]
        public static string CalcularIncidentesProveedor(long _ruc)
        {
            string incidentes = "0";
            Proveedor objProveedor = new Proveedor()
            {
                RUC = _ruc
            };
            incidentes = ProveedorLN.GetInstance().CalcularIncidentesProveedor(objProveedor);

            return incidentes;
        }

    }
}