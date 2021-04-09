using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ConnexionClass;
using DatabaseLogin;
using System.Web.Services;

namespace WebApplication4
{
	public partial class Index : System.Web.UI.Page
	{
		public List<List<string>> results;
		public List<List<string>> resultsPost;
		public List<byte[]> imgPost;

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

			sql = "SELECT Post.id_post, Post.titre, DATE_FORMAT(Post.date_pub, \"%d/%m/%Y\"), Post.img_apercu, Compte.pseudo FROM Post NATURAL JOIN Compte";
			cmd = new MySqlCommand(sql, con);
			rdr = cmd.ExecuteReader();

			List<List<string>> resultsPost = new List<List<string>>();
			List<Byte[]> imgPost = new List<Byte[]>();

			while (rdr.Read())
			{
				List<string> l = new List<string>();
				l.Add(Convert.ToString(rdr.GetValue(0)));
				l.Add(Convert.ToString(rdr.GetValue(1)));
				l.Add(Convert.ToString(rdr.GetValue(2)));
				imgPost.Add((byte[])rdr.GetValue(3));
				l.Add(Convert.ToString(rdr.GetValue(4)));
				resultsPost.Add(l);

			}

			rdr.Close();

			string output = "";
			int cpt = 0;
			string idCpt = "0";

			HttpContext context = HttpContext.Current;

            if (context.Session["id"] != null)
            {
				idCpt = (string)context.Session["id"];
            }

            foreach (var item in resultsPost)
            {
				sql = "SELECT COUNT(*) FROM LikePost WHERE id_post="+item[0];
				cmd = new MySqlCommand(sql, con);
				rdr = cmd.ExecuteReader();

				string nbLike = "";

				while (rdr.Read())
				{
					nbLike = Convert.ToString(rdr.GetValue(0));
				}
				rdr.Close();

				string classLike = "gris";

                if (context.Session["id"] != null)
                {
					sql = "SELECT COUNT(*) FROM LikePost WHERE id_post=" + item[0]+ " && id_cpt="+context.Session["id"];
					cmd = new MySqlCommand(sql, con);
					rdr = cmd.ExecuteReader();

					string isLike = "";

					while (rdr.Read())
					{
						isLike = Convert.ToString(rdr.GetValue(0));
					}
					rdr.Close();

					if (isLike == "1")
					{
						classLike = "rouge";
					}
                }

				output += "<div class=\"each-post\" data-idpost='"+item[0]+"'>"+
				  "<div class=\"minia-post\" style=\"background-image: url('data:image/jpeg;base64," + Convert.ToBase64String(imgPost[cpt]) + "')\"></div>" +
				"<div class=\"top-post\">" +
					"<h3><asp:Label runat=\"server\" id=\"namePost\" >" + item[1] + "</asp:Label></h3>" +
					"<div id=\"div"+cpt+"\" style=\"display: flex; align-items: center;\">" +
						"<p class=\"nb_like\" style=\"margin-right: 10px\">"+nbLike+ "</p>" +
						"<i data-idpost='" + item[0] + "' class=\"fa fa-heart " + classLike+ "\"></i>" +
					"</div>" +
				"</div>" +
                "<div class=\"infos-post\">"+
					"<p>Date de mise en ligne : " + item[2] + "</p>" +
				"</div>" +
                "<a href=\"poste.aspx?id="+item[0]+ "\">Voir plus</a>" +
			"</div>";
				cpt++;

			}

			allPost.InnerHtml = output;

			con.Close();
		}

		[WebMethod]
		public static string LikePost(string idCpt, string idPoste)
		{
			var con = Database.Connect();
			con.Open();

			string sql = "SELECT COUNT(*) FROM LikePost WHERE id_post="+idPoste+" && id_cpt="+idCpt;
			var cmd = new MySqlCommand(sql, con);
			MySqlDataReader rdr = cmd.ExecuteReader();

			int isLiked = 0;
			while (rdr.Read())
			{
				isLiked = Convert.ToInt32(rdr.GetValue(0));
			}
			rdr.Close();

            if (isLiked == 0)
            {
				// si non like on like
				sql = "INSERT INTO LikePost(id_post, id_cpt) values(" + idPoste + ", " + idCpt + ")";
				cmd = new MySqlCommand(sql, con);
				cmd.ExecuteReader();
				return "like";
			} else
            {
				// si like on unlike
				sql = "DELETE FROM LikePost WHERE id_cpt=" + idCpt + " && id_post=" + idPoste;
				cmd = new MySqlCommand(sql, con);
				cmd.ExecuteReader();
				return "unlike";
			}

			return "true";
		}
	}
}