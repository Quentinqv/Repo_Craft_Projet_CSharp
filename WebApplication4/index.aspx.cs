using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebApplication4
{
    public partial class Index : System.Web.UI.Page
    {
        public object date;
		public List<List<string>> results;
		
		protected void Page_Load(object sender, EventArgs e)
        {

			string cs = @"SERVER=mysql-killian.alwaysdata.net; DATABASE=killian_craft; UID=killian_rh_user; PASSWORD=pierrevitouxkillian";
			var con = new MySqlConnection(cs);
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

			/*Response.Write(results[0][0]);
			Response.Write(results[0][1]);*/


			this.date = DateTime.Now;

		}
	}
}