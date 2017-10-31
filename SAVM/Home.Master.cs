using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAVM
{
	public partial class Home : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnManual_Click(object sender, ImageClickEventArgs e)
        {
            string FileName = "Copia de CV.MedinaDonayre.pdf";
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "application/pdf";
            response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
            response.TransmitFile(Server.MapPath("~/manual/Copia de CV.MedinaDonayre.pdf"));
            response.Flush();
            response.End();

        }
    }
}