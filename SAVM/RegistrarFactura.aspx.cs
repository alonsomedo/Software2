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
    public partial class RegistrarFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool RegistrarFacturaProveedor(string _codFactura,string _fecha,long _ruc, decimal _total)
        {
            bool resultado = false;
            FacturaProveedor objFactura = new FacturaProveedor()
            {
                NroFactura = _codFactura,
                FecFactura = _fecha,
                Proveedor = new Proveedor()
                {
                    RUC = _ruc
                },
                Total = _total

            };

            return resultado = FacturaLN.GetInstance().RegistrarFacturaProveedor(objFactura);
        }

    }
}