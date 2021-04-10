using DatabaseLogin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class poste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["id"] == null)
            {
                Response.Redirect("index.aspx?login=false");
            }

            string idParam = Request.QueryString["id"];
            if (idParam == null || idParam == "")
            {
                Response.Redirect("index.aspx");
            }

            var con = Database.Connect();
            con.Open();

            string sql = "SELECT Post.titre, DATE_FORMAT(Post.date_pub, \"%d/%m/%Y\"), Post.img_apercu, Compte.pseudo, Post.contenu, Compte.id_cpt FROM Post NATURAL JOIN Compte WHERE id_post="+idParam;
            var cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string titrePoste = "";
            string datePoste = "";
            string pseudoCompte = "";
            string contenuPoste = "";
            string idCompte = "";
            List<Byte[]> imgPost = new List<Byte[]>();

            while (rdr.Read())
            {
                titrePoste = Convert.ToString(rdr.GetValue(0));
                datePoste = Convert.ToString(rdr.GetValue(1));
                imgPost.Add((byte[])rdr.GetValue(2));
                pseudoCompte = Convert.ToString(rdr.GetValue(3));
                contenuPoste = Convert.ToString(rdr.GetValue(4));
                idCompte = Convert.ToString(rdr.GetValue(5));
            }

            rdr.Close();

            sql = "SELECT COUNT(*) FROM LikePost WHERE id_post=" + idParam;
            cmd = new MySqlCommand(sql, con);
            rdr = cmd.ExecuteReader();

            string nbLike = "";

            while (rdr.Read())
            {
                nbLike = Convert.ToString(rdr.GetValue(0));
            }
            rdr.Close();

            sql = "SELECT Compte.id_cpt, Compte.pseudo, Commentaire.contenu FROM Commentaire Natural JOIN Compte WHERE id_post=" + idParam;
            cmd = new MySqlCommand(sql, con);
            rdr = cmd.ExecuteReader();

            List<List<string>> resultsComs = new List<List<string>>();

            while (rdr.Read())
            {
                List<string> l = new List<string>();
                l.Add(Convert.ToString(rdr.GetValue(0)));
                l.Add(Convert.ToString(rdr.GetValue(1)));
                l.Add(Convert.ToString(rdr.GetValue(2)));
                resultsComs.Add(l);
            }

            rdr.Close();

            sql = "SELECT COUNT(*) FROM LikePost WHERE id_post=" + idParam + " && id_cpt=" + context.Session["id"];
            cmd = new MySqlCommand(sql, con);
            rdr = cmd.ExecuteReader();

            string isLike = "";
            string classLike = "gris";

            while (rdr.Read())
            {
                isLike = Convert.ToString(rdr.GetValue(0));
            }
            rdr.Close();

            if (isLike == "1")
            {
                classLike = "rouge";
            }

            string outputComs = "";
            foreach (var item in resultsComs)
            {
                outputComs += "<div class=\"each-com-post\">"+
                                "<p>"+item[2]+"</p>"+
                               "</div>"+
                               "<a href=\"profil.aspx?id=" + item[0] + "\">" + item[1] + "</a>";
            }

            string output = "<div class=\"each-post-uniq\">"+
                "<div class=\"top-post\">"+
                    "<h3>"+titrePoste+"</h3>"+
                    "<div>"+
                        "<span class=\"nb_like\">"+nbLike+"</span>"+
                        "<i class=\"fa fa-heart "+classLike+"\" data-idpost=\""+idParam+"\"></i>"+
                    "</div>"+
                "</div>"+
                "<div class=\"minia-post\" style=\"background-image: url('data:image/jpeg;base64," + Convert.ToBase64String(imgPost[0]) + "')\">" +
                "</div>"+
                "<div class=\"contenu_post\">"+
                    "<p>"+contenuPoste+"</p>"+
                "</div>"+
                "<div class=\"footer-post\">"+
                    "<p>Poste publié par<a title=\"Voir le profil\" href=\"profil.aspx?id="+idCompte+"\"> "+pseudoCompte+"</a> le "+datePoste+".</p>"+
                "</div>"+
                "<div class=\"com-post\">"+outputComs+
                "</div>"+
            "</div>";

            postUniq.InnerHtml = output;
        }

        protected void commenter_Click(object sender, EventArgs e)
        {
            var con = Database.Connect();
            con.Open();

            HttpContext context = HttpContext.Current;

            string sql = "INSERT INTO Commentaire(id_post, id_cpt, contenu) values(" + Request.QueryString["id"] + ", " + context.Session["id"] + ", \""+ textareaAddCom.Value+ "\")";
            var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteReader();

            Response.Redirect(Request.Url.ToString());
        }
    }
}