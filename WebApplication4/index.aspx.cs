using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using ConnexionClass;
using DatabaseLogin;

namespace WebApplication4
{
	public partial class Index : System.Web.UI.Page
	{
		public object date;
		public List<List<string>> results;

		protected void Page_Load(object sender, EventArgs e)
		{
			var con = Database.Connect();
			con.Open();

			string sql = "SELECT * FROM Compte";
			var cmd = new MySqlCommand(sql, con);
			MySqlDataReader rdr = cmd.ExecuteReader();

			List<List<string>> results = new List<List<string>>();

			while (rdr.Read())
			{
				List<string> l = new List<string>();
				l.Add(Convert.ToString(rdr.GetValue(0)));
				l.Add(Convert.ToString(rdr.GetValue(1)));
				results.Add(l);
			}
			con.Close();

			namePost.Text = results[0][1];

			/*Response.Write(Session["pseudo"]);
			Response.Write(Session["email"]);*/

			this.date = DateTime.Now;

		}
	}
}