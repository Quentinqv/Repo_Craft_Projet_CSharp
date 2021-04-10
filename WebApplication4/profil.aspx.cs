using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseLogin;
using MySql.Data.MySqlClient;

namespace WebApplication4
{
    public partial class profil : System.Web.UI.Page
    {
        public List<string> results;
        public string idCpt;

        protected void Page_Load(object sender, EventArgs e)
        {
            string idParam = Request.QueryString["id"];
            if (idParam == null)
            {
                Response.Redirect("index.aspx");
            }
            /*Response.Write(idParam);*/

            var con = Database.Connect();
            con.Open();

            HttpContext context = HttpContext.Current;

            if (context.Session["id"] != null)
            {
                string sql1 = "SELECT COUNT(*) FROM LiaisonAmi WHERE id_cpt1=" + context.Session["id"] + " && id_cpt2=" + idParam + " || id_cpt1=" + idParam + " && id_cpt2=" + context.Session["id"];
                var cmd1 = new MySqlCommand(sql1, con);
                MySqlDataReader rdr3 = cmd1.ExecuteReader();

                string isFriend = "";

                while (rdr3.Read())
                {
                    isFriend = Convert.ToString(rdr3.GetValue(0));
                }

                rdr3.Close();

                if (isFriend == "1")
                {
                    friend.Text = "Retirer des amis";
                }
            }

            string sql = "SELECT id_cpt, pseudo, email, DATE_FORMAT(date_nais, \"%d/%m/%Y\"), avatar, tel, DATE_FORMAT(date_inscription, \"%d/%m/%Y\") FROM Compte WHERE id_cpt=" + idParam;
            var cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<string> results = new List<string>();

            while (rdr.Read())
            {
                results.Add(Convert.ToString(rdr.GetValue(0)));
                results.Add(Convert.ToString(rdr.GetValue(1)));
                results.Add(Convert.ToString(rdr.GetValue(2)));
                results.Add(Convert.ToString(rdr.GetValue(3)));
                results.Add(Convert.ToString(rdr.GetValue(4)));
                results.Add(Convert.ToString(rdr.GetValue(5)));
                results.Add(Convert.ToString(rdr.GetValue(6)));
            }

            /*Response.Write(results[1]);*/
            idCpt = results[0];
            titreNom.Text = results[1];
            emailCompteId.Text = "Email: "+results[2];
            dateNaisId.Text = "Date de naissance: " + results[3];
            telId.Text = "Téléphone: " + results[5];
            dateInscriptionId.Text = "Date d'inscription: " + results[6];

            if (!IsPostBack)
            {
                emailCompteIdInput.Text = results[2];
                dateNaisIdInput.Text = results[3];
                telIdInput.Text = results[5];
            }

            rdr.Close();

            sql = "SELECT COUNT(*) FROM Post WHERE id_cpt=" + idParam;
            cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr1 = cmd.ExecuteReader();
            string nbPubli = "";
            while (rdr1.Read())
            {
                nbPubli = Convert.ToString(rdr1.GetValue(0));
            }

            nbPubliId.Text = nbPubli;

            rdr1.Close();

            sql = "SELECT COUNT(*) FROM LiaisonAmi WHERE id_cpt1=" + idParam+" OR id_cpt2="+idParam;
            cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr2 = cmd.ExecuteReader();
            string nbAmis = "";
            while (rdr2.Read())
            {
                nbAmis = Convert.ToString(rdr2.GetValue(0));
            }

            nbAmisId.Text = nbAmis;

            rdr2.Close();

            sql = "SELECT Post.id_post, Post.img_apercu FROM Post NATURAL JOIN Compte WHERE id_cpt="+ idParam;
            cmd = new MySqlCommand(sql, con);
            rdr = cmd.ExecuteReader();

            List<List<string>> resultsPost = new List<List<string>>();
            List<Byte[]> imgPost = new List<Byte[]>();

            while (rdr.Read())
            {
                List<string> l = new List<string>();
                l.Add(Convert.ToString(rdr.GetValue(0)));
                imgPost.Add((byte[])rdr.GetValue(1));
                resultsPost.Add(l);
            }

            rdr.Close();

            string output = "";

            int cpt = 0;

            foreach (var item in resultsPost)
            {
                sql = "SELECT COUNT(*) FROM LikePost WHERE id_post=" + item[0];
                cmd = new MySqlCommand(sql, con);
                rdr = cmd.ExecuteReader();

                string nbLike = "";

                while (rdr.Read())
                {
                    nbLike = Convert.ToString(rdr.GetValue(0));
                }
                rdr.Close();

                sql = "SELECT COUNT(*) FROM Commentaire WHERE id_post=" + item[0];
                cmd = new MySqlCommand(sql, con);
                rdr = cmd.ExecuteReader();

                string nbCom = "";

                while (rdr.Read())
                {
                    nbCom = Convert.ToString(rdr.GetValue(0));
                }
                rdr.Close();

                output += "<a href=\"poste.aspx?id=" + item[0] + "\" class=\"post-profil\" data-idpost=\"" + item[0]+ "\" style=\"background-image: url('data:image/jpeg;base64," + Convert.ToBase64String(imgPost[cpt]) + "')\">" +
                                   "<div class=\"hover-post\">" +
                                    "<i class=\"fa fa-heart\"></i> <span>"+nbLike+"</span>" +
                                    "<i class=\"fa fa-comment\"></i> <span>"+nbCom+"</span>" +
                                "</div>" +
                            "</a>";
                cpt++;
            }

            postProfil.InnerHtml = output;

            sql = "SELECT Compte.pseudo, Compte.id_cpt FROM LiaisonAmi NATURAL JOIN Compte WHERE id_cpt1=" + idParam + " || id_cpt2=" + idParam;
            cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr4 = cmd.ExecuteReader();

            List<List<string>> listAmis = new List<List<string>>();

            while (rdr4.Read())
            {
                if (Convert.ToString(rdr4.GetValue(0)) != results[1])
                {
                    List<string> l = new List<string>();
                    l.Add(Convert.ToString(rdr4.GetValue(0)));
                    l.Add(Convert.ToString(rdr4.GetValue(1)));
                    listAmis.Add(l);
                }
            }

            string outputAmis = "<h6>Les amis:</h6>";

            foreach (var item in listAmis)
            {
                outputAmis += "<a href=\"profil.aspx?id="+item[1]+"\">"+item[0]+"</a>";
            }

            rdr4.Close();

            amisProfil.InnerHtml = outputAmis;
        }

