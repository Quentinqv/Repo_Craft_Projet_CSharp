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

            string sql = "SELECT id_cpt, pseudo, email, date_nais, avatar, tel, date_inscription FROM Compte WHERE id_cpt="+idParam;
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
        }

        protected void addFriend_Click(object sender, EventArgs e)
        {

        }

        protected void modifierCompte_Click(object sender, EventArgs e)
        {

        }

        protected void disconnect_Click(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            context.Session.Clear();
            context.Session.Abandon();
        }
    }
}