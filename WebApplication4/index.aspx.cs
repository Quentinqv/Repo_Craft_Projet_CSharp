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
		public List<List<string>> results;
		public List<List<string>> resultsPost;

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

			rdr.Close();

			namePost.Text = results[0][1];

			/*Response.Write(Session["pseudo"]);
			Response.Write(Session["email"]);*/

			sql = "SELECT Post.titre, Post.date_pub, Post.img_apercu, Compte.pseudo FROM Post NATURAL JOIN Compte";
			cmd = new MySqlCommand(sql, con);
			rdr = cmd.ExecuteReader();

			List<List<string>> resultsPost = new List<List<string>>();

			while (rdr.Read())
			{
				List<string> l = new List<string>();
				l.Add(Convert.ToString(rdr.GetValue(0)));
				l.Add(Convert.ToString(rdr.GetValue(1)));
				l.Add(Convert.ToString(rdr.GetValue(2)));
				l.Add(Convert.ToString(rdr.GetValue(3)));
				resultsPost.Add(l);
			}

			/*Response.Write(resultsPost[0][0]);*/

			con.Close();
		}
	}
}