        protected void friend_Click(object sender, EventArgs e)
        {
            var con = Database.Connect();
            con.Open();

            HttpContext context = HttpContext.Current;

            string sql = "SELECT COUNT(*) FROM LiaisonAmi WHERE id_cpt1="+ context.Session["id"]+ " && id_cpt2="+idCpt+ " || id_cpt1="+idCpt + " && id_cpt2="+ context.Session["id"];
            var cmd = new MySqlCommand(sql, con);
            var rdr = cmd.ExecuteReader();

            string isFriend = "";

            while (rdr.Read())
            {
                isFriend = Convert.ToString(rdr.GetValue(0));
            }

            rdr.Close();

            if (isFriend != "1")
            {
                sql = "INSERT INTO LiaisonAmi(id_cpt1, id_cpt2) values(" + context.Session["id"] + ", " + idCpt + ")";
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteReader();

                friend.Text = "Retirer des amis";
                int v = Convert.ToInt32(nbAmisId.Text) + 1;
                nbAmisId.Text = Convert.ToString(v);
            } else
            {
                sql = "DELETE FROM LiaisonAmi WHERE id_cpt1=" + context.Session["id"] + " && id_cpt2=" + idCpt + " || id_cpt1=" + idCpt + " && id_cpt2=" + context.Session["id"];
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteReader();

                friend.Text = "Ajouter en ami";
                int v = Convert.ToInt32(nbAmisId.Text) - 1;
                nbAmisId.Text = Convert.ToString(v);
            }

        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (emailCompteIdInput.Text == "" || dateNaisIdInput.Text == "" || telIdInput.Text == "")
            {
                Response.Redirect(Request.Url.ToString()+"&update=false");
            }

            var con = Database.Connect();
            con.Open();

            HttpContext context = HttpContext.Current;

            string[] dateNaisSplit = dateNaisIdInput.Text.Split('/');
            string dateNais = dateNaisSplit[2] + "-" + dateNaisSplit[1] + "-" + dateNaisSplit[0];

            string sql = "UPDATE Compte SET email=\""+ emailCompteIdInput.Text + "\", date_nais=\"" + dateNais + "\", tel=\"" + telIdInput.Text + "\" WHERE id_cpt=" + context.Session["id"];
            var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteReader();

            Response.Redirect(Request.Url.ToString());
        }

        protected void disconnect_Click(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            context.Session.Clear();
            context.Session.Abandon();
        }
    }
}