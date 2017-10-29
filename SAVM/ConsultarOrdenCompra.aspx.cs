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
    public partial class ConsultarOrdenCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<OrdenCompra> ListarOrdenCompra()
        {
            List<OrdenCompra> Lista = null;

            Lista = OrdenCompraLN.GetInstance().ListarOrdenCompra();

            return Lista;
            
        }
    }
}