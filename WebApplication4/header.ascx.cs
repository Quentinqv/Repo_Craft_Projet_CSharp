using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConnexionClass;

namespace WebApplication4
{
	public partial class header : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}
		protected void btnSubmit_Click_Connect(object sender, EventArgs e)
		{
			string output = Connexion.ToConnect(pseudoConnect.Value, passwordConnect.Value);
            Response.Write(output);
            Response.Write(Session["pseudo"]);
            Response.Write(Session["email"]);
        }
	}
}